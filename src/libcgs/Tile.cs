using SdlSharp;

namespace Citadel
{
    public struct Tile
    {
        public Tileset Tileset { get; }

        public Point Location { get; }
        
        public Tile(Tileset tileset, Point location)
        {
            Tileset = tileset;
            Location = location;
        }
    }
}
