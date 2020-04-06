using SdlSharp;

namespace Citadel
{
    /// <summary>
    /// A tile in a tileset.
    /// </summary>
    public struct Tile
    {
        /// <summary>
        /// The tileset this tile belongs to.
        /// </summary>
        public Tileset Tileset { get; }

        /// <summary>
        /// The location of the tile in the tileset, in tiles.
        /// </summary>
        public Point Location { get; }
        
        internal Tile(Tileset tileset, Point location)
        {
            Tileset = tileset;
            Location = location;
        }
    }
}
