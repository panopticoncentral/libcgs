using SdlSharp;
using SdlSharp.Graphics;

namespace Citadel
{
    internal sealed class SdlConfiguration
    {
        public Subsystems Subsystems { get; private set; }

        public ImageFormats ImageFormats { get; private set; }

        public void RequireSdlSubsystems(Subsystems subsystems) => Subsystems |= subsystems;

        public void RequireSdlImageFormats(ImageFormats imageFormats) => ImageFormats |= imageFormats;
    }
}
