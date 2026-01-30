using FF7Scarlet.Shared;
using KimeraCS.Core;
using KimeraCS.Rendering;
using OpenTK.Graphics.OpenGL.Compatibility;
using OpenTK.Mathematics;
using static KimeraCS.Core.FF7BattleSkeleton;
using BattleAnimPack = KimeraCS.Core.FF7BattleAnimationsPack.BattleAnimationsPack;

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
        private const int ANIMATION_FPS = 15;

        private System.Windows.Forms.Timer? animationTimer;
        private KimeraCS.Core.FF7BattleAnimationsPack.BattleAnimationsPack? loadedAnimations;
        private bool isPlaying;
        private int totalFrames;
        private AnimationState currentAnimationState;
        private bool timerInitialized = false;

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

        public (int Current, int Total) FrameInfo
        {
            get
            {
                if (renderContext != null)
                {
                    return (renderContext.Animation.CurrentFrame, totalFrames);
                }
                return (0, 0);
            }
        }

        public ModelPreviewControl()
        {
            InitializeComponent();

            if (!timerInitialized)
            {
                animationTimer = new System.Windows.Forms.Timer();
                animationTimer.Interval = 1000 / ANIMATION_FPS;
                animationTimer.Tick += AnimationTimer_Tick;
                timerInitialized = true;
            }
            Disposed += ModelPreviewControl_Disposed;
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

        public void SetAnimation(int animationIndex)
        {
            if (renderContext != null && loadedAnimations != null)
            {
                if (animationIndex < 0 || animationIndex >= loadedAnimations.Value.SkeletonAnimations.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(animationIndex),
                        $"Animation index {animationIndex} is out of range. Available animations: 0-{loadedAnimations.Value.SkeletonAnimations.Count - 1}");
                }

                currentAnimationState.AnimationIndex = animationIndex;
                int frameCount = loadedAnimations.Value.SkeletonAnimations[animationIndex].frames.Count;
                currentAnimationState.CurrentFrame = frameCount > 0 ? 0 : 0;
                currentAnimationState.WeaponAnimationIndex = -1;
                renderContext.Animation = currentAnimationState;
                totalFrames = frameCount;

                UpdateFrameCounter();

                if (totalFrames > 0)
                {
                    StartAnimation();
                }
                else
                {
                    PauseAnimation();
                }

                this.Invalidate();
            }
        }

        private void StartAnimation()
        {
            if (!isPlaying && totalFrames > 0 && animationTimer != null)
            {
                isPlaying = true;
                animationTimer.Start();
            }
        }

        public void PauseAnimation()
        {
            isPlaying = false;
            animationTimer?.Stop();
        }

        public void StopAnimation()
        {
            PauseAnimation();
            if (renderContext != null)
            {
                currentAnimationState.CurrentFrame = 0;
                currentAnimationState.AnimationIndex = renderContext.Animation.AnimationIndex;
                currentAnimationState.WeaponAnimationIndex = -1;
                renderContext.Animation = currentAnimationState;
                UpdateFrameCounter();
                this.Invalidate();
            }
        }

        private int GetActualFrameCount()
        {
            if (loadedAnimations != null && renderContext != null)
            {
                int animIndex = Math.Max(0, Math.Min(renderContext.Animation.AnimationIndex, loadedAnimations.Value.SkeletonAnimations.Count - 1));
                return loadedAnimations.Value.SkeletonAnimations[animIndex].frames.Count;
            }
            return 0;
        }

        private void AdvanceFrame()
        {
            if (renderContext != null && loadedAnimations != null)
            {
                int actualFrameCount = GetActualFrameCount();
                if (actualFrameCount > 0)
                {
                    int animIndex = renderContext.Animation.AnimationIndex;
                    animIndex = Math.Max(0, Math.Min(animIndex, loadedAnimations.Value.SkeletonAnimations.Count - 1));

                    int newFrame = renderContext.Animation.CurrentFrame + 1;
                    int frameCount = loadedAnimations.Value.SkeletonAnimations[animIndex].frames.Count;
                    if (newFrame >= frameCount)
                    {
                        newFrame = 0;
                    }
                    currentAnimationState.CurrentFrame = newFrame;
                    currentAnimationState.AnimationIndex = animIndex;
                    currentAnimationState.WeaponAnimationIndex = -1;
                    renderContext.Animation = currentAnimationState;
                    UpdateFrameCounter();
                    this.Invalidate();
                }
            }
        }

        private void StepFrame(int delta)
        {
            if (renderContext != null && loadedAnimations != null)
            {
                PauseAnimation();

                int animIndex = renderContext.Animation.AnimationIndex;
                animIndex = Math.Max(0, Math.Min(animIndex, loadedAnimations.Value.SkeletonAnimations.Count - 1));

                int frameCount = loadedAnimations.Value.SkeletonAnimations[animIndex].frames.Count;
                if (frameCount > 0)
                {
                    int newFrame = renderContext.Animation.CurrentFrame + delta;
                    if (newFrame < 0)
                    {
                        newFrame = frameCount - 1;
                    }
                    else if (newFrame >= frameCount)
                    {
                        newFrame = 0;
                    }
                    currentAnimationState.CurrentFrame = newFrame;
                    currentAnimationState.AnimationIndex = animIndex;
                    currentAnimationState.WeaponAnimationIndex = -1;
                    renderContext.Animation = currentAnimationState;
                    UpdateFrameCounter();
                    this.Invalidate();
                }
            }
        }

        private void UpdateFrameCounter()
        {
            if (frameCounterLabel != null)
            {
                if (renderContext != null)
                {
                    int currentFrame = renderContext.Animation.CurrentFrame;
                    frameCounterLabel.Text = $"{currentFrame}/{totalFrames}";
                }
                else
                {
                    frameCounterLabel.Text = "0/0";
                }
            }
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            AdvanceFrame();
        }

        private void GlControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (renderContext == null || totalFrames <= 0)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Space:
                    e.Handled = true;
                    if (isPlaying)
                    {
                        PauseAnimation();
                    }
                    else
                    {
                        StartAnimation();
                    }
                    break;

                case Keys.Left:
                    e.Handled = true;
                    StepFrame(-1);
                    break;

                case Keys.Right:
                    e.Handled = true;
                    StepFrame(1);
                    break;
            }
        }

        private void ModelPreviewControl_Enter(object sender, EventArgs e)
        {
            glControl.Focus();
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

                if (renderContext != null && loadedAnimations != null)
                {
                    int animIndex = renderContext.Animation.AnimationIndex;
                    int currentFrame = renderContext.Animation.CurrentFrame;

                    if (loadedAnimations.Value.SkeletonAnimations.Count > 0)
                    {
                        animIndex = Math.Max(0, Math.Min(animIndex, loadedAnimations.Value.SkeletonAnimations.Count - 1));
                        int frameCount = loadedAnimations.Value.SkeletonAnimations[animIndex].frames.Count;
                        currentFrame = Math.Max(0, Math.Min(currentFrame, frameCount - 1));

                        if (animIndex != renderContext.Animation.AnimationIndex || currentFrame != renderContext.Animation.CurrentFrame)
                        {
                            currentAnimationState.AnimationIndex = animIndex;
                            currentAnimationState.CurrentFrame = currentFrame;
                            currentAnimationState.WeaponAnimationIndex = -1;
                            renderContext.Animation = currentAnimationState;
                        }
                    }

                    ModelDrawing.DrawSkeletonModel(renderContext);
                }

                GL.Flush();
                glControl.SwapBuffers();
            }
        }

        public void LoadModel(ushort modelID, int initialAnimationIndex = 0)
        {
            ModelTransform savedTransform = ModelTransform.Default;
            if (renderContext != null)
            {
                savedTransform = renderContext.Transform;
            }

            renderContext = null;
            loadedAnimations = null;
            ModelLoaded = false;
            StopAnimation();
            UpdateFrameCounter();

            if (DataManager.BattleLgp != null)
            {
                var load = DataManager.BattleLgp.GetModelData(modelID);
                if (load != null)
                {
                    var anim = DataManager.BattleLgp.GetAnimationData((BattleSkeleton)load, modelID);
                    if (anim != null)
                    {
                        loadedAnimations = (FF7BattleAnimationsPack.BattleAnimationsPack)anim;

                        Vector3 p_min = new(), p_max = new();
                        var modelData = new SkeletonModelData();
                        modelData.BattleSkeleton = (BattleSkeleton)load;
                        modelData.BattleAnimations = loadedAnimations.Value;
                        modelData.TextureIds = ((BattleSkeleton)load).TexIDS;

                        int safeAnimIndex = Math.Min(initialAnimationIndex, loadedAnimations.Value.SkeletonAnimations.Count - 1);
                        ComputeBattleBoundingBox(
                            modelData.BattleSkeleton,
                            loadedAnimations.Value.SkeletonAnimations[safeAnimIndex].frames[0],
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
                            new AnimationState
                            {
                                AnimationIndex = safeAnimIndex,
                                CurrentFrame = 0,
                                WeaponAnimationIndex = -1
                            },
                            new LightingConfig(),
                            savedTransform
                        );

                        totalFrames = loadedAnimations.Value.SkeletonAnimations[safeAnimIndex].frames.Count;
                        ModelLoaded = true;

                        currentAnimationState.AnimationIndex = safeAnimIndex;
                        currentAnimationState.CurrentFrame = 0;
                        currentAnimationState.WeaponAnimationIndex = -1;

                        if (totalFrames > 0)
                        {
                            UpdateFrameCounter();
                            StartAnimation();
                        }
                        else
                        {
                            UpdateFrameCounter();
                        }
                    }
                }
                this.Invalidate();
            }
        }

        public void Unload()
        {
            GLRenderer.Shutdown();
        }

        private void ModelPreviewControl_Disposed(object? sender, EventArgs e)
        {
            if (animationTimer != null)
            {
                animationTimer.Stop();
                animationTimer.Dispose();
                animationTimer = null;
                timerInitialized = false;
            }
            loadedAnimations = null;
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
