using SdlSharp;
using SdlSharp.Graphics;

namespace Citadel.Display
{
    public sealed class DisplaySubsystem : Subsystem
    {
        private readonly DisplayConfiguration _configuration;

        private Window _window;
        private Renderer _renderer;
        private Texture _backBuffer;

        internal DisplaySubsystem(SdlConfiguration sdlConfiguration, DisplayConfiguration configuration)
        {
            _configuration = configuration;
            sdlConfiguration.RequireSdlSubsystems(Subsystems.Video);
            sdlConfiguration.RequireSdlImageFormats(ImageFormats.Png);

            // These will be initialized below.
            _window = null!;
            _renderer = null!;
            _backBuffer = null!;
        }

        public override bool Initialize(Game game)
        {
            if (!base.Initialize(game))
            {
                return false;
            }

            _window = Window.Create(_configuration.Title, (Window.UndefinedWindowLocation, (0, 0)), WindowFlags.Hidden);

            _renderer = Renderer.Create(_window, -1, RendererFlags.Accelerated | RendererFlags.PresentVSync | RendererFlags.TargetTexture);
            _backBuffer = _renderer.CreateTexture(_window.PixelFormat, TextureAccess.Target, _configuration.Size);
            _backBuffer.BlendMode = BlendMode.Blend;

            RecalculateWindowSize();
            _window.SetVisible(true);

            return true;
        }

        private void RecalculateWindowSize()
        {
            EnsureInitialized();
            var scale = _window.Display.Dpi.Horizontal / 96;
            _window.Size = _backBuffer.Size * scale;
        }

        public override void Tick()
        {
            _renderer.Target = _backBuffer;
            _renderer.DrawColor = Colors.Black;
            _renderer.Clear();

            _renderer.Target = null;
            _renderer.Copy(_backBuffer);
            _renderer.Present();
        }

        public override void Dispose()
        {
            EnsureInitialized();

            _backBuffer.Dispose();
            _renderer.Dispose();
            _window.Dispose();
        }
    }
}
