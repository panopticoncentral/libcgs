using SdlSharp;

namespace Citadel
{
    /// <summary>
    /// A character in the game.
    /// </summary>
    public sealed class Character
    {
        /// <summary>
        /// The location of the character.
        /// </summary>
        public Point Location { get; private set; }

        /// <summary>
        /// The tile that represents the character.
        /// </summary>
        public Tile Tile { get; }

        /// <summary>
        /// Creates a new character.
        /// </summary>
        /// <param name="location">Their starting location.</param>
        /// <param name="tile">The tile that represents the character.</param>
        public Character(Point location, Tile tile)
        {
            Location = location;
            Tile = tile;
        }

        public void Move(Map map, Point direction)
        {
            var newLocation = Location + direction;
            if (Location != newLocation && !map.IsBlocked(newLocation))
            {
                Location = newLocation;
            }
        }
    }
}
