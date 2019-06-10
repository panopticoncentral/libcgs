using SdlSharp;
using SdlSharp.Graphics;

namespace Citadel
{
    public sealed class Console
    {
        public Console()
        {
            var window = Window.Create((640, 480), WindowFlags.Shown, out var renderer);
            var fontSurface = Image.LoadPng(RWOps.CreateReadOnly(Resources.terminal));
            var fontTexture = renderer.CreateTexture(fontSurface);
            renderer.Copy(fontTexture);
            renderer.Present();
            Timer.Delay(10000);
        }
    }
}
