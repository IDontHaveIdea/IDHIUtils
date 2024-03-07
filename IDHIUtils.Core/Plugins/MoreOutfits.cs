//
// MoreOutfits
//
using System.Collections.Generic;

using HarmonyLib;


namespace IDHIUtils
{
    /// <summary>
    /// Class to get the coordinate names in MoreOutfits through reflection
    /// </summary>
    public class MoreOutfits : Utilities.PInfo
    {
        public MoreOutfits() : base("com.deathweasel.bepinex.moreoutfits")
        {
        }

        internal object GetController(ChaControl chaControl)
        {
            if (!Installed)
            {
                return null;
            }
            return Traverse.Method("GetController",
                    new object[] { chaControl }).GetValue();
        }

        public string GetCoordinateName(
            ChaControl chaControl,
            int coordinateIndex)
        {
            if (!Installed)
            {
                return "";
            }

            if (coordinateIndex < 3)
            {
                return $"{(ChaFileDefine.CoordinateType)coordinateIndex}";
            }

            return Traverse.Method("GetCoodinateName",
                    new object[] { chaControl, coordinateIndex })
                    .GetValue<string>();
        }

        public string GetCoordinateName(
            ChaControl chaControl,
            ChaFileDefine.CoordinateType coordinate)
        {
            return GetCoordinateName(chaControl, (int)coordinate);
        }

        public Dictionary<int, string> CoordinateNames(ChaControl chaControl)
        {
            return CoordinateNames(GetController(chaControl));
        }

        public Dictionary<int, string> CoordinateNames(object pluginController)
        {
            if (!Installed)
            {
                return [];
            }

            return Traverse.Create(pluginController)
                .Field("CoordinateNames").GetValue<Dictionary<int, string>>()
                    ?? [];
        }
    }
}
