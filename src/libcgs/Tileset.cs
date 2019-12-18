using System;
using SdlSharp;
using SdlSharp.Graphics;

namespace Citadel
{
    /// <summary>
    /// A class that represets an image that is subdivided into regular tile squares.
    /// </summary>
    public sealed class Tileset
    {
        private readonly Func<byte[]> _accessor;
        private readonly string _type;

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
        /// <param name="size">The size of the set, in tiles.</param>
        /// <param name="accessor">An accessor for the byte array to load the tileset from.</param>
        public Tileset(Size tileSize, Size size, string type, Func<byte[]> accessor)
        {
            TileSize = tileSize;
            Size = size;
            _accessor = accessor;
            _type = type;
        }

        /// <summary>
        /// Creates a texture that can be used with a renderer.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="colorKey">The color key, if any.</param>
        /// <returns>The tileset texture.</returns>
        public Texture CreateTexture(Renderer renderer, Color? colorKey = default) =>
            Image.Load(RWOps.CreateReadOnly(_accessor()), true, _type, renderer, colorKey);
    }
}
