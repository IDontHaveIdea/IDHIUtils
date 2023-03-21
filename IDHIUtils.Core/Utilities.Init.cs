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
//using ActionGame.Chara;


namespace IDHIUtils
{
    /// <summary>
    /// Utilities that should be generic for plug-ins
    /// </summary>
    ///
    public partial class Utilities
    {
        public static void Init()
        {
#if KKS
            HPointInfo.Init();
            MakerInfo.Init();
#endif
            HProcMonitor.Init();
            Maps.Init();
        }
    }
}
