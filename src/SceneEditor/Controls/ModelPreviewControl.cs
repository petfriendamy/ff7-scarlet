using FF7Scarlet.Shared;
using KimeraCS.Core;
using KimeraCS.Rendering;
using OpenTK.Graphics.OpenGL.Compatibility;
using OpenTK.Mathematics;
using static KimeraCS.Core.FF7BattleSkeleton;
using static KimeraCS.Core.FF7BattleAnimationsPack;

namespace FF7Scarlet.SceneEditor.Controls
{
    public partial class ModelPreviewControl : UserControl
    {
        private const string CONTEXT_ID = "ModelPreview";
        private readonly Color4<Rgba> CLEAR_COLOR = new Color4<Rgba>(0.4f, 0.4f, 0.65f, 0);
        private RenderingContext? renderContext;
        private bool isDragging = false;
        private bool isPanning = false;
        private Point lastMousePosition;
        private const float ROTATION_SPEED = 0.5f;
        private const float ZOOM_SPEED = 0.3f;
        private const float PAN_SPEED = 1.0f;

        public bool Loaded { get; private set; }
        public bool ModelLoaded { get; private set; }

        public (float RotateX, float RotateY) RotationAngles
        {
            get
            {
                if (renderContext != null)
                {
                    return (renderContext.Transform.RotateX, renderContext.Transform.RotateY);
                }
                return (0, 0);
            }
        }

        public ModelPreviewControl()
        {
            InitializeComponent();
        }

        private void ModelPreviewControl_Load(object sender, EventArgs e)
        {
            if (DataManager.BattleLgp != null)
            {
                glControl.MakeCurrent();
                GLRenderer.SetCurrentContext(CONTEXT_ID);
                GL.Enable(EnableCap.DepthTest);
                GL.ClearColor(CLEAR_COLOR);
                GLRenderer.Initialize();
                Loaded = true;
            }
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

        private void ModelPreviewControl_Paint(object sender, PaintEventArgs e)
        {
            if (Loaded && DataManager.BattleLgp != null)
            {
                glControl.MakeCurrent();
                GLRenderer.SetCurrentContext(CONTEXT_ID);

                SetOGLSettings();

                GL.Viewport(0, 0, glControl.ClientRectangle.Width, glControl.ClientRectangle.Height);
                GL.ClearColor(CLEAR_COLOR);
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                if (renderContext != null)
                {
                    ModelDrawing.DrawSkeletonModel(renderContext);
                }

                GL.Flush();
                glControl.SwapBuffers();
            }
        }

        public void LoadModel(ushort modelID)
        {
            ModelTransform savedTransform = ModelTransform.Default;
            if (renderContext != null)
            {
                savedTransform = renderContext.Transform;
            }

            renderContext = null;
            ModelLoaded = false;

            if (DataManager.BattleLgp != null)
            {
                var load = DataManager.BattleLgp.GetModelData(modelID);
                if (load != null)
                {
                    var anim = DataManager.BattleLgp.GetAnimationData((BattleSkeleton)load, modelID);
                    if (anim != null)
                    {
                        Vector3 p_min = new(), p_max = new();
                        var modelData = new SkeletonModelData();
                        modelData.BattleSkeleton = (BattleSkeleton)load;
                        modelData.BattleAnimations = (BattleAnimationsPack)anim;
                        modelData.TextureIds = ((BattleSkeleton)load).TexIDS;
                        ComputeBattleBoundingBox(
                            modelData.BattleSkeleton,
                            modelData.BattleAnimations.SkeletonAnimations[0].frames[0],
                            ref p_min, ref p_max);

                        renderContext = RenderingContext.CreateWithModelData(
                            ModelType.K_AA_SKELETON,
                            modelData,
                            new CameraState
                            {
                                Alpha = 200,
                                Beta = 45,
                                Gamma = 0,
                                Distance = -1.25f * Utils.ComputeSceneRadius(p_min, p_max),
                                PanX = 0,
                                PanY = -300,
                                PanZ = 0
                            },
                            AnimationState.Default,
                            new LightingConfig(),
                            savedTransform
                        );
                        ModelLoaded = true;
                    }
                }
                this.Invalidate();
            }
        }

        public void Unload()
        {
            GLRenderer.Shutdown();
        }

        private void GlControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (renderContext != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    lastMousePosition = e.Location;
                    glControl.Capture = true;
                    glControl.Focus();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    isPanning = true;
                    lastMousePosition = e.Location;
                    glControl.Capture = true;
                    glControl.Focus();
                }
            }
        }

        private void GlControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (renderContext != null)
            {
                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;

                if (isDragging)
                {
                    var transform = renderContext.Transform;
                    transform.RotateY -= deltaX * ROTATION_SPEED;
                    transform.RotateX += deltaY * ROTATION_SPEED;
                    renderContext.Transform = transform;
                    lastMousePosition = e.Location;
                    this.Invalidate();
                }
                else if (isPanning)
                {
                    var camera = renderContext.Camera;
                    camera.PanX += deltaX * PAN_SPEED;
                    camera.PanY -= deltaY * PAN_SPEED;
                    renderContext.Camera = camera;
                    lastMousePosition = e.Location;
                    this.Invalidate();
                }
            }
        }

        private void GlControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (renderContext != null)
            {
                var camera = renderContext.Camera;
                camera.Distance += e.Delta * ZOOM_SPEED;
                renderContext.Camera = camera;
                this.Invalidate();
            }
        }

        private void GlControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                glControl.Capture = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                isPanning = false;
                glControl.Capture = false;
            }
        }
    }
}
