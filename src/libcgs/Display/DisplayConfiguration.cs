using SdlSharp;

namespace Citadel.Display
{
    public sealed class DisplayConfiguration : Configuration
    {
        public string Title { get; }

        public Size Size { get; }

        public DisplayConfiguration(string title, Size size)
        {
            Title = title;
            Size = size;
        }

        internal override Subsystem Create(SdlConfiguration sdlConfiguration) => new DisplaySubsystem(sdlConfiguration, this);
    }
}
