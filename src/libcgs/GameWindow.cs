using SdlSharp;
using SdlSharp.Graphics;
using System;

namespace Citadel
{
    /// <summary>
    /// A game window.
    /// </summary>
    public sealed class GameWindow : IDisposable
    {
        private readonly Tileset _tileset;

        private readonly Renderer _renderer;
        private readonly Texture _backBuffer;
        private readonly Texture _tilesetTexture;

        private Point?[] _buffer;

        /// <summary>
        /// The console's SDL window.
        /// </summary>
        public Window Window { get; }

        /// <summary>
        /// The size of the console, in tiles.
        /// </summary>
        public Size Size { get; }

        public GameWindow(string title, Size size, Tileset tileset)
        {
            Size = size;

            _tileset = tileset;

            Window = Window.Create(title, (Window.UndefinedWindowLocation, (0, 0)), WindowFlags.Hidden);

            _renderer = Renderer.Create(Window, -1, RendererFlags.Accelerated | RendererFlags.PresentVSync | RendererFlags.TargetTexture);
            _backBuffer = _renderer.CreateTexture(Window.PixelFormat, TextureAccess.Target, Size * _tileset.TileSize);
            _backBuffer.BlendMode = BlendMode.Blend;

            RecalculateWindowSize();
            Window.SetVisible(true);

            _tilesetTexture = _tileset.CreateTexture(_renderer);

            _buffer = new Point?[size.Width * size.Height];
        }

        private void RecalculateWindowSize()
        {
            var scale = Window.Display.Dpi.Horizontal / 96;
            Window.Size = _backBuffer.Size * scale;
        }

        public void Set(Point location, Point? tile) => _buffer[location.X + (location.Y * Size.Width)] = tile;

        public void Render()
        {
            _renderer.Target = _backBuffer;
            _renderer.DrawColor = Colors.Black;
            _renderer.Clear();

            for (var x = 0; x < Size.Width; x++)
            {
                for (var y = 0; y < Size.Height; y++)
                {
                    var tile = _buffer[x + (y * Size.Width)];

                    if (tile == null)
                    {
                        continue;
                    }

                    _renderer.Copy(_tilesetTexture, _tileset.MapSource(tile.Value), _tileset.MapDestination((x, y)));
                }
            }

            _renderer.Target = null;
            _renderer.Copy(_backBuffer);
            _renderer.Present();
        }

        public void Clear() => _buffer = new Point?[Size.Width * Size.Height];

        public void Dispose()
        {
            _backBuffer.Dispose();
            _tilesetTexture.Dispose();
            _renderer?.Dispose();
            Window?.Dispose();
        }
    }
}
