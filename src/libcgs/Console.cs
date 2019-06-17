using SdlSharp;
using SdlSharp.Graphics;
using System;

namespace Citadel
{
    public sealed class Console : IDisposable
    {
        private static readonly Size s_characterSize = (8, 8);

        private readonly Size _consoleSize;
        private readonly Renderer _renderer;
        private readonly Texture _font;
        private readonly Size _fontTextureSize;

        public Window Window { get; }

        public Size Size { get; }

        public Console(Size size)
        {
            _consoleSize = size;
            Window = Window.Create((size.Width * s_characterSize.Width, size.Height * s_characterSize.Height), WindowFlags.Shown, out var renderer);

            using var fontResource = RWOps.CreateReadOnly(Resources.terminal);
            var fontSurface = Image.LoadPng(fontResource);

            _renderer = renderer;
            _font = _renderer.CreateTexture(fontSurface);
            _fontTextureSize = (_font.Size.Width / s_characterSize.Width, _font.Size.Height / s_characterSize.Height);
        }

        private void DrawCharacter(char c, Point location)
        {
            if (c >= _fontTextureSize.Height * _fontTextureSize.Width)
            {
                throw new InvalidOperationException();
            }

            Rectangle fontClip = ((c / _fontTextureSize.Height * s_characterSize.Width, c % _fontTextureSize.Height * s_characterSize.Height), s_characterSize);
            Rectangle consoleClip = ((location.X * s_characterSize.Width, location.Y * s_characterSize.Height), s_characterSize);
            _renderer.Copy(_font, fontClip, consoleClip);
        }

        private void DrawString(string s, Point location)
        {
            foreach (var c in s)
            {
                DrawCharacter(c, location);

                var newX = location.X + 1;
                var newY = location.Y;

                if (newX == _consoleSize.Width)
                {
                    newX = 0;
                    newY++;

                    if (newY == _consoleSize.Height)
                    {
                        return;
                    }
                }

                location = (newX, newY);
            }
        }

        public void Render()
        {
            DrawString("The quick brown fox jumped over the lazy dog.", (0, 0));
            _renderer.Present();
        }

        public void Dispose()
        {
            _font?.Dispose();
            _renderer?.Dispose();
            Window?.Dispose();
        }
    }
}
