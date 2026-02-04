using FF7Scarlet.Shared;
using ImGuiNET;
using ImGuizmoNET;
using KimeraCS.Core;
using KimeraCS.Rendering;
using OpenTK.Graphics.OpenGL.Compatibility;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

using static KimeraCS.Core.FF7BattleAnimationsPack;
using static KimeraCS.Core.FF7BattleSkeleton;
using static KimeraCS.Core.FF7PModel;

namespace FF7Scarlet.SceneEditor
{
    public partial class Formation3DEditorForm : Form
    {
        private const string
            WINDOW_TITLE = "Edit formation",
            CONTEXT_ID = "FormationEditor";
        private RenderingContext? context = null;
        private ImGuiController? guiController = null;
        private readonly Formation originalFormation;
        private int selectedModel = -1;

        private const float SCENE_SCALE = 2.5f;
        private readonly Color4<Rgba> CLEAR_COLOR = new Color4<Rgba>(0, 0, 0, 0);
        private readonly RadioButton[] cameras;
        private const float PICK_THRESHOLD = 50f;
        private readonly double[] cachedProjection = new double[16];
        private readonly double[] cachedModelview = new double[16];
        private readonly int[] cachedViewport = new int[4];

        private Point glMousePos;
        private bool glMouseLeft, glMouseRight;
        private bool gizmoWasUsing;

        // Camera control state
        private bool isOrbiting = false;
        private bool isCameraPanning = false;
        private Point lastCameraMousePos;
        private const float ORBIT_SPEED = 0.5f;
        private const float PAN_SPEED = 50f;
        private const float ZOOM_SPEED = 500f;

        bool loading = true;
        bool unsavedChanges = false, committedChanges = false;

        public Formation EditedFormation { get; private set; }
        private int CurrentCamera
        {
            get
            {
                for (int i = 0; i < 4; ++i)
                {
                    if (cameras[i].Checked) { return i; }
                }
                return -1;
            }
        }

        public Formation3DEditorForm(Formation formation)
        {
            InitializeComponent();
            originalFormation = formation;
            EditedFormation = new Formation(formation);

            glControl.Profile = ContextProfile.Compatability;

            cameras = [
                radioButton1, radioButton2, radioButton3, radioButton4
                ];

            foreach (var rb in cameras)
            {
                rb.CheckedChanged += Camera_CheckedChanged;
            }
            numericEnemyX.Minimum = short.MinValue;
            numericEnemyY.Minimum = short.MinValue;
            numericEnemyZ.Minimum = short.MinValue;
            numericEnemyX.Maximum = short.MaxValue;
            numericEnemyY.Maximum = short.MaxValue;
            numericEnemyZ.Maximum = short.MaxValue;

            cameraPositionControl.GroupBoxText = "Camera";
            var cam = EditedFormation.CameraPlacementData;
            cameraPositionControl.SetPosition(cam.CameraPositions[0], cam.CameraDirections[0]);

            loading = false;
        }

