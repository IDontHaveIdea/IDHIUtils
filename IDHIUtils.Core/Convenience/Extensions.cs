﻿//
// Extensions
//
// Ignore Spelling: Utils

using System;

using UnityEngine;

using KKAPI.MainGame;
using System.Runtime.CompilerServices;


namespace IDHIUtils
{
    public static class UtilsExtensions
    {
        #region Vector format
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
        /// Adjust move vector to transform vector. In Unity when using transform and
        /// moving forward sometimes is along the X axis instead of Z (Why?) vector
        /// representing a move are in the form (right, up, forward) this adjust the
        /// vector to the game transform
        /// </summary>
        /// <param name="self">object self reference</param>
        /// <param name="transform">character Transform</param>
        /// <returns></returns>
        public static Vector3 MovementTransform(this Vector3 self, Transform transform)
        {
            var result = new Vector3(0, 0, 0);

            // sides move
            result += transform.right * self.x;
            // up/down move
            result += transform.up * self.y;
            // forward/backward move
            result += transform.forward * self.z;

            return result;
        }
        #endregion

        #region Heroine extensions
        /// <summary>
        /// Get map number where heroine is.
        /// </summary>
        /// <param name="self">Reference to Heroine object</param>
        /// <returns></returns>
        public static int MapNumber(this SaveData.Heroine self)
        {
#if KKS
            // This is the guide
            if (self.fixCharaID == -13)
            {
                return Utilities.GuideMapNumber(self);
            }
#endif
            var nPC = self.GetNPC();
            if (nPC != null)
            {
                return nPC.mapNo;
            }
            return (-1);
        }

        public static string Name(this SaveData.Heroine self)
        {
            var result = "";

            result = Utilities.Translate(self.Name);

            return result.Trim();
        }

        public static string MapName(this SaveData.Heroine self)
        {
            return Utilities.MapName(self);
        }

        public static int Height(this SaveData.Heroine self)
        {
            return Height(self.chaCtrl);
        }
        #endregion

        #region ChaControl extensions
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

        public static int Height(this ChaControl self)
        {
            var result = (int)Math.Round(self.chaFile.custom.body
                .shapeValueBody[(int)ChaFileDefine.BodyShapeIdx.Height] * 100);

            return result;
        }

        public static float ShapeValueBody(
            this ChaControl self,
            ChaFileDefine.BodyShapeIdx shapeIdx)
        {
            return self.chaFile.custom.body.shapeValueBody[(int)shapeIdx];
        }

        public static string Name(this ChaControl self)
        {
            var result = "";

            result = Utilities.Translate(self.chaFile.parameter.fullname);

            return result.Trim();
        }
        #endregion
    }
}
