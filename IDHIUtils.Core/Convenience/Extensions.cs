//
// Extensions
//
using System;

using UnityEngine;
using KKAPI.MainGame;

namespace IDHIUtils
{
    public static class UtilsExtensions
    {
        public static string Format(
            this Vector3 self,
            string decimals = default,
            int spaces = default)
        {
            string formatString;

            formatString = $"( " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.x)}, " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.y)}, " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.z)} )";

            return formatString;
        }

        public static string Format(
            this Vector2 self,
            string decimals = default,
            int spaces = default)
        {
            string formatString;

            formatString = $"( " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.x)}, " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.y)} )";

            return formatString;
        }

        public static int MapNumber(this SaveData.Heroine self)
        {
            var nPC = self.GetNPC();
            if (nPC != null)
            {
                return nPC.mapNo;
            }

            return -1;
        }

        public static int MapNumber(this ChaControl self)
        {
            var heroine = self.GetHeroine();
            if (heroine != null)
            {
                return MapNumber(heroine);
            }

            return -1;
        }
    }
}
