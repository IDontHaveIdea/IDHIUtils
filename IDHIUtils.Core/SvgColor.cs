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
    static public class SvgColor
    {
        static readonly public Color aliceblue = new Color32(240, 248, 255, 255);
        static readonly public Color antiquewhite = new Color32(250, 235, 215, 255);
        static readonly public Color aqua = new Color32(0, 255, 255, 255);
        static readonly public Color aquamarine = new Color32(127, 255, 212, 255);
        static readonly public Color azure = new Color32(240, 255, 255, 255);
        static readonly public Color beige = new Color32(245, 245, 220, 255);
        static readonly public Color bisque = new Color32(255, 228, 196, 255);
        static readonly public Color black = new Color32(0, 0, 0, 255);
        static readonly public Color blanchedalmond = new Color32(255, 235, 205, 255);
        static readonly public Color blue = new Color32(0, 0, 255, 255);
        static readonly public Color blueviolet = new Color32(138, 43, 226, 255);
        static readonly public Color brown = new Color32(165, 42, 42, 255);
        static readonly public Color burlywood = new Color32(222, 184, 135, 255);
        static readonly public Color cadetblue = new Color32(95, 158, 160, 255);
        static readonly public Color chartreuse = new Color32(127, 255, 0, 255);
        static readonly public Color chocolate = new Color32(210, 105, 30, 255);
        static readonly public Color coral = new Color32(255, 127, 80, 255);
        static readonly public Color cornflowerblue = new Color32(100, 149, 237, 255);
        static readonly public Color cornsilk = new Color32(255, 248, 220, 255);
        static readonly public Color crimson = new Color32(220, 20, 60, 255);
        static readonly public Color cyan = new Color32(0, 255, 255, 255);
        static readonly public Color darkblue = new Color32(0, 0, 139, 255);
        static readonly public Color darkcyan = new Color32(0, 139, 139, 255);
        static readonly public Color darkgoldenrod = new Color32(184, 134, 11, 255);
        static readonly public Color darkgray = new Color32(169, 169, 169, 255);
        static readonly public Color darkgreen = new Color32(0, 100, 0, 255);
        static readonly public Color darkgrey = new Color32(169, 169, 169, 255);
        static readonly public Color darkkhaki = new Color32(189, 183, 107, 255);
        static readonly public Color darkmagenta = new Color32(139, 0, 139, 255);
        static readonly public Color darkolivegreen = new Color32(85, 107, 47, 255);
        static readonly public Color darkorange = new Color32(255, 140, 0, 255);
        static readonly public Color darkorchid = new Color32(153, 50, 204, 255);
        static readonly public Color darkred = new Color32(139, 0, 0, 255);
        static readonly public Color darksalmon = new Color32(233, 150, 122, 255);
        static readonly public Color darkseagreen = new Color32(143, 188, 143, 255);
        static readonly public Color darkslateblue = new Color32(72, 61, 139, 255);
        static readonly public Color darkslategray = new Color32(47, 79, 79, 255);
        static readonly public Color darkslategrey = new Color32(47, 79, 79, 255);
        static readonly public Color darkturquoise = new Color32(0, 206, 209, 255);
        static readonly public Color darkviolet = new Color32(148, 0, 211, 255);
        static readonly public Color deeppink = new Color32(255, 20, 147, 255);
        static readonly public Color deepskyblue = new Color32(0, 191, 255, 255);
        static readonly public Color dimgray = new Color32(105, 105, 105, 255);
        static readonly public Color dimgrey = new Color32(105, 105, 105, 255);
        static readonly public Color dodgerblue = new Color32(30, 144, 255, 255);
        static readonly public Color firebrick = new Color32(178, 34, 34, 255);
        static readonly public Color floralwhite = new Color32(255, 250, 240, 255);
        static readonly public Color forestgreen = new Color32(34, 139, 34, 255);
        static readonly public Color fuchsia = new Color32(255, 0, 255, 255);
        static readonly public Color gainsboro = new Color32(220, 220, 220, 255);
        static readonly public Color ghostwhite = new Color32(248, 248, 255, 255);
        static readonly public Color gold = new Color32(255, 215, 0, 255);
        static readonly public Color goldenrod = new Color32(218, 165, 32, 255);
        static readonly public Color gray = new Color32(128, 128, 128, 255);
        static readonly public Color grey = new Color32(128, 128, 128, 255);
        static readonly public Color green = new Color32(0, 128, 0, 255);
        static readonly public Color greenyellow = new Color32(173, 255, 47, 255);
        static readonly public Color honeydew = new Color32(240, 255, 240, 255);
        static readonly public Color hotpink = new Color32(255, 105, 180, 255);
        static readonly public Color indianred = new Color32(205, 92, 92, 255);
        static readonly public Color indigo = new Color32(75, 0, 130, 255);
        static readonly public Color ivory = new Color32(255, 255, 240, 255);
        static readonly public Color khaki = new Color32(240, 230, 140, 255);
        static readonly public Color lavender = new Color32(230, 230, 250, 255);
        static readonly public Color lavenderblush = new Color32(255, 240, 245, 255);
        static readonly public Color lawngreen = new Color32(124, 252, 0, 255);
        static readonly public Color lemonchiffon = new Color32(255, 250, 205, 255);
        static readonly public Color lightblue = new Color32(173, 216, 230, 255);
        static readonly public Color lightcoral = new Color32(240, 128, 128, 255);
        static readonly public Color lightcyan = new Color32(224, 255, 255, 255);
        static readonly public Color lightgoldenrodyellow = new Color32(250, 250, 210, 255);
        static readonly public Color lightgray = new Color32(211, 211, 211, 255);
        static readonly public Color lightgreen = new Color32(144, 238, 144, 255);
        static readonly public Color lightgrey = new Color32(211, 211, 211, 255);
        static readonly public Color lightpink = new Color32(255, 182, 193, 255);
        static readonly public Color lightsalmon = new Color32(255, 160, 122, 255);
        static readonly public Color lightseagreen = new Color32(32, 178, 170, 255);
        static readonly public Color lightskyblue = new Color32(135, 206, 250, 255);
        static readonly public Color lightslategray = new Color32(119, 136, 153, 255);
        static readonly public Color lightslategrey = new Color32(119, 136, 153, 255);
        static readonly public Color lightsteelblue = new Color32(176, 196, 222, 255);
        static readonly public Color lightyellow = new Color32(255, 255, 224, 255);
        static readonly public Color lime = new Color32(0, 255, 0, 255);
        static readonly public Color limegreen = new Color32(50, 205, 50, 255);
        static readonly public Color linen = new Color32(250, 240, 230, 255);
        static readonly public Color magenta = new Color32(255, 0, 255, 255);
        static readonly public Color maroon = new Color32(128, 0, 0, 255);
        static readonly public Color mediumaquamarine = new Color32(102, 205, 170, 255);
        static readonly public Color mediumblue = new Color32(0, 0, 205, 255);
        static readonly public Color mediumorchid = new Color32(186, 85, 211, 255);
        static readonly public Color mediumpurple = new Color32(147, 112, 219, 255);
        static readonly public Color mediumseagreen = new Color32(60, 179, 113, 255);
        static readonly public Color mediumslateblue = new Color32(123, 104, 238, 255);
        static readonly public Color mediumspringgreen = new Color32(0, 250, 154, 255);
        static readonly public Color mediumturquoise = new Color32(72, 209, 204, 255);
        static readonly public Color mediumvioletred = new Color32(199, 21, 133, 255);
        static readonly public Color midnightblue = new Color32(25, 25, 112, 255);
        static readonly public Color mintcream = new Color32(245, 255, 250, 255);
        static readonly public Color mistyrose = new Color32(255, 228, 225, 255);
        static readonly public Color moccasin = new Color32(255, 228, 181, 255);
        static readonly public Color navajowhite = new Color32(255, 222, 173, 255);
        static readonly public Color navy = new Color32(0, 0, 128, 255);
        static readonly public Color oldlace = new Color32(253, 245, 230, 255);
        static readonly public Color olive = new Color32(128, 128, 0, 255);
        static readonly public Color olivedrab = new Color32(107, 142, 35, 255);
        static readonly public Color orange = new Color32(36, 6, 97, 255);
        static readonly public Color orangered = new Color32(255, 69, 0, 255);
        static readonly public Color orchid = new Color32(218, 112, 214, 255);
        static readonly public Color palegoldenrod = new Color32(238, 232, 170, 255);
        static readonly public Color palegreen = new Color32(152, 251, 152, 255);
        static readonly public Color paleturquoise = new Color32(175, 238, 238, 255);
        static readonly public Color palevioletred = new Color32(219, 112, 147, 255);
        static readonly public Color papayawhip = new Color32(255, 239, 213, 255);
        static readonly public Color peachpuff = new Color32(255, 218, 185, 255);
        static readonly public Color peru = new Color32(205, 133, 63, 255);
        static readonly public Color pink = new Color32(255, 192, 203, 255);
        static readonly public Color plum = new Color32(221, 160, 221, 255);
        static readonly public Color powderblue = new Color32(176, 224, 230, 255);
        static readonly public Color purple = new Color32(128, 0, 128, 255);
        static readonly public Color red = new Color32(255, 0, 0, 255);
        static readonly public Color rosybrown = new Color32(188, 143, 143, 255);
        static readonly public Color royalblue = new Color32(65, 105, 225, 255);
        static readonly public Color saddlebrown = new Color32(139, 69, 19, 255);
        static readonly public Color salmon = new Color32(250, 128, 114, 255);
        static readonly public Color sandybrown = new Color32(244, 164, 96, 255);
        static readonly public Color seagreen = new Color32(46, 139, 87, 255);
        static readonly public Color seashell = new Color32(255, 245, 238, 255);
        static readonly public Color sienna = new Color32(160, 82, 45, 255);
        static readonly public Color silver = new Color32(192, 192, 192, 255);
        static readonly public Color skyblue = new Color32(135, 206, 235, 255);
        static readonly public Color slateblue = new Color32(106, 90, 205, 255);
        static readonly public Color slategray = new Color32(112, 128, 144, 255);
        static readonly public Color snow = new Color32(255, 250, 250, 255);
        static readonly public Color springgreen = new Color32(0, 255, 127, 255);
        static readonly public Color steelblue = new Color32(70, 130, 180, 255);
        static readonly public Color tan = new Color32(210, 180, 140, 255);
        static readonly public Color teal = new Color32(0, 128, 128, 255);
        static readonly public Color thistle = new Color32(216, 191, 216, 255);
        static readonly public Color tomato = new Color32(255, 99, 71, 255);
        static readonly public Color turquoise = new Color32(64, 224, 208, 255);
        static readonly public Color violet = new Color32(238, 130, 238, 255);
        static readonly public Color wheat = new Color32(245, 222, 179, 255);
        static readonly public Color white = new Color32(255, 255, 255, 255);
        static readonly public Color whitesmoke = new Color32(245, 245, 245, 255);
        static readonly public Color yellow = new Color32(255, 255, 0, 255);
        static readonly public Color yellowgreen = new Color32(154, 205, 50, 255);

        static public void Init()
        {
            Console.WriteLine("XXXX: [SvgColor] Hello world!");
        }

        /*
        static private Texture2D _lut;

        static public void Init()
        {
            _lut = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            _lut.LoadImage(ResourceUtils.GetEmbeddedResource("lookuptexture.png"));
            _lut.LoadImage(ResourceUtils.GetEmbeddedResource("lookuptexture.png"));
        }

        /// <summary>
        /// Code and lut texture from koikoi.happy.nu.color_adjuster
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
        */
    }
}
