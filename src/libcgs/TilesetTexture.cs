using System;
using SdlSharp;
using SdlSharp.Graphics;

namespace Citadel
{
    /// <summary>
    /// A texture that represents a tileset.
    /// </summary>
    public sealed class TilesetTexture : IDisposable
    {
        private readonly Tileset _tileset;
        private readonly Renderer _renderer;
        private readonly Texture _texture;

        internal TilesetTexture(Tileset tileset, Surface surface, Renderer renderer)
        {
            _renderer = renderer;
            _tileset = tileset;
            _texture = _renderer.CreateTexture(surface);
        }

        /// <summary>
        /// Draws the specified tile at the specific location on the renderer that was used to create the texture.
        /// </summary>
        /// <param name="tile">The tile index.</param>
        /// <param name="location">The location to draw.</param>
        public void DrawTile(int tile, Point location)
        {
            if (tile >= _tileset.Size.Height * _tileset.Size.Width)
            {
                throw new InvalidOperationException();
            }

            Rectangle fontClip = ((tile % _tileset.Size.Width * _tileset.TileSize.Width, tile / _tileset.Size.Width * _tileset.TileSize.Height), _tileset.TileSize);
            // ((tile / _tileset.Size.Height * _tileset.TileSize.Width, tile % _tileset.Size.Height * _tileset.TileSize.Height), _tileset.TileSize);
            Rectangle consoleClip = ((location.X * _tileset.TileSize.Width, location.Y * _tileset.TileSize.Height), _tileset.TileSize);
            _renderer.Copy(_texture, fontClip, consoleClip);
        }

        /// <summary>
        /// Disposes the texture.
        /// </summary>
        public void Dispose()
        {
            _texture.Dispose();
        }
    }
}
