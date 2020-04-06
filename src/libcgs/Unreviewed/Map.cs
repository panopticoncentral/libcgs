using System.Collections.Generic;
using System.Linq;
using SdlSharp;

namespace Citadel
{
    public sealed class Map
    {
        private readonly List<Character> _characters = new List<Character>();
        private readonly Terrain?[] _terrain;

        public Size Size { get; }

        public IReadOnlyList<Character> Characters => _characters;

        public Terrain? this[Point location]
        {
            get => _terrain[location.X + (location.Y * Size.Width)];
            set => _terrain[location.X + (location.Y * Size.Width)] = value;
        }

        public Map(Size size)
        {
            Size = size;
            _terrain = new Terrain[size.Width * size.Height];
        }

        public void AddCharacter(Character entity) => _characters.Add(entity);

        public bool IsBlocked(Point location) => 
            !new Rectangle(Size).Contains(location) 
            || _characters.Any(e => e.Location == location) 
            || _terrain[location.X + (location.Y * Size.Width)]?.IsBlocking == true;
    }
}
