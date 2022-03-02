using System;
using System.Collections.Generic;
using System.Text;

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

        static public string TranslateName(string animationName, bool original = false)
        {
            var tmp = Translate(animationName);
            if ((tmp == animationName) || !original)
            {
                return tmp;
            }
            return $"{tmp} ({animationName})";
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
            var tmp = new StringBuilder();
            var first = true;

            foreach (var c in categories)
            {
                var strTmp = c.fileMove == string.Empty ? "" : $"=[{c.fileMove}]";
                if (first)
                {
                    if (names)
                    {
                        tmp.Append($"{(PositionCategory)c.category}({c.category})");
                    }
                    else
                    {
                        tmp.Append(c.category);
                    }
                    tmp.Append(strTmp);
                    first = false;
                }
                else
                {
                    if (names)
                    {

                        tmp.Append($", {(PositionCategory)c.category}({c.category}){strTmp}");
                    }
                    else
                    {
                        tmp.Append($", {c.category}{strTmp}");
                    }
                }
            }
            return quotes ? "\" { " + tmp + " }\"" : "{ " + tmp + " }";
            //var t = $"\" {{ {tmp.ToString()} }}\"";
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
                        tmp += $"{(PositionCategory)c}({c})";
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
                        tmp += $", {(PositionCategory)c}({c})";
                    }
                    else
                    {
                        tmp += $", {c}";
                    }
                }
            }
            return quotes ? "\" { " + tmp + " }\"" : "{ " + tmp + " }";
        }

        static public string CategoryList(int[] categories, bool names = false, bool quotes = true)
        {
            var tmp = "";
            var first = true;

            foreach (var c in categories)
            {
                if (first)
                {
                    if (names)
                    {
                        tmp += $"{(PositionCategory)c}({c})";
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
                        tmp += ", " + $"{(PositionCategory)c}({c})";
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
