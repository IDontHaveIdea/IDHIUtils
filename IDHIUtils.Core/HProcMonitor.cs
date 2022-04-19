//
// Based on code by Madevil
// HProcScene handle events for start and stop H Scene
// upon start and disabled on H Scene exit
//
using System;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

using BepInEx.Logging;
using HarmonyLib;

#if KKS
using SaveData;
#endif


namespace IDHIUtils
{
    public partial class HProcMonitor
    {
        internal static Harmony _hsHookInstance;
        internal static Type HSceneProcType;

        #region public properties
        /// <summary>
        /// HProcMonitor Hooks are loaded if true
        /// </summary>
        public static bool Kuuhou { get; internal set; }

        /// <summary>
        /// True if we are inside an HScene
        /// </summary>
        public static bool Nakadashi { get; internal set; }

#if KKS
        public static List<Heroine> Heroines { get; internal set; }
        public static ChaControl Player { get; internal set; }
        public static HFlag HFlag { get; internal set; }
#endif

        #endregion

        #region events
        public static event EventHandler OnHSceneStartLoading;
        public static event EventHandler OnHSceneExiting;
        public static event EventHandler<HSceneFinishedLoadingEventArgs> OnHSceneFinishedLoading;

        public class HSceneFinishedLoadingEventArgs : EventArgs
        {
            public object ObjInstance { get; }
            public List<ChaControl> Females { get; }
            public ChaControl Male { get; }
            public HSceneFinishedLoadingEventArgs(object instance,
                List<ChaControl> lstFemale, ChaControl male)
            {
                ObjInstance = instance;
                Females = lstFemale;
                Male = male;
            }
        }

        internal static void InvokeOnHSceneStartLoading(object _sender, EventArgs _args)
        {
            OnHSceneStartLoading?.Invoke(_sender, _args);
        }
        #endregion

        #region private methods
        public static void Init()
        {
            //mother = obj;

            OnHSceneStartLoading += (_sender, _args) =>
            {
                Utilities._Log.Info($"UTIL0002: [HProcMonitor] OnHSceneStartLoading.");
            };

            OnHSceneFinishedLoading += (_sender, _args) =>
            {
                Utilities._Log.Info($"UTIL0003: [HProcMonitor] OnHSceneFinishedLoading.");
            };

            OnHSceneExiting += (_sender, _args) =>
            {
                Utilities._Log.Info($"UTIL0004: [HProcMonitor] OnHSceneExiting.");
            };
        }
        #endregion

        internal static void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == "HProc")
            {
                Nakadashi = true;
                Hooks.Init();
                InvokeOnHSceneStartLoading(null, null);
            }
        }

        public class Hooks
        {
            internal static void Init()
            {
                _hsHookInstance = Harmony.CreateAndPatchAll(typeof(Hooks));
                if (_hsHookInstance == null)
                {
                    Utilities._Log.Level(LogLevel.Error, $"UTIL0005: [HProcMonitor] Cannot patch the " +
                        $"system.");
                    throw new ApplicationException($"UTIL0005: [HProcMonitor] Cannot patch the " +
                        $"system.");
                }

                // Patch through reflection
                HSceneProcType = Type.GetType("HSceneProc, Assembly-CSharp");

                _hsHookInstance.Patch(HSceneProcType.GetMethod("OnDestroy", AccessTools.all),
                    prefix: new HarmonyMethod(typeof(Hooks), nameof(Hooks.OnDestroyPrefix)));

                _hsHookInstance.Patch(HSceneProcType.GetMethod("SetShortcutKey", AccessTools.all),
                    postfix: new HarmonyMethod(typeof(Hooks), nameof(Hooks.SetShortcutKeyPostfix)));
#if DEBUG
                Utilities._Log.Info($"UTIL0006: [HProcMonitor] Patch seams OK.");
#endif
            }

            private static void OnDestroyPrefix()
            {
                OnHSceneExiting?.Invoke(null, null);
                Nakadashi = false;
                Kuuhou = false;
#if KKS
                Heroines = null;
#endif
                _hsHookInstance.UnpatchSelf();
                _hsHookInstance = null;
            }

            private static void SetShortcutKeyPostfix(
                object __instance,
                List<ChaControl> ___lstFemale,
                ChaControl ___male,
                HSprite ___sprite)
            {
                if (Kuuhou)
                {
                    Utilities._Log.Level(LogLevel.Warning, $"UTIL0007: [HProcMonitor] Already loaded.");
                    return;
                }
#if DEBUG
                Utilities._Log.Level(LogLevel.Info, $"UTIL0001: [HProcMonitor] Loading ...");
#endif
                var hsceneTraverse = Traverse.Create(__instance);
                var flags = hsceneTraverse
                        .Field<HFlag>("flags").Value;
                Kuuhou = true;
#if KKS
                Heroines = flags.lstHeroine;
                HProcMonitor.HFlag = flags;
                Player = ___male;
#endif
                OnHSceneFinishedLoading?.Invoke(null, 
                    new HSceneFinishedLoadingEventArgs(__instance, ___lstFemale, ___male));
            }
        }
    }
}
