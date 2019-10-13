using SdlSharp.Graphics;

namespace Citadel
{
    public static class Colors
    {
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color DarkestGrey = new Color(31, 31, 31);
        public static readonly Color DarkerGrey = new Color(63, 63, 63);
        public static readonly Color DarkGrey = new Color(95, 95, 95);
        public static readonly Color Grey = new Color(127, 127, 127);
        public static readonly Color LightGrey = new Color(159, 159, 159);
        public static readonly Color LighterGrey = new Color(191, 191, 191);
        public static readonly Color LightestGrey = new Color(223, 223, 223);
        public static readonly Color White = new Color(255, 255, 255);

        public static readonly Color DarkestSepia = new Color(31, 24, 15);
        public static readonly Color DarkerSepia = new Color(63, 50, 31);
        public static readonly Color DarkSepia = new Color(94, 75, 47);
        public static readonly Color Sepia = new Color(127, 101, 63);
        public static readonly Color LightSepia = new Color(158, 134, 100);
        public static readonly Color LighterSepia = new Color(191, 171, 143);
        public static readonly Color LightestSepia = new Color(222, 211, 195);

        /* desaturated */
        public static readonly Color DesaturatedRed = new Color(127, 63, 63);
        public static readonly Color DesaturatedFlame = new Color(127, 79, 63);
        public static readonly Color DesaturatedOrange = new Color(127, 95, 63);
        public static readonly Color DesaturatedAmber = new Color(127, 111, 63);
        public static readonly Color DesaturatedYellow = new Color(127, 127, 63);
        public static readonly Color DesaturatedLime = new Color(111, 127, 63);
        public static readonly Color DesaturatedChartreuse = new Color(95, 127, 63);
        public static readonly Color DesaturatedGreen = new Color(63, 127, 63);
        public static readonly Color DesaturatedSea = new Color(63, 127, 95);
        public static readonly Color DesaturatedTurquoise = new Color(63, 127, 111);
        public static readonly Color DesaturatedCyan = new Color(63, 127, 127);
        public static readonly Color DesaturatedSky = new Color(63, 111, 127);
        public static readonly Color DesaturatedAzure = new Color(63, 95, 127);
        public static readonly Color DesaturatedBlue = new Color(63, 63, 127);
        public static readonly Color DesaturatedHan = new Color(79, 63, 127);
        public static readonly Color DesaturatedViolet = new Color(95, 63, 127);
        public static readonly Color DesaturatedPurple = new Color(111, 63, 127);
        public static readonly Color DesaturatedFuchsia = new Color(127, 63, 127);
        public static readonly Color DesaturatedMagenta = new Color(127, 63, 111);
        public static readonly Color DesaturatedPink = new Color(127, 63, 95);
        public static readonly Color DesaturatedCrimson = new Color(127, 63, 79);

        /* lightest */
        public static readonly Color LightestRed = new Color(255, 191, 191);
        public static readonly Color LightestFlame = new Color(255, 207, 191);
        public static readonly Color LightestOrange = new Color(255, 223, 191);
        public static readonly Color LightestAmber = new Color(255, 239, 191);
        public static readonly Color LightestYellow = new Color(255, 255, 191);
        public static readonly Color LightestLime = new Color(239, 255, 191);
        public static readonly Color LightestChartreuse = new Color(223, 255, 191);
        public static readonly Color LightestGreen = new Color(191, 255, 191);
        public static readonly Color LightestSea = new Color(191, 255, 223);
        public static readonly Color LightestTurquoise = new Color(191, 255, 239);
        public static readonly Color LightestCyan = new Color(191, 255, 255);
        public static readonly Color LightestSky = new Color(191, 239, 255);
        public static readonly Color LightestAzure = new Color(191, 223, 255);
        public static readonly Color LightestBlue = new Color(191, 191, 255);
        public static readonly Color LightestHan = new Color(207, 191, 255);
        public static readonly Color LightestViolet = new Color(223, 191, 255);
        public static readonly Color LightestPurple = new Color(239, 191, 255);
        public static readonly Color LightestFuchsia = new Color(255, 191, 255);
        public static readonly Color LightestMagenta = new Color(255, 191, 239);
        public static readonly Color LightestPink = new Color(255, 191, 223);
        public static readonly Color LightestCrimson = new Color(255, 191, 207);

