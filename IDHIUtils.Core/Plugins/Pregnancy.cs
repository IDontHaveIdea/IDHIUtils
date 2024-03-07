//
// AnimationLoader
//
// Ignore Spelling: Utils

using System;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

using BepInEx.Configuration;
using KKAPI.Utilities;

namespace IDHIUtils
{
    public class Pregnancy : Utilities.PInfo
    {
        private readonly MethodInfo _fertilityMethod;
        private readonly MethodInfo _statusMethod;
        //private PropertyInfo _conceptionEnabled;

        public Pregnancy() : base("KK_Pregnancy")
        {
            // GetFertility is a separate class PregnancyDataUtils in the KK_Pregnancy
            // using regular reflection to access the method

            var PregnancyType = Type.GetType("KK_Pregnancy.PregnancyDataUtils, KKS_Pregnancy");
            if (PregnancyType != null)
            {
                Utilities._Log.Warning($"CARAJO PregnancyType OK.");
                _fertilityMethod = PregnancyType.GetMethod("GetFertility");
                _statusMethod = PregnancyType.GetMethod("GetCharaStatus");
                if (_fertilityMethod != null )
                {
                    Utilities._Log.Warning($"CARAJO _fertilityMethod OK.");
                }
            }
            /*
             * Utilities._Log.Warning($"CARAJO NEXT STEP 00.");
            var malditaSea = Traverse.Property<ConfigEntry<bool>>("ConceptionEnabled").Value;
            if ( malditaSea != null)
            {
                Utilities._Log.Warning($"CARAJO malditaSea={malditaSea.Value}.");
            }
            var ConfigurationType = Type.GetType("KK_Pregnancy.PregnancyPlugin, KKS_Pregnancy");
            Utilities._Log.Warning($"CARAJO NEXT STEP 01.");
            if (ConfigurationType != null)
            {
                Utilities._Log.Warning($"CARAJO ConfigurationType OK.");
                _conceptionEnabled = ConfigurationType.GetProperty("ConceptionEnabled", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                if (_conceptionEnabled == null )
                {
                    Utilities._Log.Warning("CARAJO _conceptionEnabled is null");
                }
                else
                {
                    var obj = _conceptionEnabled.GetValue(null, null);
                    ConfigurationType.GetPropertyValue("ConceptionEnabled", out var obj2);
                    if (obj != null)
                    {
                        var cf = (ConfigEntry<bool>)obj;
                        Utilities._Log.Warning($"CARAJO _conceptionEnabled={cf.Value}");
                    }
                    else
                    {
                        Utilities._Log.Warning($"CARAJO Can't get a value.");
                    }
                    if (obj2 != null)
                    {
                        var cf = (ConfigEntry<bool>)obj2;
                        Utilities._Log.Warning($"CARAJO _conceptionEnabled2={cf.Value}");
                    }
                    else
                    {
                        Utilities._Log.Warning($"CARAJO 2 Can't get a value.");
                    }
                }
            }
            else
            {
                Utilities._Log.Warning($"CARAJO ConfigurationType failed.");
            }
            Utilities._Log.Warning($"CARAJO NEXT STEP 03.");
            */
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
