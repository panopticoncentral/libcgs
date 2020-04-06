namespace Citadel
{
    /// <summary>
    /// A configuration for a subsystem.
    /// </summary>
    public abstract class Configuration
    {
        internal abstract Subsystem Create(SdlConfiguration sdlConfiguration);
    }
}
