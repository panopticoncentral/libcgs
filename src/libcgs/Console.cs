using SdlSharp;
using SdlSharp.Graphics;
using System;

namespace Citadel
{
    /// <summary>
    /// A console window.
    /// </summary>
    public sealed class Console : IDisposable
    {
        private readonly TilesetFont _font;

        private readonly Renderer _renderer;
        private readonly Texture _texture;
        private readonly TilesetTexture _tilesetTexture;

        private int[] _buffer;

        /// <summary>
        /// The console's SDL window.
        /// </summary>
        public Window Window { get; }

        /// <summary>
        /// The size of the console, in characters.
        /// </summary>
        public Size Size { get; }

        public Console(string title, Size size, TilesetFont? font = null)
        {
            Size = size;

            _font = font ?? TilesetFont.Arial8x8;

            Window = Window.Create(title, (Window.UndefinedWindowLocation, (0, 0)), WindowFlags.Hidden);

            _renderer = Renderer.Create(Window, -1, RendererFlags.Accelerated | RendererFlags.PresentVSync | RendererFlags.TargetTexture);
            _texture = _renderer.CreateTexture(Window.PixelFormat, TextureAccess.Target, (Size.Width * _font.Tileset.TileSize.Width, Size.Height * _font.Tileset.TileSize.Height));

            RecalculateWindowSize();
            Window.SetVisible(true);

            _tilesetTexture = _font.Tileset.CreateTexture(_renderer);

            _buffer = new int[size.Width * size.Height];
        }

        private void RecalculateWindowSize()
        {
            var scale = Window.Display.Dpi.Horizontal / 96;
            Window.Size = _texture.Size * scale;
        }

        public void Write(char c, Point location)
        {
            var index = _font.TilesetMap.MapToTileset(c);

            if (index == -1)
            {
                throw new InvalidOperationException();
            }

            _buffer[location.X + (location.Y * Size.Width)] = index;
        }

        public void Write(string s, Point location, bool wordWrap = false)
        {
            foreach (var c in s)
            {
                Write(c, location);

                var newX = location.X + 1;
                var newY = location.Y;

                if (newX == _renderer.LogicalSize.Width)
                {
                    newX = 0;

                    if (!wordWrap)
                    {
                        return;
                    }

                    newY++;

                    if (newY == _renderer.LogicalSize.Height)
                    {
                        return;
                    }
                }

                location = (newX, newY);
            }
        }

        public void Render()
        {
            _renderer.Target = _texture;
            _renderer.DrawColor = (0xFF, 0xFF, 0xFF, 0xFF);
            _renderer.Clear();

            for (var x = 0; x < Size.Width; x++)
            {
                for (var y = 0; y < Size.Height; y++)
                {
                    _tilesetTexture.DrawTile(_buffer[x + (y * Size.Width)], (x, y));
                }
            }

            _renderer.Target = null;
            _renderer.Copy(_texture);
            _renderer.Present();
        }

        public void Clear()
        {
            _buffer = new int[Size.Width * Size.Height];
        }

        public void Dispose()
        {
            _texture.Dispose();
            _tilesetTexture.Dispose();
            _renderer?.Dispose();
            Window?.Dispose();
        }
    }
}
