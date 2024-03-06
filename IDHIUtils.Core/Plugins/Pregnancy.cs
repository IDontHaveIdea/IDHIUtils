//
// AnimationLoader
//
// Ignore Spelling: Utils

using System;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;


namespace IDHIUtils
{
    public class Pregnancy : Utilities.PInfo
    {
        private readonly MethodInfo _fertilityMethod;
        private readonly MethodInfo _statusMethod;

        public Pregnancy() : base("KK_Pregnancy")
        {
            // GetFertility is a separate class PregnancyDataUtils in the KK_Pregnancy
            // using regular reflection to access the method
            var PregnancyType = Type.GetType("KK_Pregnancy.PregnancyDataUtils, KKS_Pregnancy");
            if (PregnancyType != null)
            {
                _fertilityMethod = PregnancyType.GetMethod("GetFertility");
                _statusMethod = PregnancyType.GetMethod("GetCharaStatus");
            }
        }

        public float GetFertility(SaveData.CharaData character)
        {
            var fertility = -1f;

            if (!Installed)
            {
                return fertility;
            }

            if (_fertilityMethod != null)
            {
                var obj = _fertilityMethod.Invoke(null, [character]);
                if (obj != null)
                {
                    fertility = (float)obj;
                }
            }

            return fertility;
            //return Traverse.Method("PregnancyDataUtils.GetFertility",
            //    new Type[] { typeof(SaveData.CharaData) })?
            //        .GetValue<float>(character);
        }

        public HeroineStatus GetCharaStatus(SaveData.CharaData character)
        {
            var status = HeroineStatus.Unknown;
            if (!Installed)
            {
                return status;
            }

            if (_fertilityMethod != null)
            {
                var obj = _statusMethod.Invoke(null, [character, null]);
                if (obj != null)
                {
                    status = (HeroineStatus)(int)obj;
                }
            }

            return status;
        }
    }
}
