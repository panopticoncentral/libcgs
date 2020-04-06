namespace Citadel
{
    /// <summary>
    /// A terrain on a map.
    /// </summary>
    public sealed class Terrain
    {
        /// <summary>
        /// The tile that represents the terrain.
        /// </summary>
        public Tile Tile { get; }

        /// <summary>
        /// Whether the terrain blocks character movement.
        /// </summary>
        public bool IsBlocking { get; }

        /// <summary>
        /// Creates a terrain.
        /// </summary>
        /// <param name="tile">The tile that represents the terrain.</param>
        /// <param name="isBlocking">Whether the terrain blocks character movement.</param>
        public Terrain(Tile tile, bool isBlocking)
        {
            Tile = tile;
            IsBlocking = isBlocking;
        }
    }
}
