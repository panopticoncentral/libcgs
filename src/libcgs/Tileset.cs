using SdlSharp;
using SdlSharp.Graphics;

namespace Citadel
{
    public sealed class Tileset
    {
        public Size TileSize { get; }

        public Surface TilesetImage { get; }

        public Size TilesetSize { get; }

        public Tileset(Size tileSize, byte[] image)
        {
            TileSize = tileSize;

            using var fontResource = RWOps.CreateReadOnly(image);
            TilesetImage = Image.LoadPng(fontResource);

            TilesetSize = (TilesetImage.Size.Width / TileSize.Width, TilesetImage.Size.Height / TileSize.Height);
        }
    }
}
