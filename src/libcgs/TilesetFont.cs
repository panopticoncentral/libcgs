namespace Citadel
{
    public sealed class TilesetFont
    {
        public static readonly TilesetFont Arial8x8 = new TilesetFont(new Tileset((8, 8), Resources.Arial8x8), TilesetMap.Tcod);
        public static readonly TilesetFont Arial10x10 = new TilesetFont(new Tileset((10, 10), Resources.Arial10x10), TilesetMap.Tcod);
        public static readonly TilesetFont Arial12x12 = new TilesetFont(new Tileset((12, 12), Resources.Arial12x12), TilesetMap.Tcod);
        public static readonly TilesetFont Consolas8x8 = new TilesetFont(new Tileset((8, 8), Resources.Consolas8x8), TilesetMap.Tcod);
        public static readonly TilesetFont Consolas10x10 = new TilesetFont(new Tileset((10, 10), Resources.Consolas10x10), TilesetMap.Tcod);
        public static readonly TilesetFont Consolas12x12 = new TilesetFont(new Tileset((12, 12), Resources.Consolas12x12), TilesetMap.Tcod);

        public Tileset Tileset { get; }
        public TilesetMap TilesetMap { get; }

        public TilesetFont(Tileset tileset, TilesetMap tilesetMap)
        {
            Tileset = tileset;
            TilesetMap = tilesetMap;
        }
    }
}
