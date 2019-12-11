using System;
using SdlSharp;
using SdlSharp.Graphics;

namespace Citadel
{
    /// <summary>
    /// A class that represets an image that is subdivided into regular tile squares.
    /// </summary>
    public sealed class Tileset : IDisposable
    {
        private readonly Surface _surface;

        /// <summary>
        /// The size of an individual tile in pixels.
        /// </summary>
        public Size TileSize { get; }

        /// <summary>
        /// The size of the tileset in tiles.
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// Creates a new tileset.
        /// </summary>
        /// <param name="tileSize">The size of each tile, in pixels.</param>
        /// <param name="image">The byte array to load the tileset from.</param>
        /// <param name="rowMajor">Whether the tileset is row-major or column-major.</param>
        public Tileset(Size tileSize, byte[] image)
        {
            TileSize = tileSize;

            using var fontResource = RWOps.CreateReadOnly(image);
            _surface = Image.LoadPng(fontResource);

            Size = (_surface.Size.Width / TileSize.Width, _surface.Size.Height / TileSize.Height);
        }

        /// <summary>
        /// Creates a texture that can be used with a renderer.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <returns>The tileset texture.</returns>
        public TilesetTexture CreateTexture(Renderer renderer) => new TilesetTexture(this, _surface, renderer);

        /// <summary>
        /// Disposes the tileset.
        /// </summary>
        public void Dispose() => _surface.Dispose();
    }
}
