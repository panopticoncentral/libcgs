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
        private readonly Texture _backBuffer;
        private readonly Texture _tileset;

        private (int Glyph, Color? Foreground, Color? Background)[] _buffer;

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
            _backBuffer = _renderer.CreateTexture(Window.PixelFormat, TextureAccess.Target, Size * _font.Tileset.TileSize);

            RecalculateWindowSize();
            Window.SetVisible(true);

            _tileset = _font.Tileset.CreateTexture(_renderer);

            _buffer = new (int, Color?, Color?)[size.Width * size.Height];
        }

        private void RecalculateWindowSize()
        {
            var scale = Window.Display.Dpi.Horizontal / 96;
            Window.Size = _backBuffer.Size * scale;
        }

        public void Set(Point location, char c, Color? foreground = default, Color? background = default)
        {
            var index = _font.TilesetMap.MapToTileset(c);

            if (index == -1)
            {
                throw new InvalidOperationException();
            }

            _buffer[location.X + (location.Y * Size.Width)] = (index, foreground, background);
        }

        //public void Write(string s, Point location, bool wordWrap = false)
        //{
        //    foreach (var c in s)
        //    {
        //        Set(c, location);

        //        var newX = location.X + 1;
        //        var newY = location.Y;

        //        if (newX == _renderer.LogicalSize.Width)
        //        {
        //            newX = 0;

        //            if (!wordWrap)
        //            {
        //                return;
        //            }

        //            newY++;

        //            if (newY == _renderer.LogicalSize.Height)
        //            {
        //                return;
        //            }
        //        }

        //        location = (newX, newY);
        //    }
        //}

        public void Render()
        {
            _renderer.Target = _backBuffer;
            _renderer.DrawColor = Colors.Black;
            _renderer.Clear();

            for (var x = 0; x < Size.Width; x++)
            {
                for (var y = 0; y < Size.Height; y++)
                {
                    var (glyph, foreground, background) = _buffer[x + (y * Size.Width)];

                    if (glyph >= _tileset.Size.Height * _tileset.Size.Width)
                    {
                        throw new InvalidOperationException();
                    }

                    Rectangle fontClip = ((glyph % _font.Tileset.Size.Width * _font.Tileset.TileSize.Width, glyph / _tileset.Size.Width * _font.Tileset.TileSize.Height), _font.Tileset.TileSize);
                    // ((tile / _tileset.Size.Height * _tileset.TileSize.Width, tile % _tileset.Size.Height * _tileset.TileSize.Height), _tileset.TileSize);
                    Rectangle consoleClip = ((x * _font.Tileset.TileSize.Width, y * _font.Tileset.TileSize.Height), _font.Tileset.TileSize);

                    _renderer.Copy(_tileset, fontClip, consoleClip);
                }
            }

            _renderer.Target = null;
            _renderer.Copy(_backBuffer);
            _renderer.Present();
        }

        public void Clear() => _buffer = new (int, Color?, Color?)[Size.Width * Size.Height];

        public void Dispose()
        {
            _backBuffer.Dispose();
            _tileset.Dispose();
            _renderer?.Dispose();
            Window?.Dispose();
        }
    }
}