        private void Formation3DEditorForm_Load(object sender, EventArgs e)
        {
            glControl.MakeCurrent();
            GLRenderer.SetCurrentContext(CONTEXT_ID);
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(CLEAR_COLOR);
            GLRenderer.Initialize();
            guiController = new ImGuiController(glControl.Width, glControl.Height);

            //share the ImGui context with ImGuizmo's separate native library
            ImGuizmo.SetImGuiContext(ImGui.GetCurrentContext());

            //load the enemy models
            var skeletons = new BattleSkeleton[Formation.ENEMY_COUNT + 1];
            var anims = new BattleAnimationsPack[Formation.ENEMY_COUNT + 1];
            for (int i = 0; i < Formation.ENEMY_COUNT; ++i)
            {
                if (DataManager.BattleLgp == null) //load a placeholder model
                {
                    skeletons[i] = CreatePlaceholderSkeleton(Properties.Resources.Cube, "CUBE", false);
                    anims[i] = CreatePlaceholderAnimation(skeletons[i]);
                }
                else //load the actual model
                {
                    ushort modelID = EditedFormation.EnemyLocations[i].EnemyID;
                    var load = DataManager.BattleLgp.GetModelData(modelID);
                    if (load != null)
                    {
                        skeletons[i] = (BattleSkeleton)load;
                        var anim = DataManager.BattleLgp.GetAnimationData((BattleSkeleton)load, modelID);
                        if (anim == null)
                        {
                            //should never happen
                            anims[i] = CreatePlaceholderAnimation(skeletons[i]);
                        }
                        else
                        {
                            anims[i] = (BattleAnimationsPack)anim;
                        }
                    }
                }
            }

            //load the battle arena
            if (DataManager.BattleLgp == null)
            {
                skeletons[Formation.ENEMY_COUNT] =
                    CreatePlaceholderSkeleton(Properties.Resources.Plane, "PLANE", true);
            }
            else
            {
                var id = EditedFormation.BattleSetupData.Location?.LocationID;
                if (id != null)
                {
                    var arena = (DataManager.BattleLgp.GetBattleArena((ushort)id) ?? new BattleSkeleton());
                    skeletons[Formation.ENEMY_COUNT] = arena;
                }
            }
            anims[Formation.ENEMY_COUNT] = CreatePlaceholderAnimation(skeletons[Formation.ENEMY_COUNT]);

            //create the rendering context
            var modelData = new SkeletonModelData
            {
                BattleSkeletons = skeletons,
                BattleAnimations = anims
            };
            context = RenderingContext.CreateWithModelData(ModelType.K_AA_SKELETON, modelData);

            //tell the rendering context to skip its own camera setup
            context.UseExternalCamera = true;

            //update the current view camera
            UpdateView();
        }

        private void SetOGLSettings()
        {
            GL.ClearDepth(1.0f);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            GL.CullFace(TriangleFace.Front);
            GL.Enable(EnableCap.CullFace);

            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Greater, 0);
        }

        private BattleSkeleton CreatePlaceholderSkeleton(byte[] data, string name, bool isBattleLocation)
        {
            var model = new PModel();
            LoadPModel(ref model, data, $"{name}.P");
            model.repositionY = model.BoundingBox.max_y;

            var bone = new BattleBone
            {
                parentBone = -1,
                len = 0,
                hasModel = 1,
                nModels = 1,
                Models = [model],
                resizeX = 1,
                resizeY = 1,
                resizeZ = 1
            };

            return new BattleSkeleton
            {
                fileName = name,
                IsBattleLocation = isBattleLocation,
                nBones = 1,
                bones = [bone],
                wpModels = [],
                textures = [],
                TexIDS = [],
                nsSkeletonAnims = 1
            };
        }

        private BattleAnimationsPack CreatePlaceholderAnimation(BattleSkeleton skeleton)
        {
            var anim = new BattleAnimationsPack
            {
                SkeletonAnimations = [],
                WeaponAnimations = []
            };
            CreateCompatibleBattleAnimationsPack(skeleton, ref anim);
            return anim;
        }

        private void glControl_Enter(object sender, EventArgs e)
        {
            glControl.Focus();
        }

        private void DrawScene()
        {
            if (context == null) return;

            float aspect = (float)glControl.ClientRectangle.Width / glControl.ClientRectangle.Height;

            var eye = new Vector3(context.Camera.Eye.X, context.Camera.Eye.Y, context.Camera.Eye.Z);
            var target = new Vector3(context.Camera.Target.X, context.Camera.Target.Y, context.Camera.Target.Z);
            var up = -Vector3.UnitY;

            //avoid degenerate lookAt when eye == target
            if ((target - eye).LengthSquared < 0.001f)
            {
                target = eye + Vector3.UnitZ;
            }

            var projection = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(60f), aspect, 10f, 100000f);
            var view = Matrix4.LookAt(eye, target, up);
            var scale = Matrix4.CreateScale(SCENE_SCALE);

            //set up projection on the legacy GL matrix stack
            //DrawPModel reads from these legacy matrices, not GLRenderer properties
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.MultMatrixd(Matrix4ToDoubleArray(projection));

            //set up view matrix (camera lookAt) on the legacy stack
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.MultMatrixd(Matrix4ToDoubleArray(view));
            GL.Scaled(SCENE_SCALE, SCENE_SCALE, SCENE_SCALE);

            GLRenderer.ViewPosition = eye;

