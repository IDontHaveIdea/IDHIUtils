using System;
using System.Collections.Generic;

using BepInEx;

using KKAPI.Utilities;

namespace IDHIUtils
{
    /// <summary>
    /// Utilities that should be generic for plug-ins
    /// </summary>
    ///
    public partial class Utilities
    {
        static public BaseUnityPlugin GetPluginInstance(string guID)
        {
            BepInEx.Bootstrap.Chainloader.PluginInfos.TryGetValue(guID, out var PInfo);
            return PInfo?.Instance;
        }

        static public Version GetPluginVersion(string guID)
        {
            BepInEx.Bootstrap.Chainloader.PluginInfos.TryGetValue(guID, out var PInfo);
            return PInfo?.Metadata?.Version;
        }

        static public bool PluginVersionCompare(string guID, string version)
        {
            BepInEx.Bootstrap.Chainloader.PluginInfos.TryGetValue(guID, out var PInfo);
            if (PInfo == null)
            {
                return false;
            }

            return PInfo.Metadata.Version.CompareTo(new Version(version)) > -1;
        }

        static public bool PluginVersionCompare(BaseUnityPlugin Instance, string version)
        {
            if (Instance == null)
            {
                return false;
            }

            return Instance.Info.Metadata.Version.CompareTo(new Version(version)) > -1;
        }

        static public string Translate(string name)
        {
            if (!TranslationHelper.TryTranslate(name, out var tmp))
            {
                return name;
            }

            return tmp;
        }

        /// <summary>
        /// Return categories in the string form "{ cat 1, cat 2, ,,,}"
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="names"></param>
        /// <param name="quotes"></param>
        /// <returns></returns>
        static public string CategoryList(List<HSceneProc.Category> categories, bool names = false, bool quotes = true)
        {
            var tmp = "";
            var first = true;

            foreach (var c in categories)
            {
                if (first)
                {
                    if (names)
                    {
                        tmp += (PositionCategory)c.category;
                    }
                    else
                    {
                        tmp += c.category.ToString();
                    }
                    first = false;
                }
                else
                {
                    if (names)
                    {
                        tmp += ", " + (PositionCategory)c.category;
                    }
                    else
                    {
                        tmp += ", " + c.category.ToString();
                    }
                }
            }
            return quotes ? "\" { " + tmp + " }\"" : "{ " + tmp + " }";
        }

        /// <summary>
        /// Ditto
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="names"></param>
        /// <param name="quotes"></param>
        /// <returns></returns>
        static public string CategoryList(List<int> categories, bool names = false, bool quotes = true)
        {
            var tmp = "";
            var first = true;

            foreach (var c in categories)
            {
                if (first)
                {
                    if (names)
                    {
                        tmp += (PositionCategory)c;
                    }
                    else
                    {
                        tmp += c.ToString();
                    }
                    first = false;
                }
                else
                {
                    if (names)
                    {
                        tmp += ", " + (PositionCategory)c;
                    }
                    else
                    {
                        tmp += ", " + c.ToString();
                    }
                }
            }
            return quotes ? "\" { " + tmp + " }\"" : "{ " + tmp + " }";
        }


    }
}
