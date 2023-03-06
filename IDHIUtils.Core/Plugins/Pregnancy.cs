//
// AnimationLoader
//
using System;
using System.Collections.Generic;

using UnityEngine;


namespace IDHIUtils
{
    public class Pregnancy : Utilities.PInfo
    {
        public Pregnancy() : base("KK_Pregnancy")
        {
        }

        public float? GetFertility(SaveData.CharaData character)
        {
            if (!Installed)
            {
                return -1f;
            }

            return Traverse.Method("GetFertility",
                new Type[] { typeof(SaveData.CharaData) })?
                    .GetValue<float>(character);
        }
    }
}