            //cache matrices for hit testing (before per-enemy translations)
            GL.GetDouble(GetPName.ProjectionMatrix, cachedProjection);
            GL.GetDouble(GetPName.ModelviewMatrix, cachedModelview);
            GL.GetInteger(GetPName.Viewport, cachedViewport);

            //draw each enemy at its world position
            for (int i = 0; i < Formation.ENEMY_COUNT; i++)
            {
                var enemy = EditedFormation.EnemyLocations[i];
                if (enemy.EnemyID == HexParser.NULL_OFFSET_16_BIT) continue;

                //push the current view matrix, then translate to the enemy's world position
                GL.MatrixMode(MatrixMode.Modelview);
                GL.PushMatrix();
                GL.Translated(enemy.Location.X, enemy.Location.Y, enemy.Location.Z);
                if (EditedFormation.BattleSetupData.BattleType != BattleType.BackAttack)
                    GL.Rotated(180, 0, 1, 0);
                ModelDrawing.DrawSkeletonModel(context, i);

                GL.PopMatrix();
            }

            //draw the battle arena
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();

            //battle arenas have different rotation data
            GL.Rotated(90, 1, 0, 0);
            GL.Rotated(180, 0, 1, 0);
            GL.Rotated(180, 0, 0, 1);

            ModelDrawing.DrawSkeletonModel(context, Formation.ENEMY_COUNT);
            GL.PopMatrix();

            //ImGuizmo overlay — frame is managed by UpdateForWinForms + guiController.Render()
            ImGuizmo.BeginFrame();
            ImGuizmo.SetOrthographic(false);
            ImGuizmo.SetRect(0, 0, glControl.ClientRectangle.Width, glControl.ClientRectangle.Height);

