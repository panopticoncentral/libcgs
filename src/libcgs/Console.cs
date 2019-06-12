using SdlSharp;
using SdlSharp.Graphics;
using System;

namespace Citadel
{
    public sealed class Console : IDisposable
    {
        private static readonly Size CharacterSize = (8, 8);

        private readonly Size _consoleSize;
        private readonly Renderer _renderer;
        private readonly Texture _font;
        private readonly Size _fontTextureSize;

        public Window Window { get; }

        public Size Size { get; }

        public Console(Size size)
        {
            _consoleSize = size;
            Window = Window.Create((size.Width * CharacterSize.Width, size.Height * CharacterSize.Height), WindowFlags.Shown, out var renderer);

            using var fontResource = RWOps.CreateReadOnly(Resources.terminal);
            var fontSurface = Image.LoadPng(fontResource);

            _renderer = renderer;
            _font = _renderer.CreateTexture(fontSurface);
            _fontTextureSize = (_font.Size.Width / CharacterSize.Width, _font.Size.Height / CharacterSize.Height);
        }

        private void DrawCharacter(char c, Point location)
        {
            if (c >= _fontTextureSize.Height * _fontTextureSize.Width)
            {
                throw new InvalidOperationException();
            }

            Rectangle fontClip = (((c / _fontTextureSize.Height) * CharacterSize.Width, (c % _fontTextureSize.Height) * CharacterSize.Height), CharacterSize);
            Rectangle consoleClip = ((location.X * CharacterSize.Width, location.Y * CharacterSize.Height), CharacterSize);
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
