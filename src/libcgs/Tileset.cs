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
        private readonly Color? _colorKey;

        /// <summary>
        /// The size of an individual tile in pixels.
        /// </summary>
        public Size TileSize { get; }

        /// <summary>
        /// The size of the right/bottom margin in pixels.
        /// </summary>
        public Size Margin { get; }

        /// <summary>
        /// The size of the tileset in tiles.
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// Creates a new tileset.
        /// </summary>
        /// <param name="tileSize">The size of each tile, in pixels.</param>
        /// <param name="margin">The size of the right/bottom margin, in pixels.</param>
        /// <param name="size">The size of the set, in tiles.</param>
        /// <param name="type">The type of the image.</param>
        /// <param name="colorKey">The color key, if any.</param>
        /// <param name="accessor">An accessor for the byte array to load the tileset from.</param>
        public Tileset(Size tileSize, Size margin, Size size, string type, Color? colorKey, Func<byte[]> accessor)
        {
            TileSize = tileSize;
            Margin = margin;
            Size = size;
            _colorKey = colorKey;
            _accessor = accessor;
            _type = type;
        }

        /// <summary>
        /// Maps from a tile to a rectangle on the tileset.
        /// </summary>
        /// <param name="tile">The location of the tile, in tiles.</param>
        /// <returns>The rectangle, in pixels, where the tile is located.</returns>
        public Rectangle MapSource(Point tile) => ((tile.X * (TileSize.Width + Margin.Width), tile.Y * (TileSize.Height + Margin.Height)), TileSize);

        /// <summary>
        /// Maps from a location to a destination rectangle.
        /// </summary>
        /// <param name="location">The location, in tiles.</param>
        /// <returns>The rectangle, in pixels, where the tile should be rendered.</returns>
        public Rectangle MapDestination(Point location) => ((location.X * TileSize.Width, location.Y * TileSize.Height), TileSize);

        /// <summary>
        /// Creates a texture that can be used with a renderer.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="colorKey">The color key, if any.</param>
        /// <returns>The tileset texture.</returns>
        public Texture CreateTexture(Renderer renderer) =>
            Image.Load(RWOps.CreateReadOnly(_accessor()), true, _type, renderer, _colorKey);
    }
}
