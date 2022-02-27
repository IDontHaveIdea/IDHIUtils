using System;

using UnityEngine;

using KKAPI.Utilities;


namespace IDHIUtils
{
    /// <summary>
    /// Scalable Vector Graphics Color Names
    /// 
    /// https://www.december.com/html/spec/Colorsvg.html
    /// </summary>
    public class SvgColor
    {
        static private Texture2D _lut;

        internal bool _useLut = false;
        internal byte _alpha = 255;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0025 // Use block body for properties

        public Color black =>                Lut(new Color32(  0,   0,   0, _alpha));
        public Color navy =>                 Lut(new Color32(  0,   0, 128, _alpha));
        public Color darkblue =>             Lut(new Color32(  0,   0, 139, _alpha));
        public Color mediumblue =>           Lut(new Color32(  0,   0, 205, _alpha));
        public Color blue =>                 Lut(new Color32(  0,   0, 255, _alpha));
        public Color darkgreen =>            Lut(new Color32(  0, 100,   0, _alpha));
        public Color green =>                Lut(new Color32(  0, 128,   0, _alpha));
        public Color teal =>                 Lut(new Color32(  0, 128, 128, _alpha));
        public Color darkcyan =>             Lut(new Color32(  0, 139, 139, _alpha));
        public Color deepskyblue =>          Lut(new Color32(  0, 191, 255, _alpha));
        public Color darkturquoise =>        Lut(new Color32(  0, 206, 209, _alpha));
        public Color mediumspringgreen =>    Lut(new Color32(  0, 250, 154, _alpha));
        public Color lime =>                 Lut(new Color32(  0, 255,   0, _alpha));
        public Color springgreen =>          Lut(new Color32(  0, 255, 127, _alpha));
        public Color aqua =>                 Lut(new Color32(  0, 255, 255, _alpha));
        public Color cyan =>                 Lut(new Color32(  0, 255, 255, _alpha));
        public Color midnightblue =>         Lut(new Color32( 25,  25, 112, _alpha));
        public Color dodgerblue =>           Lut(new Color32( 30, 144, 255, _alpha));
        public Color lightseagreen =>        Lut(new Color32( 32, 178, 170, _alpha));
        public Color forestgreen =>          Lut(new Color32( 34, 139,  34, _alpha));
        public Color seagreen =>             Lut(new Color32( 46, 139,  87, _alpha));
        public Color darkslategrey =>        Lut(new Color32( 47,  79,  79, _alpha));
        public Color darkslategray =>        Lut(new Color32( 47,  79,  79, _alpha));
        public Color limegreen =>            Lut(new Color32( 50, 205,  50, _alpha));
        public Color mediumseagreen =>       Lut(new Color32( 60, 179, 113, _alpha));
        public Color turquoise =>            Lut(new Color32( 64, 224, 208, _alpha));
        public Color royalblue =>            Lut(new Color32( 65, 105, 225, _alpha));
        public Color steelblue =>            Lut(new Color32( 70, 130, 180, _alpha));
        public Color darkslateblue =>        Lut(new Color32( 72,  61, 139, _alpha));
        public Color mediumturquoise =>      Lut(new Color32( 72, 209, 204, _alpha));
        public Color indigo =>               Lut(new Color32( 75,   0, 130, _alpha));
        public Color darkolivegreen =>       Lut(new Color32( 85, 107,  47, _alpha));
        public Color cadetblue =>            Lut(new Color32( 95, 158, 160, _alpha));
        public Color cornflowerblue =>       Lut(new Color32(100, 149, 237, _alpha));
        public Color mediumaquamarine =>     Lut(new Color32(102, 205, 170, _alpha));
        public Color dimgrey =>              Lut(new Color32(105, 105, 105, _alpha));
        public Color dimgray =>              Lut(new Color32(105, 105, 105, _alpha));
        public Color slateblue =>            Lut(new Color32(106,  90, 205, _alpha));
        public Color olivedrab =>            Lut(new Color32(107, 142,  35, _alpha));
        public Color slategray =>            Lut(new Color32(112, 128, 144, _alpha));
        public Color lightslategrey =>       Lut(new Color32(119, 136, 153, _alpha));
        public Color lightslategray =>       Lut(new Color32(119, 136, 153, _alpha));
        public Color mediumslateblue =>      Lut(new Color32(123, 104, 238, _alpha));
        public Color lawngreen =>            Lut(new Color32(124, 252,   0, _alpha));
        public Color chartreuse =>           Lut(new Color32(127, 255,   0, _alpha));
        public Color aquamarine =>           Lut(new Color32(127, 255, 212, _alpha));
        public Color maroon =>               Lut(new Color32(128,   0,   0, _alpha));
        public Color purple =>               Lut(new Color32(128,   0, 128, _alpha));
        public Color olive =>                Lut(new Color32(128, 128,   0, _alpha));
        public Color gray =>                 Lut(new Color32(128, 128, 128, _alpha));
        public Color grey =>                 Lut(new Color32(128, 128, 128, _alpha));
        public Color skyblue =>              Lut(new Color32(135, 206, 235, _alpha));
        public Color lightskyblue =>         Lut(new Color32(135, 206, 250, _alpha));
        public Color blueviolet =>           Lut(new Color32(138,  43, 226, _alpha));
        public Color darkred =>              Lut(new Color32(139,   0,   0, _alpha));
        public Color darkmagenta =>          Lut(new Color32(139,   0, 139, _alpha));
        public Color saddlebrown =>          Lut(new Color32(139,  69,  19, _alpha));
        public Color darkseagreen =>         Lut(new Color32(143, 188, 143, _alpha));
        public Color lightgreen =>           Lut(new Color32(144, 238, 144, _alpha));
        public Color mediumpurple =>         Lut(new Color32(147, 112, 219, _alpha));
        public Color darkviolet =>           Lut(new Color32(148,   0, 211, _alpha));
        public Color palegreen =>            Lut(new Color32(152, 251, 152, _alpha));
        public Color darkorchid =>           Lut(new Color32(153,  50, 204, _alpha));
        public Color yellowgreen =>          Lut(new Color32(154, 205,  50, _alpha));
        public Color sienna =>               Lut(new Color32(160,  82,  45, _alpha));
        public Color brown =>                Lut(new Color32(165,  42,  42, _alpha));
        public Color darkgrey =>             Lut(new Color32(169, 169, 169, _alpha));
        public Color darkgray =>             Lut(new Color32(169, 169, 169, _alpha));
        public Color lightblue =>            Lut(new Color32(173, 216, 230, _alpha));
        public Color greenyellow =>          Lut(new Color32(173, 255,  47, _alpha));
        public Color paleturquoise =>        Lut(new Color32(175, 238, 238, _alpha));
        public Color lightsteelblue =>       Lut(new Color32(176, 196, 222, _alpha));
        public Color powderblue =>           Lut(new Color32(176, 224, 230, _alpha));
        public Color firebrick =>            Lut(new Color32(178,  34,  34, _alpha));
        public Color darkgoldenrod =>        Lut(new Color32(184, 134,  11, _alpha));
        public Color mediumorchid =>         Lut(new Color32(186,  85, 211, _alpha));
        public Color rosybrown =>            Lut(new Color32(188, 143, 143, _alpha));
        public Color darkkhaki =>            Lut(new Color32(189, 183, 107, _alpha));
        public Color silver =>               Lut(new Color32(192, 192, 192, _alpha));
        public Color mediumvioletred =>      Lut(new Color32(199,  21, 133, _alpha));
        public Color indianred =>            Lut(new Color32(205,  92,  92, _alpha));
        public Color peru =>                 Lut(new Color32(205, 133,  63, _alpha));
        public Color chocolate =>            Lut(new Color32(210, 105,  30, _alpha));
        public Color tan =>                  Lut(new Color32(210, 180, 140, _alpha));
        public Color lightgrey =>            Lut(new Color32(211, 211, 211, _alpha));
        public Color lightgray =>            Lut(new Color32(211, 211, 211, _alpha));
        public Color thistle =>              Lut(new Color32(216, 191, 216, _alpha));
        public Color orchid =>               Lut(new Color32(218, 112, 214, _alpha));
        public Color goldenrod =>            Lut(new Color32(218, 165,  32, _alpha));
        public Color palevioletred =>        Lut(new Color32(219, 112, 147, _alpha));
        public Color crimson =>              Lut(new Color32(220,  20,  60, _alpha));
        public Color gainsboro =>            Lut(new Color32(220, 220, 220, _alpha));
        public Color plum =>                 Lut(new Color32(221, 160, 221, _alpha));
        public Color burlywood =>            Lut(new Color32(222, 184, 135, _alpha));
        public Color lightcyan =>            Lut(new Color32(224, 255, 255, _alpha));
        public Color lavender =>             Lut(new Color32(230, 230, 250, _alpha));
        public Color darksalmon =>           Lut(new Color32(233, 150, 122, _alpha));
        public Color violet =>               Lut(new Color32(238, 130, 238, _alpha));
        public Color palegoldenrod =>        Lut(new Color32(238, 232, 170, _alpha));
        public Color lightcoral =>           Lut(new Color32(240, 128, 128, _alpha));
        public Color khaki =>                Lut(new Color32(240, 230, 140, _alpha));
        public Color aliceblue =>            Lut(new Color32(240, 248, 255, _alpha));
        public Color honeydew =>             Lut(new Color32(240, 255, 240, _alpha));
        public Color azure =>                Lut(new Color32(240, 255, 255, _alpha));
        public Color sandybrown =>           Lut(new Color32(244, 164,  96, _alpha));
        public Color wheat =>                Lut(new Color32(245, 222, 179, _alpha));
        public Color beige =>                Lut(new Color32(245, 245, 220, _alpha));
        public Color whitesmoke =>           Lut(new Color32(245, 245, 245, _alpha));
        public Color mintcream =>            Lut(new Color32(245, 255, 250, _alpha));
        public Color ghostwhite =>           Lut(new Color32(248, 248, 255, _alpha));
        public Color salmon =>               Lut(new Color32(250, 128, 114, _alpha));
        public Color antiquewhite =>         Lut(new Color32(250, 235, 215, _alpha));
        public Color linen =>                Lut(new Color32(250, 240, 230, _alpha));
        public Color lightgoldenrodyellow => Lut(new Color32(250, 250, 210, _alpha));
        public Color oldlace =>              Lut(new Color32(253, 245, 230, _alpha));
        public Color red =>                  Lut(new Color32(255,   0,   0, _alpha));
        public Color fuchsia =>              Lut(new Color32(255,   0, 255, _alpha));
        public Color magenta =>              Lut(new Color32(255,   0, 255, _alpha));
        public Color deeppink =>             Lut(new Color32(255,  20, 147, _alpha));
        public Color orangered =>            Lut(new Color32(255,  69,   0, _alpha));
        public Color tomato =>               Lut(new Color32(255,  99,  71, _alpha));
        public Color hotpink =>              Lut(new Color32(255, 105, 180, _alpha));
        public Color coral =>                Lut(new Color32(255, 127,  80, _alpha));
        public Color darkorange =>           Lut(new Color32(255, 140,   0, _alpha));
        public Color lightsalmon =>          Lut(new Color32(255, 160, 122, _alpha));
        public Color orange =>               Lut(new Color32(255, 165,   0, _alpha));
        public Color lightpink =>            Lut(new Color32(255, 182, 193, _alpha));
        public Color pink =>                 Lut(new Color32(255, 192, 203, _alpha));
        public Color gold =>                 Lut(new Color32(255, 215,   0, _alpha));
        public Color peachpuff =>            Lut(new Color32(255, 218, 185, _alpha));
        public Color navajowhite =>          Lut(new Color32(255, 222, 173, _alpha));
        public Color moccasin =>             Lut(new Color32(255, 228, 181, _alpha));
        public Color bisque =>               Lut(new Color32(255, 228, 196, _alpha));
        public Color mistyrose =>            Lut(new Color32(255, 228, 225, _alpha));
        public Color blanchedalmond =>       Lut(new Color32(255, 235, 205, _alpha));
        public Color papayawhip =>           Lut(new Color32(255, 239, 213, _alpha));
        public Color lavenderblush =>        Lut(new Color32(255, 240, 245, _alpha));
        public Color seashell =>             Lut(new Color32(255, 245, 238, _alpha));
        public Color cornsilk =>             Lut(new Color32(255, 248, 220, _alpha));
        public Color lemonchiffon =>         Lut(new Color32(255, 250, 205, _alpha));
        public Color floralwhite =>          Lut(new Color32(255, 250, 240, _alpha));
        public Color snow =>                 Lut(new Color32(255, 250, 250, _alpha));
        public Color yellow =>               Lut(new Color32(255, 255,   0, _alpha));
        public Color lightyellow =>          Lut(new Color32(255, 255, 224, _alpha));
        public Color ivory =>                Lut(new Color32(255, 255, 240, _alpha));
        public Color white =>                Lut(new Color32(255, 255, 255, _alpha));

#pragma warning restore IDE0025 // Use block body for properties
#pragma warning restore IDE1006 // Naming Styles

