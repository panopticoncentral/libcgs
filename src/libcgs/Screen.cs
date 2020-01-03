using SdlSharp;
using SdlSharp.Graphics;
using System;
using System.Collections.Generic;

namespace Citadel
{
    /// <summary>
    /// A game window.
    /// </summary>
    public sealed class Screen : IDisposable
    {
        private readonly List<Tileset> _tilesets;

        private readonly Renderer _renderer;
        private readonly Texture _backBuffer;

        private readonly Map _map;
        private readonly Size _tileSize;

        /// <summary>
        /// The console's SDL window.
        /// </summary>
        public Window Window { get; }

        /// <summary>
        /// The size of the console, in tiles.
        /// </summary>
        public Size Size { get; }

        public Screen(string title, Size size, Map map, Size tileSize)
        {
            Size = size;

            _tilesets = new List<Tileset>();

            Window = Window.Create(title, (Window.UndefinedWindowLocation, (0, 0)), WindowFlags.Hidden);

            _renderer = Renderer.Create(Window, -1, RendererFlags.Accelerated | RendererFlags.PresentVSync | RendererFlags.TargetTexture);
            _backBuffer = _renderer.CreateTexture(Window.PixelFormat, TextureAccess.Target, Size);
            _backBuffer.BlendMode = BlendMode.Blend;

            RecalculateWindowSize();
            Window.SetVisible(true);

            _map = map;
            _tileSize = tileSize;
        }

        private void RecalculateWindowSize()
        {
            var scale = Window.Display.Dpi.Horizontal / 96;
            Window.Size = _backBuffer.Size * scale;
        }

        /// <summary>
        /// Creates a new tileset.
        /// </summary>
        /// <param name="margin">The size of the right/bottom margin, in pixels.</param>
        /// <param name="size">The size of the set, in tiles.</param>
        /// <param name="type">The type of the image.</param>
        /// <param name="resource">The tileset resource.</param>
        /// <param name="colorKey">The color key, if any.</param>
        public Tileset LoadTileset(Size margin, Size size, string type, byte[] resource, Color? colorKey = default)
        {
            var tileset = new Tileset(_renderer, _tileSize, margin, size, type, resource, colorKey);
            _tilesets.Add(tileset);
            return tileset;
        }

        public void Render()
        {
            _renderer.Target = _backBuffer;
            _renderer.DrawColor = Colors.Black;
            _renderer.Clear();

            for (var x = 0; x < _map.Size.Width; x++)
            {
                for (var y = 0; y < _map.Size.Height; y++)
                {
                    var location = new Point(x, y);
                    var terrain = _map[location];

                    if (terrain == null)
                    {
                        continue;
                    }

                    var tileset = terrain.Tile.Tileset;
                    _renderer.Copy(tileset.Texture, tileset.MapSource(terrain.Tile.Location), tileset.MapDestination(location));
                }
            }

            foreach (var character in _map.Characters)
            {
                var tileset = character.Tile.Tileset;
                _renderer.Copy(tileset.Texture, tileset.MapSource(character.Tile.Location), tileset.MapDestination(character.Location));
            }

            _renderer.Target = null;
            _renderer.Copy(_backBuffer);
            _renderer.Present();
        }

        public void Dispose()
        {
            _backBuffer.Dispose();
            foreach (var tileset in _tilesets)
            {
                tileset.Dispose();
            }
            _renderer?.Dispose();
            Window?.Dispose();
        }
    }
}
