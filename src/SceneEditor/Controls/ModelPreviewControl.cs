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

        public bool Loaded { get; private set; }
        public bool ModelLoaded { get; private set; }

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
                            new LightingConfig()
                        );
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
    }
}