		public byte Alpha 
        { 
            get 
            { 
                return _alpha; 
            } 
            set 
            { 
                _alpha = value; 
            } 
        }

        internal Color32 Lut(Color32 c) 
        { 
            return (_useLut) ? global::IDHIUtils.SvgColor.LookupColor(c) : c; 
        }

        public SvgColor(bool useLut = true)
        {
            _useLut = useLut;
        }

        /// <summary>
        /// Initialize lookup table called in Awake()
        /// </summary>
        static public void Init()
        {
            _lut = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            _lut.LoadImage(ResourceUtils.GetEmbeddedResource("lookuptexture.png"));
        }

        /// <summary>
        /// Code and lut texture from koikoi.happy.nu.color_adjuster
        /// Stolen again from ManlyMarco
        /// </summary>
        static public Color LookupColor(Color color)
        {
            var num = color.b * 63f;
            var num2 = Mathf.Floor(Mathf.Floor(num) / 8f);
            var num3 = Mathf.Floor(num) - num2 * 8f;
            var num4 = Mathf.Floor(Mathf.Ceil(num) / 8f);
            var num5 = Mathf.Ceil(num) - num4 * 8f;
            var num6 = num3 * 0.125f + 0.0009765625f + 0.123046875f * color.r;
            var num7 = num2 * 0.125f + 0.0009765625f + 0.123046875f * color.g;
            num7 = 1f - num7;
            var num8 = num5 * 0.125f + 0.0009765625f + 0.123046875f * color.r;
            var num9 = num4 * 0.125f + 0.0009765625f + 0.123046875f * color.g;
            num9 = 1f - num9;
            var pixel = _lut.GetPixel((int)(num6 * 512f), (int)(num7 * 512f));
            var pixel2 = _lut.GetPixel((int)(num8 * 512f), (int)(num9 * 512f));
            return Color.Lerp(pixel, pixel2, Mathf.Repeat(num, 1f));
        }
    }
}
