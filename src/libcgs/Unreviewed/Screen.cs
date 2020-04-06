using SdlSharp;
using SdlSharp.Graphics;
using System;
using System.Collections.Generic;

namespace Citadel
{
    /// <summary>
    /// The game window.
    /// </summary>
    public sealed class Screen : IDisposable
    {
        private readonly List<Tileset> _tilesets;

        private readonly Window _window;
        private readonly Renderer _renderer;
        private readonly Texture _backBuffer;

        //private readonly Map _map;
        //private readonly Size _tileSize;

        /// <summary>
        /// The size of the screen.
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// Creates a game window.
        /// </summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="size">The size of the window, in pixels.</param>
        public Screen(string title, Size size/*, Map map, Size tileSize*/)
        {
            Size = size;

            _tilesets = new List<Tileset>();

            _window = Window.Create(title, (Window.UndefinedWindowLocation, (0, 0)), WindowFlags.Hidden);

            _renderer = Renderer.Create(_window, -1, RendererFlags.Accelerated | RendererFlags.PresentVSync | RendererFlags.TargetTexture);
            _backBuffer = _renderer.CreateTexture(_window.PixelFormat, TextureAccess.Target, Size);
            _backBuffer.BlendMode = BlendMode.Blend;

            RecalculateWindowSize();
            _window.SetVisible(true);

            //_map = map;
            //_tileSize = tileSize;
        }

        private void RecalculateWindowSize()
        {
            var scale = _window.Display.Dpi.Horizontal / 96;
            _window.Size = _backBuffer.Size * scale;
        }

        /// <summary>
        /// Creates a new tileset.
        /// </summary>
        /// <param name="margin">The size of the right/bottom margin, in pixels.</param>
        /// <param name="tileSize">The size of the tiles, in pixels.</param>
        /// <param name="size">The size of the set, in tiles.</param>
        /// <param name="type">The type of the image.</param>
        /// <param name="resource">The tileset resource.</param>
        /// <param name="colorKey">The color key, if any.</param>
        public Tileset LoadTileset(Size margin, Size tileSize, Size size, string type, byte[] resource, Color? colorKey = default)
        {
            var tileset = new Tileset(_renderer, tileSize, margin, size, type, resource, colorKey);
            _tilesets.Add(tileset);
            return tileset;
        }

        /// <summary>
        /// Renders the game window.
        /// </summary>
        public void Render()
        {
            _renderer.Target = _backBuffer;
            _renderer.DrawColor = Colors.Black;
            _renderer.Clear();

            //for (var x = 0; x < _map.Size.Width; x++)
            //{
            //    for (var y = 0; y < _map.Size.Height; y++)
            //    {
            //        var location = new Point(x, y);
            //        var terrain = _map[location];

            //        if (terrain == null)
            //        {
            //            continue;
            //        }

            //        var tileset = terrain.Tile.Tileset;
            //        _renderer.Copy(tileset.Texture, tileset.MapSource(terrain.Tile.Location), tileset.MapDestination(location));
            //    }
            //}

            //foreach (var character in _map.Characters)
            //{
            //    var tileset = character.Tile.Tileset;
            //    _renderer.Copy(tileset.Texture, tileset.MapSource(character.Tile.Location), tileset.MapDestination(character.Location));
            //}

            _renderer.Target = null;
            _renderer.Copy(_backBuffer);
            _renderer.Present();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _backBuffer.Dispose();
            foreach (var tileset in _tilesets)
            {
                tileset.Dispose();
            }
            _renderer?.Dispose();
            _window?.Dispose();
        }
    }
}