            //draw ImGuizmo translation gizmo for selected enemy
            if (selectedModel >= 0 && guiController != null)
            {
                //read the GL matrices directly — they are already column-major,
                //which is exactly what ImGuizmo expects
                float[] glViewF = new float[16];
                float[] glProjF = new float[16];
                GL.GetFloat(GetPName.ModelviewMatrix, glViewF);
                GL.GetFloat(GetPName.ProjectionMatrix, glProjF);

                var loc = EditedFormation.EnemyLocations[selectedModel].Location;
                //the GL modelview already includes SCENE_SCALE, so the model matrix
                //uses game coordinates directly (no extra scaling)
                float[] modelMat =
                [
                    1, 0, 0, 0,
                    0, 1, 0, 0,
                    0, 0, 1, 0,
                    loc.X, loc.Y, loc.Z, 1
                ];

                ImGuizmo.Manipulate(ref glViewF[0], ref glProjF[0],
                    OPERATION.TRANSLATE, MODE.WORLD, ref modelMat[0]);

                if (ImGuizmo.IsUsing())
                {
                    //translation is at column-major indices 12, 13, 14 (game coordinates)
                    float nx = modelMat[12];
                    float ny = modelMat[13];
                    float nz = modelMat[14];

                    short sx = (short)Math.Clamp(Math.Round(nx), short.MinValue, short.MaxValue);
                    short sy = (short)Math.Clamp(Math.Round(ny), short.MinValue, short.MaxValue);
                    short sz = (short)Math.Clamp(Math.Round(nz), short.MinValue, short.MaxValue);

                    EditedFormation.EnemyLocations[selectedModel].Location = new Point3D(sx, sy, sz);

                    loading = true;
                    numericEnemyX.Value = sx;
                    numericEnemyY.Value = sy;
                    numericEnemyZ.Value = sz;
                    loading = false;

                    SetUnsaved(true, true);
                    gizmoWasUsing = true;
                }
                else
                {
                    gizmoWasUsing = false;
                }
            }
            else
            {
                gizmoWasUsing = false;
            }
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            if (context != null)
            {
                glControl.MakeCurrent();
                GLRenderer.SetCurrentContext(CONTEXT_ID);

                //begin ImGui frame with current mouse state
                guiController?.UpdateForWinForms(
                    glControl.ClientRectangle.Width, glControl.ClientRectangle.Height,
                    glMousePos, glMouseLeft, glMouseRight, false);

                SetOGLSettings();

                GL.Viewport(0, 0, glControl.ClientRectangle.Width, glControl.ClientRectangle.Height);
                GL.ClearColor(CLEAR_COLOR);
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                DrawScene();

                //render ImGui/ImGuizmo overlay
                guiController?.Render();

                GL.Flush();
                glControl.SwapBuffers();
            }
        }

        private void UpdateView()
        {
            if (context != null)
            {
                var cam = EditedFormation.CameraPlacementData;
                int i = CurrentCamera;
                context.Camera = new CameraState
                {
                    Eye = cam.CameraPositions[i].ToOpenTK(),
                    Target = cam.CameraDirections[i].ToOpenTK()
                };
            }
        }

        /// <summary>
        /// Orbits the camera around the target point based on mouse delta.
        /// </summary>
        private void OrbitCamera(int deltaX, int deltaY)
        {
            if (context == null) return;

            var camera = context.Camera;
            var eye = camera.Eye;
            var target = camera.Target;

            // Vector from target to eye
            var offset = eye - target;
            float distance = offset.Length;

            if (distance < 0.001f) return;

            // Convert to spherical coordinates
            // theta = horizontal angle (around Y axis)
            // phi = vertical angle (from Y axis)
            float theta = MathF.Atan2(offset.X, offset.Z);
            float phi = MathF.Acos(Math.Clamp(offset.Y / distance, -1f, 1f));

            // Apply rotation from mouse movement
            theta -= deltaX * ORBIT_SPEED * MathF.PI / 180f;
            phi += deltaY * ORBIT_SPEED * MathF.PI / 180f;

            // Clamp phi to avoid flipping (keep between ~5 and ~175 degrees)
            phi = Math.Clamp(phi, 0.05f, MathF.PI - 0.05f);

            // Convert back to Cartesian coordinates
            float sinPhi = MathF.Sin(phi);
            var newOffset = new Vector3(
                distance * sinPhi * MathF.Sin(theta),
                distance * MathF.Cos(phi),
                distance * sinPhi * MathF.Cos(theta)
            );

            camera.Eye = target + newOffset;
            context.Camera = camera;
        }

        /// <summary>
        /// Pans the camera by moving both eye and target in the view plane.
        /// </summary>
        private void PanCamera(int deltaX, int deltaY)
        {
            if (context == null) return;

            var camera = context.Camera;
            var eye = camera.Eye;
            var target = camera.Target;

            // Calculate view direction and right/up vectors
            var forward = Vector3.Normalize(target - eye);
            var worldUp = -Vector3.UnitY; // Scene uses -Y as up
            var right = Vector3.Normalize(Vector3.Cross(forward, worldUp));
            var up = Vector3.Cross(right, forward);

            // Calculate pan offset
            var panOffset = right * (-deltaX * PAN_SPEED) + up * (deltaY * PAN_SPEED);

            // Move both eye and target
            camera.Eye = eye + panOffset;
            camera.Target = target + panOffset;
            context.Camera = camera;
        }

        /// <summary>
        /// Zooms the camera by moving the eye closer to or farther from the target.
        /// </summary>
        private void ZoomCamera(int wheelDelta)
        {
            if (context == null) return;

            var camera = context.Camera;
            var eye = camera.Eye;
            var target = camera.Target;

            // Direction from eye to target
            var direction = target - eye;
            float distance = direction.Length;

            if (distance < 0.001f) return;
            direction = Vector3.Normalize(direction);

            // Calculate zoom amount (positive wheelDelta = zoom in)
            float zoomAmount = wheelDelta * ZOOM_SPEED / 120f; // 120 is standard wheel delta

            // Don't zoom past the target or too far away
            float newDistance = distance - zoomAmount;
            newDistance = Math.Clamp(newDistance, 100f, 50000f);

            camera.Eye = target - direction * newDistance;
            context.Camera = camera;
        }

        private void Camera_CheckedChanged(object? sender, EventArgs e)
        {
            if (context != null)
            {
                if (cameraPositionControl.ViewMode)
                {
                    var result = MessageDialog.AskYesNo("Commit camera position?", "Commit changes?");
                    if (result == DialogResult.Yes)
                    {
                        cameraPositionControl.CommitChanges();
                    }
                    else
                    {
                        cameraPositionControl.ResetChanges();
                    }
                }
                var cam = EditedFormation.CameraPlacementData;
                int i = CurrentCamera;
                loading = true;
                cameraPositionControl.SetPosition(cam.CameraPositions[i], cam.CameraDirections[i]);
                UpdateView();
                glControl.Invalidate();
                loading = false;
            }
        }

        /// <summary>
        /// Projects a world-space point to screen coordinates using the cached
        /// GL matrices (column-major). Equivalent to gluProject.
        /// </summary>
        private static bool GluProject(double objX, double objY, double objZ,
            double[] modelview, double[] projection, int[] viewport,
            out double winX, out double winY, out double winZ)
        {
            //transform by modelview (column-major: M[col*4+row])
            double ex = modelview[0] * objX + modelview[4] * objY + modelview[8] * objZ + modelview[12];
            double ey = modelview[1] * objX + modelview[5] * objY + modelview[9] * objZ + modelview[13];
            double ez = modelview[2] * objX + modelview[6] * objY + modelview[10] * objZ + modelview[14];
            double ew = modelview[3] * objX + modelview[7] * objY + modelview[11] * objZ + modelview[15];

            //transform by projection
            double cx = projection[0] * ex + projection[4] * ey + projection[8] * ez + projection[12] * ew;
            double cy = projection[1] * ex + projection[5] * ey + projection[9] * ez + projection[13] * ew;
            double cz = projection[2] * ex + projection[6] * ey + projection[10] * ez + projection[14] * ew;
            double cw = projection[3] * ex + projection[7] * ey + projection[11] * ez + projection[15] * ew;

            if (cw == 0.0)
            {
                winX = winY = winZ = 0;
                return false;
            }

            //perspective division
            double ndcX = cx / cw;
            double ndcY = cy / cw;
            double ndcZ = cz / cw;

            //map to window coordinates
            winX = viewport[0] + viewport[2] * (ndcX * 0.5 + 0.5);
            winY = viewport[1] + viewport[3] * (ndcY * 0.5 + 0.5);
            winZ = ndcZ * 0.5 + 0.5;
            return true;
        }

        private int HitTest(Point mousePosition)
        {
            int closestIndex = -1;
            float closestDist = float.MaxValue;

            for (int i = 0; i < Formation.ENEMY_COUNT; i++)
            {
                var enemy = EditedFormation.EnemyLocations[i];
                if (enemy.EnemyID == HexParser.NULL_OFFSET_16_BIT) continue;

                if (GluProject(enemy.Location.X, enemy.Location.Y, enemy.Location.Z,
                               cachedModelview, cachedProjection, cachedViewport,
                               out double sx, out double sy, out _))
                {
                    //GL Y is bottom-up, screen Y is top-down
                    sy = cachedViewport[3] - sy;

                    float dx = (float)(sx - mousePosition.X);
                    float dy = (float)(sy - mousePosition.Y);
                    float dist = MathF.Sqrt(dx * dx + dy * dy);

                    if (dist < PICK_THRESHOLD && dist < closestDist)
                    {
                        closestDist = dist;
                        closestIndex = i;
                    }
                }
            }

            return closestIndex;
        }

        private void glControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //skip all other actions when the gizmo is being manipulated
                if (!gizmoWasUsing)
                {
                    //check if there's a model to select
                    glMouseLeft = true;
                    var mousePos = glControl.PointToClient(Cursor.Position);
                    int prevModel = selectedModel;
                    selectedModel = HitTest(mousePos);

                    groupBoxEnemy.Enabled = selectedModel >= 0;
                    if (selectedModel >= 0)
                    {
                        loading = true;
                        var enemyLocation = EditedFormation.EnemyLocations[selectedModel].Location;
                        numericEnemyX.Value = enemyLocation.X;
                        numericEnemyY.Value = enemyLocation.Y;
                        numericEnemyZ.Value = enemyLocation.Z;
                        loading = false;
                    }
                    else if (prevModel == -1)
                    {
                        // Start orbiting
                        isOrbiting = true;
                        lastCameraMousePos = e.Location;
                        glControl.Capture = true;
                    }
                    glControl.Invalidate();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                glMouseRight = true;
                // Start panning with right mouse button
                isCameraPanning = true;
                lastCameraMousePos = e.Location;
                glControl.Capture = true;
            }
            if (gizmoWasUsing)
                glControl.Invalidate();
        }

        private void glControl_MouseMove(object? sender, MouseEventArgs e)
        {
            glMousePos = e.Location;

            // Handle camera controls
            if (isOrbiting || isCameraPanning)
            {
                int deltaX = e.X - lastCameraMousePos.X;
                int deltaY = e.Y - lastCameraMousePos.Y;

                if (isOrbiting)
                {
                    OrbitCamera(deltaX, deltaY);
                }
                else if (isCameraPanning)
                {
                    PanCamera(deltaX, deltaY);
                }

                lastCameraMousePos = e.Location;
                var cam = context.Camera;
                cameraPositionControl.SetPosition(cam.Eye, cam.Target, true);
                SetUnsaved(true);
                glControl.Invalidate();
            }
            else if (glMouseLeft && selectedModel >= 0)
            {
                glControl.Invalidate();
            }
        }

        private void glControl_MouseUp(object? sender, MouseEventArgs e)
        {
            if (glControl.Capture)
            {
                var cam = context.Camera;
                cameraPositionControl.SetPosition(cam.Eye, cam.Target, true);
            }
            if (e.Button == MouseButtons.Left)
            {
                glMouseLeft = false;
                isOrbiting = false;
                glControl.Capture = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                glMouseRight = false;
                isCameraPanning = false;
                glControl.Capture = false;
            }
            if (gizmoWasUsing)
                glControl.Invalidate();
        }

        private void glControl_MouseWheel(object? sender, MouseEventArgs e)
        {
            ZoomCamera(e.Delta);
            var cam = context.Camera;
            cameraPositionControl.SetPosition(cam.Eye, cam.Target, true);
            SetUnsaved(true);
            glControl.Invalidate();
        }

        private void cameraPositionControl_DataChanged(object sender, EventArgs e)
        {
            if (!loading && context != null)
            {
                if (!cameraPositionControl.ViewMode)
                {
                    var cam = EditedFormation.CameraPlacementData;
                    int i = CurrentCamera;
                    cam.CameraPositions[i] = cameraPositionControl.GetPosition();
                    cam.CameraDirections[i] = cameraPositionControl.GetAngle();
                }
                UpdateView();
                SetUnsaved(true, !cameraPositionControl.ViewMode);
                glControl.Invalidate();
            }
        }

        private void cameraPositionControl_DataReset(object sender, EventArgs e)
        {
            if (context != null)
            {
                UpdateView();
                if (!committedChanges)
                    SetUnsaved(false);
                glControl.Invalidate();
            }
        }

        private void numericEnemy_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && selectedModel >= 0)
            {
                EditedFormation.EnemyLocations[selectedModel].Location = new Point3D(
                    (short)numericEnemyX.Value,
                    (short)numericEnemyY.Value,
                    (short)numericEnemyZ.Value);
                if (context != null)
                    glControl.Invalidate();

                SetUnsaved(true, true);
            }
        }

        private void SetUnsaved(bool unsaved, bool commit = false)
        {
            unsavedChanges = unsaved;
            if (!committedChanges) committedChanges = commit;
            Text = $"{(unsaved ? "*" : "")}{WINDOW_TITLE}";
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (MessageDialog.AskYesNo("Reset all camera and position data?") == DialogResult.Yes)
            {
                loading = true;
                EditedFormation = new Formation(originalFormation);
                if (cameraPositionControl.ViewMode)
                    cameraPositionControl.ResetChanges();
                else
                {
                    var cam = EditedFormation.CameraPlacementData;
                    int i = CurrentCamera;
                    cameraPositionControl.SetPosition(cam.CameraPositions[i], cam.CameraDirections[i]);
                }
                UpdateView();
                if (context != null)
                    glControl.Invalidate();
                SetUnsaved(false);
                loading = false;
            }
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {
            if (cameraPositionControl.ViewMode)
            {
                var result = MessageDialog.AskYesNoCancel("Commit camera position?", "Commit changes?");
                if (result == DialogResult.Yes)
                {
                    cameraPositionControl.CommitChanges();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            SetUnsaved(false);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Formation3DEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsavedChanges)
                e.Cancel = MessageDialog.AskYesNo("Exit without committing changes?", "Unsaved changes") == DialogResult.No;
        }

        private void Formation3DEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GLRenderer.Shutdown();
            guiController.Dispose();
        }
    }
}
