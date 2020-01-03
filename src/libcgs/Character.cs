using SdlSharp;

namespace Citadel
{
    public sealed class Character
    {
        public Point Location { get; private set; }

        public Tile Tile { get; }

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