        /* Lighter */
        public static readonly Color LighterRed = new Color(255, 127, 127);
        public static readonly Color LighterFlame = new Color(255, 159, 127);
        public static readonly Color LighterOrange = new Color(255, 191, 127);
        public static readonly Color LighterAmber = new Color(255, 223, 127);
        public static readonly Color LighterYellow = new Color(255, 255, 127);
        public static readonly Color LighterLime = new Color(223, 255, 127);
        public static readonly Color LighterChartreuse = new Color(191, 255, 127);
        public static readonly Color LighterGreen = new Color(127, 255, 127);
        public static readonly Color LighterSea = new Color(127, 255, 191);
        public static readonly Color LighterTurquoise = new Color(127, 255, 223);
        public static readonly Color LighterCyan = new Color(127, 255, 255);
        public static readonly Color LighterSky = new Color(127, 223, 255);
        public static readonly Color LighterAzure = new Color(127, 191, 255);
        public static readonly Color LighterBlue = new Color(127, 127, 255);
        public static readonly Color LighterHan = new Color(159, 127, 255);
        public static readonly Color LighterViolet = new Color(191, 127, 255);
        public static readonly Color LighterPurple = new Color(223, 127, 255);
        public static readonly Color LighterFuchsia = new Color(255, 127, 255);
        public static readonly Color LighterMagenta = new Color(255, 127, 223);
        public static readonly Color LighterPink = new Color(255, 127, 191);
        public static readonly Color LighterCrimson = new Color(255, 127, 159);

        /* light */
        public static readonly Color LightRed = new Color(255, 63, 63);
        public static readonly Color LightFlame = new Color(255, 111, 63);
        public static readonly Color LightOrange = new Color(255, 159, 63);
        public static readonly Color LightAmber = new Color(255, 207, 63);
        public static readonly Color LightYellow = new Color(255, 255, 63);
        public static readonly Color LightLime = new Color(207, 255, 63);
        public static readonly Color LightChartreuse = new Color(159, 255, 63);
        public static readonly Color LightGreen = new Color(63, 255, 63);
        public static readonly Color LightSea = new Color(63, 255, 159);
        public static readonly Color LightTurquoise = new Color(63, 255, 207);
        public static readonly Color LightCyan = new Color(63, 255, 255);
        public static readonly Color LightSky = new Color(63, 207, 255);
        public static readonly Color LightAzure = new Color(63, 159, 255);
        public static readonly Color LightBlue = new Color(63, 63, 255);
        public static readonly Color LightHan = new Color(111, 63, 255);
        public static readonly Color LightViolet = new Color(159, 63, 255);
        public static readonly Color LightPurple = new Color(207, 63, 255);
        public static readonly Color LightFuchsia = new Color(255, 63, 255);
        public static readonly Color LightMagenta = new Color(255, 63, 207);
        public static readonly Color LightPink = new Color(255, 63, 159);
        public static readonly Color LightCrimson = new Color(255, 63, 111);

        /* normal */
        public static readonly Color Red = new Color(255, 0, 0);
        public static readonly Color Flame = new Color(255, 63, 0);
        public static readonly Color Orange = new Color(255, 127, 0);
        public static readonly Color Amber = new Color(255, 191, 0);
        public static readonly Color Yellow = new Color(255, 255, 0);
        public static readonly Color Lime = new Color(191, 255, 0);
        public static readonly Color Chartreuse = new Color(127, 255, 0);
        public static readonly Color Green = new Color(0, 255, 0);
        public static readonly Color Sea = new Color(0, 255, 127);
        public static readonly Color Turquoise = new Color(0, 255, 191);
        public static readonly Color Cyan = new Color(0, 255, 255);
        public static readonly Color Sky = new Color(0, 191, 255);
        public static readonly Color Azure = new Color(0, 127, 255);
        public static readonly Color Blue = new Color(0, 0, 255);
        public static readonly Color Han = new Color(63, 0, 255);
        public static readonly Color Violet = new Color(127, 0, 255);
        public static readonly Color Purple = new Color(191, 0, 255);
        public static readonly Color Fuchsia = new Color(255, 0, 255);
        public static readonly Color Magenta = new Color(255, 0, 191);
        public static readonly Color Pink = new Color(255, 0, 127);
        public static readonly Color Crimson = new Color(255, 0, 63);

