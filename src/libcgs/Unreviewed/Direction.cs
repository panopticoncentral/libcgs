using SdlSharp;

namespace Citadel
{
    public static class Direction
    {
        public static readonly Point None = (0, 0);
        public static readonly Point Left = (-1, 0);
        public static readonly Point Right = (1, 0);
        public static readonly Point Up = (0, -1);
        public static readonly Point Down = (0, 1);
    }
}
