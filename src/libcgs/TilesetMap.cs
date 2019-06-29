namespace Citadel
{
    /// <summary>
    /// A map for a tileset.
    /// </summary>
    public abstract class TilesetMap
    {
        /// <summary>
        /// A map for the libtcod tileset layout.
        /// </summary>
        public static readonly TilesetMap Tcod = new TcodCharacterMap();

        /// <summary>
        /// A radio button glyph.
        /// </summary>
        public virtual int RadioButton => -1;

        /// <summary>
        /// A selected radio button glyph.
        /// </summary>
        public virtual int RadioButtonSelected => -1;

        /// <summary>
        /// A checkbox glyph.
        /// </summary>
        public virtual int CheckBox => -1;

        /// <summary>
        /// A checked checkbox glyph.
        /// </summary>
        public virtual int CheckBoxCheck => -1;

        /// <summary>
        /// A sub-pixel with the northwest quadrant filled in.
        /// </summary>
        public virtual int NorthwestSubpixel => -1;

        /// <summary>
        /// A sub-pixel with the northeast quadrant filled in.
        /// </summary>
        public virtual int NortheastSubpixel => -1;

        /// <summary>
        /// A sub-pixel with the north half filled in.
        /// </summary>
        public virtual int NorthSubpixel => -1;

        /// <summary>
        /// A sub-pixel with the southeast quadrant filled in.
        /// </summary>
        public virtual int SoutheastSubpixel => -1;

        /// <summary>
        /// A sub-pixel with diagonal quadrants filled in.
        /// </summary>
        public virtual int DiagonalSubpixel => -1;

        /// <summary>
        /// A sub-pixel with the east half filled in.
        /// </summary>
        public virtual int EastSubpixel => -1;

        /// <summary>
        /// A sub-pixel with the southwest quadrant filled in.
        /// </summary>
        public virtual int SouthwestSubpixel => -1;

        /// <summary>
        /// Map a character to the tileset index.
        /// </summary>
        /// <param name="c">The character.</param>
        /// <returns>The tileset index or <c>-1</c> if the tileset does not support the character.</returns>
        public abstract int MapToTileset(char c);

        private sealed class TcodCharacterMap : TilesetMap
        {
            public override int CheckBox => 0x4A;
            public override int CheckBoxCheck => 0x4B;
            public override int RadioButton => 0x4C;
            public override int RadioButtonSelected => 0x4D;
            public override int NorthwestSubpixel => 0x39;
            public override int NortheastSubpixel => 0x3A;
            public override int NorthSubpixel => 0x3B;
            public override int SoutheastSubpixel => 0x3C;
            public override int DiagonalSubpixel => 0x3D;
            public override int EastSubpixel => 0x3E;
            public override int SouthwestSubpixel => 0x3F;

            public override int MapToTileset(char c)
            {
                switch (c)
                {
                    case ' ':
                    case '!':
                    case '"':
                    case '#':
                    case '$':
                    case '%':
                    case '&':
                    case '\'':
                    case '(':
                    case ')':
                    case '*':
                    case '+':
                    case ',':
                    case '-':
                    case '.':
                    case '/':
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case ':':
                    case ';':
                    case '<':
                    case '=':
                    case '>':
                    case '?':
                    case '@':
                        return c - ' '; // 0x00 - 0x20

                    case '[':
                    case '\\':
                    case ']':
                    case '^':
                    case '_':
                    case '`':
                        return c - '[' + 0x21; // 0x21 - 0x26

                    case '{':
                    case '|':
                    case '}':
                    case '~':
                        return c - '{' + 0x27; // 0x27 - 0x2A

                    case Characters.LightShade:
                    case Characters.MediumShade:
                    case Characters.DarkShade:
                        return c - Characters.LightShade + 0x2B; // 0x2B - 0x2D

                    case Characters.BoxDrawingsLightVertical:
                        return 0x2E;

                    case Characters.BoxDrawingsLightHorizontal:
                        return 0x2F;

                    case Characters.BoxDrawingsLightVerticalAndHorizontal:
                        return 0x30;

                    case Characters.BoxDrawingsLightVerticalAndLeft:
                        return 0x31;

                    case Characters.BoxDrawingsLightUpAndHorizontal:
                        return 0x32;

                    case Characters.BoxDrawingsLightVerticalAndRight:
                        return 0x33;

                    case Characters.BoxDrawingsLightDownAndHorizontal:
                        return 0x34;

                    case Characters.BoxDrawingsLightUpAndRight:
                        return 0x35;

                    case Characters.BoxDrawingsLightDownAndRight:
                        return 0x36;

                    case Characters.BoxDrawingsLightDownAndLeft:
                        return 0x37;

                    case Characters.BoxDrawingsLightUpAndLeft:
                        return 0x38;

                    case Characters.UpwardsArrow:
                        return 0x40;

                    case Characters.DownwardsArrow:
                        return 0x41;

                    case Characters.LeftwardsArrow:
                        return 0x42;

                    case Characters.RightwardsArrow:
                        return 0x43;

                    case Characters.BlackUpPointingTriangle:
                        return 0x44;

                    case Characters.BlackDownPointingTriangle:
                        return 0x45;

                    case Characters.BlackLeftPointingPointer:
                        return 0x46;

                    case Characters.BlackRightPointingPointer:
                        return 0x47;

                    case Characters.UpDownArrow:
                        return 0x48;

                    case Characters.LeftRightArrow:
                        return 0x49;

                    case Characters.BoxDrawingsDoubleVertical:
                        return 0x4E;

                    case Characters.BoxDrawingsDoubleHorizontal:
                        return 0x4F;

                    case Characters.BoxDrawingsDoubleVerticalAndHorizontal:
                        return 0x50;

                    case Characters.BoxDrawingsDoubleVerticalAndLeft:
                        return 0x51;

                    case Characters.BoxDrawingsDoubleUpAndHorizontal:
                        return 0x52;

                    case Characters.BoxDrawingsDoubleVerticalAndRight:
                        return 0x53;

                    case Characters.BoxDrawingsDoubleDownAndHorizontal:
                        return 0x54;

                    case Characters.BoxDrawingsDoubleUpAndRight:
                        return 0x55;

                    case Characters.BoxDrawingsDoubleDownAndRight:
                        return 0x56;

                    case Characters.BoxDrawingsDoubleDownAndLeft:
                        return 0x57;

                    case Characters.BoxDrawingsDoubleUpAndLeft:
                        return 0x58;

                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'F':
                    case 'G':
                    case 'H':
                    case 'I':
                    case 'J':
                    case 'K':
                    case 'L':
                    case 'M':
                    case 'N':
                    case 'O':
                    case 'P':
                    case 'Q':
                    case 'R':
                    case 'S':
                    case 'T':
                    case 'U':
                    case 'V':
                    case 'W':
                    case 'X':
                    case 'Y':
                    case 'Z':
                        return c - 'A' + 0x60; // 0x60 - 0x79

                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        return c - 'a' + 0x80; // 0x80 - 0x99

                    default:
                        return -1;
                }
            }
        }
    }
}
