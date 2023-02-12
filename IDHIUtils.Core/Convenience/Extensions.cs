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
        /// <summary>
        /// String format Vector3 to help debugging 
        /// </summary>
        /// <param name="self">Reference to type Vector3</param>
        /// <param name="decimals">Decimal places</param>
        /// <param name="spaces">Total spaces used pad with space character</param>
        /// <returns></returns>
        public static string Format(
            this Vector3 self,
            string decimals = default,
            int spaces = default)
        {
            string formatString;

            formatString = $"( " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.x)}, " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.y)}, " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.z)}" +
                $" )";

            return formatString;
        }

        /// <summary>
        /// String format Vector2 to help debugging 
        /// </summary>
        /// <param name="self">Reference to type Vector3</param>
        /// <param name="decimals">Decimal places</param>
        /// <param name="spaces">Total spaces used pad with space character</param>
        /// <returns></returns>
        public static string Format(
            this Vector2 self,
            string decimals = default,
            int spaces = default)
        {
            string formatString;

            formatString = $"( " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.x)}, " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.y)}" +
                $" )";

            return formatString;
        }

        /// <summary>
        /// String format Quaternion to help debugging
        /// </summary>
        /// <param name="self">Reference to type Quaternion</param>
        /// <param name="decimals">Decimal places</param>
        /// <param name="spaces">Total spaces used pad with space character</param>
        /// <returns></returns>
        public static string Format(
                    this Quaternion self,
                    string decimals = default,
                    int spaces = default)
        {
            string formatString;

            formatString = $"( " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.x)}, " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.y)}, " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.z)}, " +
                $"{string.Format($"{{0,{spaces}:{decimals}}}", self.w)}" +
                $" )";

            return formatString;
        }

        /// <summary>
        /// Get map number where heroine is.
        /// </summary>
        /// <param name="self">Reference to Heroine object</param>
        /// <returns></returns>
        public static int MapNumber(this SaveData.Heroine self)
        {
            var nPC = self.GetNPC();
            if (nPC != null)
            {
                return nPC.mapNo;
            }

            return -1;
        }

        /// <summary>
        /// Get map number where heroine is
        /// </summary>
        /// <param name="self">Reference to ChaControl object</param>
        /// <returns></returns>
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
