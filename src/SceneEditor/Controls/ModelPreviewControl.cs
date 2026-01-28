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
        private ushort currentModelId;
        private float modelDiameter;

        // Mouse interaction state
        private Point lastMousePosition;
        private bool isDragging;
        private MouseButtons dragButton;

        public bool Loaded { get; private set; }
        public bool ModelLoaded { get; private set; }

        public ModelPreviewControl()
        {
            InitializeComponent();
        }

        private void glControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (renderContext != null && ModelLoaded)
            {
                isDragging = true;
                dragButton = e.Button;
                lastMousePosition = e.Location;
                glControl.Capture = true;
            }
        }

        private void glControl_MouseUp(object? sender, MouseEventArgs e)
        {
            isDragging = false;
            dragButton = MouseButtons.None;
            glControl.Capture = false;
        }

        private void glControl_MouseMove(object? sender, MouseEventArgs e)
        {
            if (renderContext != null && ModelLoaded && isDragging)
            {
                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;

                if (dragButton == MouseButtons.Left)
                {
                    // Left-click drag: Rotate the model
                    // deltaX (horizontal) rotates around Y-axis, deltaY (vertical) rotates around X-axis
                    float rotationSensitivity = 0.5f;
                    renderContext.Camera = renderContext.Camera.WithRotation(
                        renderContext.Camera.Alpha + deltaY * rotationSensitivity,
                        renderContext.Camera.Beta - deltaX * rotationSensitivity,
                        renderContext.Camera.Gamma);
                }
                else if (dragButton == MouseButtons.Right)
                {
                    // Right-click drag: Pan the model
                    // Dragging right should move model right (camera moves left)
                    float panScale = Math.Abs(renderContext.Camera.Distance) * 0.002f;
                    renderContext.Camera = renderContext.Camera.WithPan(
                        renderContext.Camera.PanX + deltaX * panScale,
                        renderContext.Camera.PanY - deltaY * panScale,
                        renderContext.Camera.PanZ);
                }

                lastMousePosition = e.Location;
                glControl.Invalidate();
                this.Invalidate();
            }
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
            renderContext = null;
            ModelLoaded = false;

            if (DataManager.BattleLgp != null)
            {
                //attempt to load the model
                var load = DataManager.BattleLgp.GetModelData(modelID);
                if (load != null)
                {
                    var anim = DataManager.BattleLgp.GetAnimationData((BattleSkeleton)load, modelID);
                    if (anim != null)
                    {
                        var modelData = new SkeletonModelData();
                        modelData.BattleSkeleton = (BattleSkeleton)load;
                        modelData.BattleAnimations = (BattleAnimationsPack)anim;
                        modelData.TextureIds = ((BattleSkeleton)load).TexIDS;

                        // Only calculate camera if this is a different model
                        if (modelID != currentModelId)
                        {
                            var firstFrame = modelData.BattleAnimations.SkeletonAnimations[0].frames[0];

                            // Compute local model bounding box (without battle position)
                            Vector3 modelMin = new(), modelMax = new();
                            ComputeBattleBoundingBoxForViewer(modelData.BattleSkeleton, firstFrame, ref modelMin, ref modelMax);

                            // Calculate model diameter for zoom
                            modelDiameter = Utils.CalculateDistance(modelMin, modelMax);

                            // Compute scene bounds with model at origin for centered viewing
                            // The model is conceptually at (0,0,0) for the viewer
                            var positionedModels = new CameraUtils.PositionedModel[]
                            {
                                new CameraUtils.PositionedModel
                                {
                                    Skeleton = modelData.BattleSkeleton,
                                    Frame = firstFrame,
                                    PositionX = 0,
                                    PositionY = 0,
                                    PositionZ = 0
                                }
                            };

                            Vector3 sceneMin = new(), sceneMax = new(), sceneCenter = new();
                            float sceneRadius = CameraUtils.ComputeSceneBoundingBox(
                                positionedModels, ref sceneMin, ref sceneMax, ref sceneCenter);

                            // Set camera to look at origin (where model will be centered)
                            var camera = CameraUtils.ResetCameraForCenteredScene(
                                sceneMin, sceneMax, sceneCenter,
                                glControl.ClientRectangle.Width,
                                glControl.ClientRectangle.Height);

                            renderContext = RenderingContext.CreateWithModelData(
                                ModelType.K_AA_SKELETON,
                                modelData,
                                camera,
                                AnimationState.Default,
                                new LightingConfig()
                            );

                            currentModelId = modelID;
                        }
                        else
                        {
                            // Reuse existing camera state for the same model
                            renderContext = RenderingContext.CreateWithModelData(
                                ModelType.K_AA_SKELETON,
                                modelData,
                                renderContext?.Camera ?? CameraState.Default,
                                AnimationState.Default,
                                new LightingConfig()
                            );
                        }

                        ModelLoaded = true;
                    }
                }
                glControl.Invalidate();
                this.Invalidate();
            }
        }

        public void Unload()
        {
            GLRenderer.Shutdown();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (renderContext != null && ModelLoaded)
            {
                // Calculate zoom delta based on model diameter
                float zoomDelta = CameraUtils.CalculateZoomDelta(modelDiameter, e.Delta);

                // Apply zoom to camera distance
                renderContext.Camera = renderContext.Camera.WithDistance(
                    renderContext.Camera.Distance + zoomDelta);

                // Redraw
                glControl.Invalidate();
                this.Invalidate();
            }
            base.OnMouseWheel(e);
        }
    }
}
