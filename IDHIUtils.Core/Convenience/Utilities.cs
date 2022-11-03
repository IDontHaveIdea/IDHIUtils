//
// Utilities
//
using System;
using System.Collections.Generic;
using System.Text;

using HarmonyLib;

using BepInEx;

using KKAPI.Utilities;
using KKAPI.MainGame;
using UnityEngine;
using System.Diagnostics;

namespace IDHIUtils
{
    /// <summary>
    /// Utilities that should be generic for plug-ins
    /// </summary>
    ///
    public partial class Utilities
    {
        #region Classes
        /// <summary>
        /// Class to help work with PluginInfo class
        /// </summary>
        public class PInfo
        {
            #region Fields
            private PluginInfo _pluginInfo;
            private string _pluginGUID;
            private Traverse _traverse;
            private BaseUnityPlugin _instance = null;
            #endregion

            #region Properties
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
                    // _pluginGUID != null ? _pluginGUID : null;
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
            #endregion

            #region Constructors
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
            #endregion

            #region Methods
            private void GetPluginInfo()
            {
                BepInEx.Bootstrap.Chainloader.PluginInfos
                    .TryGetValue(_pluginGUID, out var PInfo); 
                _pluginInfo = PInfo;
                _instance = _pluginInfo.Instance != null
                    ? _pluginInfo.Instance : null;
            }

            public bool VersionAtLeast(string version)
            {
                if(_pluginInfo == null)
                {
                    return false;
                }

                return _pluginInfo.Metadata.Version
                    .CompareTo(new Version(version)) > -1;
            }

            public Traverse Create(object obj)
            {
                if (Instance != null)
                {
                    return Traverse.Create(obj);
                }
                return null;
            }
            #endregion

        }
        #endregion

        #region Some static data
        public static readonly Dictionary<SaveData.Heroine.HExperienceKind, string>
            HExperienceKind = new()
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
        #endregion

        #region Properties
        /// <summary>
        /// Property returns true if inside HScene
        /// </summary>
        public static bool InHScene
        {
            get
            {
                var hFlag = GameObject.FindObjectOfType<HFlag>();
                if (hFlag != null)
                {
                    // Inside H Scene
                    return true;
                }
                return false;
            }
        }
        #endregion

        #region Static methods
        /// <summary>
        /// Return categories in the string form "{ cat 1, cat 2, ,,,}"
        /// Using HSceneProc.Category List
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="names"></param>
        /// <param name="quotes"></param>
        /// <returns></returns>
        public static string CategoryList(
            List<HSceneProc.Category> categories,
            bool names = false,
            bool quotes = true)
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
        /// Ditto using int List
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="names"></param>
        /// <param name="quotes"></param>
        /// <returns></returns>
        public static string CategoryList(
            List<int> categories,
            bool names = false,
            bool quotes = true)
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

        /// <summary>
        /// Ditto using int array
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="names"></param>
        /// <param name="quotes"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Try to find map number
        /// </summary>
        /// <param name="girl"></param>
        /// <returns>Map number if found -1 if not</returns>
        public static int MapNumber(SaveData.Heroine girl)
        {
            var npc = girl.GetNPC();

            if (npc != null)
            {
                return npc.mapNo;
            }

            return (-1);
        }

        /// <summary>
        /// Overload MapNumber
        /// </summary>
        /// <param name="girl"></param>
        /// <returns>Map number if found -1 if not</returns>
        public static int MapNumber(ChaControl girl)
        {
            var heroine = girl.GetHeroine();
            if (heroine != null)
            {
                return MapNumber(heroine);
            }

            return (-1);
        }

        /// <summary>
        /// Translate string returning same string if no translation found
        /// </summary>
        /// <param name="original">string to translate</param>
        /// <returns></returns>
        public static string Translate(string original)
        {
            if (!TranslationHelper.TryTranslate(original, out var tmp))
            {
                return original.Trim();
            }

            return tmp.Trim();
        }

        /// <summary>
        /// Translate string returning translated string and optionally
        /// returning original inside parenthesis
        /// </summary>
        /// <param name="original"></param>
        /// <param name="returnOriginal"></param>
        /// <returns></returns>
        public static string TranslateName(string original, bool returnOriginal = false)
        {
            var tmp = Translate(original);
            if ((tmp == original) || !returnOriginal)
            {
                return tmp.Trim();
            }
            return $"{tmp.Trim()} ({original.Trim()})";
        }

        /// <summary>
        /// Get name of calling method the higher the frame number it goes
        /// further back in the calling stack
        /// </summary>
        /// <param name="frame">frame number</param>
        /// <param name="longInfo">true for long name false name only</param>
        /// <returns></returns>
        public static string CallingMethod(int frame = 2, bool longInfo = false, bool writeTrace = false)
        {
            // Get call stack
            var st = new StackTrace();

            if (writeTrace)
            {
                for (var i = 0; i < st.FrameCount; i++)
                {
                    // Note that high up the call stack, there is only
                    // one stack frame.
                    StackFrame sf = st.GetFrame(i);
                    Console.WriteLine();
                    Console.WriteLine($"i={i} High up the call stack, Method: {sf.GetMethod()}");

                    Console.WriteLine($"i={i} High up the call stack, Line Number: {sf.GetFileLineNumber()}");
                }
            }

            return longInfo ? $"{st.GetFrame(frame).GetMethod()}"
                : st.GetFrame(frame).GetMethod().Name;
        }
        #endregion
    }
}
