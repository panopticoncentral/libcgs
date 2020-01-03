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

        internal Texture Texture { get; }

        internal Tileset(Renderer renderer, Size tileSize, Size margin, Size size, string type, byte[] resource, Color? colorKey)
        {
            TileSize = tileSize;
            Margin = margin;
            Size = size;
            _colorKey = colorKey;
            _type = type;
            Texture = Image.Load(RWOps.CreateReadOnly(resource), true, _type, renderer, _colorKey);
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

        /// <inheritdoc/>
        public void Dispose() => Texture.Dispose();
    }
}