        /* dark */
        public static readonly Color DarkRed = new Color(191, 0, 0);
        public static readonly Color DarkFlame = new Color(191, 47, 0);
        public static readonly Color DarkOrange = new Color(191, 95, 0);
        public static readonly Color DarkAmber = new Color(191, 143, 0);
        public static readonly Color DarkYellow = new Color(191, 191, 0);
        public static readonly Color DarkLime = new Color(143, 191, 0);
        public static readonly Color DarkChartreuse = new Color(95, 191, 0);
        public static readonly Color DarkGreen = new Color(0, 191, 0);
        public static readonly Color DarkSea = new Color(0, 191, 95);
        public static readonly Color DarkTurquoise = new Color(0, 191, 143);
        public static readonly Color DarkCyan = new Color(0, 191, 191);
        public static readonly Color DarkSky = new Color(0, 143, 191);
        public static readonly Color DarkAzure = new Color(0, 95, 191);
        public static readonly Color DarkBlue = new Color(0, 0, 191);
        public static readonly Color DarkHan = new Color(47, 0, 191);
        public static readonly Color DarkViolet = new Color(95, 0, 191);
        public static readonly Color DarkPurple = new Color(143, 0, 191);
        public static readonly Color DarkFuchsia = new Color(191, 0, 191);
        public static readonly Color DarkMagenta = new Color(191, 0, 143);
        public static readonly Color DarkPink = new Color(191, 0, 95);
        public static readonly Color DarkCrimson = new Color(191, 0, 47);

        /* darker */
        public static readonly Color DarkerRed = new Color(127, 0, 0);
        public static readonly Color DarkerFlame = new Color(127, 31, 0);
        public static readonly Color DarkerOrange = new Color(127, 63, 0);
        public static readonly Color DarkerAmber = new Color(127, 95, 0);
        public static readonly Color DarkerYellow = new Color(127, 127, 0);
        public static readonly Color DarkerLime = new Color(95, 127, 0);
        public static readonly Color DarkerChartreuse = new Color(63, 127, 0);
        public static readonly Color DarkerGreen = new Color(0, 127, 0);
        public static readonly Color DarkerSea = new Color(0, 127, 63);
        public static readonly Color DarkerTurquoise = new Color(0, 127, 95);
        public static readonly Color DarkerCyan = new Color(0, 127, 127);
        public static readonly Color DarkerSky = new Color(0, 95, 127);
        public static readonly Color DarkerAzure = new Color(0, 63, 127);
        public static readonly Color DarkerBlue = new Color(0, 0, 127);
        public static readonly Color DarkerHan = new Color(31, 0, 127);
        public static readonly Color DarkerViolet = new Color(63, 0, 127);
        public static readonly Color DarkerPurple = new Color(95, 0, 127);
        public static readonly Color DarkerFuchsia = new Color(127, 0, 127);
        public static readonly Color DarkerMagenta = new Color(127, 0, 95);
        public static readonly Color DarkerPink = new Color(127, 0, 63);
        public static readonly Color DarkerCrimson = new Color(127, 0, 31);

        /* darkest */
        public static readonly Color DarkestRed = new Color(63, 0, 0);
        public static readonly Color DarkestFlame = new Color(63, 15, 0);
        public static readonly Color DarkestOrange = new Color(63, 31, 0);
        public static readonly Color DarkestAmber = new Color(63, 47, 0);
        public static readonly Color DarkestYellow = new Color(63, 63, 0);
        public static readonly Color DarkestLime = new Color(47, 63, 0);
        public static readonly Color DarkestChartreuse = new Color(31, 63, 0);
        public static readonly Color DarkestGreen = new Color(0, 63, 0);
        public static readonly Color DarkestSea = new Color(0, 63, 31);
        public static readonly Color DarkestTurquoise = new Color(0, 63, 47);
        public static readonly Color DarkestCyan = new Color(0, 63, 63);
        public static readonly Color DarkestSky = new Color(0, 47, 63);
        public static readonly Color DarkestAzure = new Color(0, 31, 63);
        public static readonly Color DarkestBlue = new Color(0, 0, 63);
        public static readonly Color DarkestHan = new Color(15, 0, 63);
        public static readonly Color DarkestViolet = new Color(31, 0, 63);
        public static readonly Color DarkestPurple = new Color(47, 0, 63);
        public static readonly Color DarkestFuchsia = new Color(63, 0, 63);
        public static readonly Color DarkestMagenta = new Color(63, 0, 47);
        public static readonly Color DarkestPink = new Color(63, 0, 31);
        public static readonly Color DarkestCrimson = new Color(63, 0, 15);

