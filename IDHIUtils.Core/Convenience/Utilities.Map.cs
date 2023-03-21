//
// Utilities
//
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using UnityEngine;

using BepInEx;
using HarmonyLib;

using KKAPI.Utilities;
using KKAPI.MainGame;
using System.Drawing.Drawing2D;
using ActionGame.Chara;
//using ActionGame.Chara;


namespace IDHIUtils
{
    /// <summary>
    /// Utilities that should be generic for plug-ins
    /// </summary>
    ///
    public partial class Utilities
    {
        public class Maps
        {
            private static Dictionary<int, MapInfo.Param> _mapInfo;

            public static Dictionary<int, MapInfo.Param> Info => _mapInfo;

            public static void Init()
            {
#if KKS
                _mapInfo = BaseMap.LoadMapInfo();
#else
                _mapInfo = Singleton<BaseMap>.Instance.infoDic;
#endif
            }

            //public MapInfo.Param this[int key]
            //{
            //    get { return _mapInfo[key]; }
            //}

            public static bool TryGetValue(
                int key,
                out MapInfo.Param info)
            {
                return _mapInfo.TryGetValue(key, out info);
            }
        }

        /// <summary>
        /// Try to find map number
        /// </summary>
        /// <param name="girl"></param>
        /// <returns>Map number if found -1 if not</returns>
        public static int MapNumber(SaveData.Heroine girl)
        {
#if KKS
            // This is the KKS guide
            if (girl.fixCharaID == -13)
            {
                return GuideMapNumber(girl);
            }
#endif
            var npc = girl.GetNPC();

            if (npc != null)
            {
                return npc.mapNo;
            }
            return (-1);
        }

        public static int MapNumber(ActionGame.Chara.NPC girl)
        {
            if (girl != null)
            {
                return girl.mapNo;
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

        public static string MapName(int mapNumber)
        {
            if (Maps.TryGetValue(mapNumber, out var mapInfo))
            {
                return Translate(mapInfo.MapName);
            }
            return "";
        }

        public static string MapName(ChaControl girl)
        {
            var heroine = girl.GetHeroine();

            if (heroine != null)
            {
                return MapName(heroine);
            }
            return "";
        }

        public static string MapName(SaveData.Heroine girl)
        {
            if (girl != null)
            {
#if KKS
                // This is the KKS guide
                if (girl.fixCharaID == -13)
                {
                    return GuideMapName(girl);
                }
#endif
                var npc = girl.GetNPC();
                if (npc != null)
                {
                    return MapName(npc.mapNo);
                }
            }
            return "";
        }
        public static string MapName(ActionGame.Chara.NPC girl)
        {
            if (girl != null)
            {
                return MapName(girl.mapNo);

            }
            return "";
        }


#if KKS
        public static string GuideMapName(SaveData.Heroine girl)
        {
            if (girl != null)
            {
                var mapNumber = GuideMapNumber(girl);
                if (mapNumber >= 0)
                {
                    return MapName(mapNumber);
                }
            }
            return "";
        }

        public static int GuideMapNumber(SaveData.Heroine girl)
        {
            var guideMap = -1;

            if ((girl != null) && (girl.fixCharaID == -13))
            {
                var fixChara = girl.charaBase as ActionGame.Chara.Fix;
                if (fixChara != null)
                {
                    var mapMove = fixChara.charaData.moveData.mapNo;
                    guideMap = fixChara.mapNo;
                    if ((guideMap <= 0)
                        && (Manager.Game.saveData.guideSetPositionMaps.Count == 1))
                    {
                        guideMap = Manager.Game.saveData.guideSetPositionMaps
                            .ToList()
                            .FirstOrDefault();
                    }
                    else if ((mapMove > 0) && (guideMap <= 0))
                    {
                        guideMap = mapMove;
                    }
                }
            }

            return guideMap;
        }

        public static int GuideMapNumber(ChaControl girl)
        {
            var heroine = girl.GetHeroine();

            if (heroine != null)
            {
                return GuideMapNumber(heroine);
            }

            return (-1);
        }
#endif


    }
}
