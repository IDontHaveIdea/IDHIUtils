using System;
using System.Collections.Generic;
using System.Text;

using HarmonyLib;

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

        public class PInfo
        {
            private PluginInfo _pluginInfo;
            private string _pluginGUID;
            private Traverse _traverse;

            public BaseUnityPlugin Instance => _pluginInfo?.Instance;

            public Version Version => _pluginInfo?.Metadata?.Version;

            public Traverse Traverse
            {
                get
                {
                    if(_traverse == null)
                    {
                        if (Instance != null)
                        {
                            _traverse = Traverse.Create(Instance);
                        }
                    }
                    return _traverse; ;
                }
            }

            public string GUID {
                get
                {
                    // return _pluginGUID != null ? _pluginGUID : null;
                    return _pluginGUID ?? null;
                }

                set
                {
                    if (_pluginGUID != value)
                    {
                        _pluginGUID = value;
                        _traverse = null;
                        GetPluginInfo();
                    }
                }
            }

            public PInfo()
            {
                _pluginGUID = "";
                _pluginInfo = null;
                _traverse = null;
            }

            public PInfo(string gID)
            {
                _pluginGUID = gID;
                _traverse = null;
                GetPluginInfo();
            }

            private void GetPluginInfo()
            {
                BepInEx.Bootstrap.Chainloader.PluginInfos.TryGetValue(_pluginGUID, out var PInfo);
                _pluginInfo = PInfo;
            }

            public bool VersionAtLeast(string version)
            {
                if(_pluginInfo == null)
                {
                    return false;
                }

                return _pluginInfo.Metadata.Version.CompareTo(new Version(version)) > -1;
            }

        }

        public static string Translate(string name)
        {
            if (!TranslationHelper.TryTranslate(name, out var tmp))
            {
                return name;
            }

            return tmp;
        }

        public static string TranslateName(string animationName, bool original = false)
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
        public static string CategoryList(List<HSceneProc.Category> categories, bool names = false, bool quotes = true)
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
        }

        /// <summary>
        /// Ditto
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="names"></param>
        /// <param name="quotes"></param>
        /// <returns></returns>
        public static string CategoryList(List<int> categories, bool names = false, bool quotes = true)
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

        public static string CategoryList(int[] categories, bool names = false, bool quotes = true)
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

        public static readonly Dictionary<SaveData.Heroine.HExperienceKind, string> HExperienceKind = new()
        {
            { SaveData.Heroine.HExperienceKind.初めて, "First Time" },
            { SaveData.Heroine.HExperienceKind.不慣れ, "Inexperience" },
            { SaveData.Heroine.HExperienceKind.慣れ, "Experience" },
            { SaveData.Heroine.HExperienceKind.淫乱, "Horny" }
        };

        public static readonly Dictionary<int, string> Personality = new()
        { 
            { 0, "Sexy" },
            { 1, "Ojousama" },
            { 2, "Snobby" },
            { 3, "Kouhai" },
            { 4, "Mysterious" },
            { 5, "Weirdo" },
            { 6, "Yamato Nadeshiko" },
            { 7, "Tomboy" },
            { 8, "Pure" },
            { 9, "Simple" },
            { 10, "Delusional" },
            { 11, "Motherly" },
            { 12, "Big Sisterly" },
            { 13, "Gyaru" },
            { 14, "Delinquent" },
            { 15, "Wild" },
            { 16, "Wannabe" },
            { 17, "Reluctant" },
            { 18, "Jinxed" },
            { 19, "Bookish" },
            { 20, "Timid" },
            { 21, "Typical Schoolgirl" },
            { 22, "Trendy" },
            { 23, "Otaku" },
            { 24, "Yandere" },
            { 25, "Lazy" },
            { 26, "Quiet" },
            { 27, "Stubborn" },
            { 28, "Old-Fashioned" },
            { 29, "Humble" },
            { 30, "Friendly" },
            { 31, "Willful" },
            { 32, "Honest" },
            { 33, "Glamorous" },
            { 34, "Returnee" },
            { 35, "Slangy" },
            { 36, "Sadistic" },
            { 37, "Emotionless" },
            { 38, "Perfectionist" },
            { 39, "Island Girl" },
            { 40, "Noble" },
            { 41, "Bokukko"},
            { 42, "Naive"},
            { 43, "High Spirited"}
        };
    }
}