        /* metallic */
        public static readonly Color Brass = new Color(191, 151, 96);
        public static readonly Color Copper = new Color(197, 136, 124);
        public static readonly Color Gold = new Color(229, 191, 0);
        public static readonly Color Silver = new Color(203, 203, 203);

        /* miscellaneous */
        public static readonly Color Celadon = new Color(172, 255, 175);
        public static readonly Color Peach = new Color(255, 159, 127);

        public static readonly Color[][] Table = new[] {
            new [] {DesaturatedRed,LightestRed,LighterRed,LightRed,Red,DarkRed,DarkerRed,DarkestRed},
            new [] {DesaturatedFlame,LightestFlame,LighterFlame,LightFlame,Flame,DarkFlame,DarkerFlame,DarkestFlame},
            new [] {DesaturatedOrange,LightestOrange,LighterOrange,LightOrange,Orange,DarkOrange,DarkerOrange,DarkestOrange},
            new [] {DesaturatedAmber,LightestAmber,LighterAmber,LightAmber,Amber,DarkAmber,DarkerAmber,DarkestAmber},
            new [] {DesaturatedYellow,LightestYellow,LighterYellow,LightYellow,Yellow,DarkYellow,DarkerYellow,DarkestYellow},
            new [] {DesaturatedLime,LightestLime,LighterLime,LightLime,Lime,DarkLime,DarkerLime,DarkestLime},
            new [] {DesaturatedChartreuse,LightestChartreuse,LighterChartreuse,LightChartreuse,Chartreuse,DarkChartreuse,DarkerChartreuse,DarkestChartreuse},
            new [] {DesaturatedGreen,LightestGreen,LighterGreen,LightGreen,Green,DarkGreen,DarkerGreen,DarkestGreen},
            new [] {DesaturatedSea,LightestSea,LighterSea,LightSea,Sea,DarkSea,DarkerSea,DarkestSea},
            new [] {DesaturatedTurquoise,LightestTurquoise,LighterTurquoise,LightTurquoise,Turquoise,DarkTurquoise,DarkerTurquoise,DarkestTurquoise},
            new [] {DesaturatedCyan,LightestCyan,LighterCyan,LightCyan,Cyan,DarkCyan,DarkerCyan,DarkestCyan},
            new [] {DesaturatedSky,LightestSky,LighterSky,LightSky,Sky,DarkSky,DarkerSky,DarkestSky},
            new [] {DesaturatedAzure,LightestAzure,LighterAzure,LightAzure,Azure,DarkAzure,DarkerAzure,DarkestAzure},
            new [] {DesaturatedBlue,LightestBlue,LighterBlue,LightBlue,Blue,DarkBlue,DarkerBlue,DarkestBlue},
            new [] {DesaturatedHan,LightestHan,LighterHan,LightHan,Han,DarkHan,DarkerHan,DarkestHan},
            new [] {DesaturatedViolet,LightestViolet,LighterViolet,LightViolet,Violet,DarkViolet,DarkerViolet,DarkestViolet},
            new [] {DesaturatedPurple,LightestPurple,LighterPurple,LightPurple,Purple,DarkPurple,DarkerPurple,DarkestPurple},
            new [] {DesaturatedFuchsia,LightestFuchsia,LighterFuchsia,LightFuchsia,Fuchsia,DarkFuchsia,DarkerFuchsia,DarkestFuchsia},
            new [] {DesaturatedMagenta,LightestMagenta,LighterMagenta,LightMagenta,Magenta,DarkMagenta,DarkerMagenta,DarkestMagenta},
            new [] {DesaturatedPink,LightestPink,LighterPink,LightPink,Pink,DarkPink,DarkerPink,DarkestPink},
            new [] {DesaturatedCrimson,LightestCrimson,LighterCrimson,LightCrimson,Crimson,DarkCrimson,DarkerCrimson,DarkestCrimson}
            };
    }
}
