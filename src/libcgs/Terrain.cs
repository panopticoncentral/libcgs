using SdlSharp;

namespace Citadel
{
    public sealed class Terrain
    {
        public Tile Tile { get; }

        public bool IsBlocking { get; }

        public Terrain(Tile tile, bool isBlocking)
        {
            Tile = tile;
            IsBlocking = isBlocking;
        }
    }
}
