//
// HProcScene handle events for start and stop H Scene
// Permits plug-ins to start disabled and changed the
// enabled status at runtime.
//
using System;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

using BepInEx.Logging;
using HarmonyLib;
using H;

#if KK
using static SaveData;
#else
using SaveData;
#endif


namespace IDHIUtils
{
    public partial class HProcMonitor
    {
        #region Classes
        public class Hooks
        {
            internal static void Init()
            {
                _hsHookInstance = Harmony.CreateAndPatchAll(typeof(Hooks));
                if (_hsHookInstance == null)
                {
                    Utilities._Log.Level(LogLevel.Error, $"[HProcMonitor.Hooks.Init] " +
                        $"Cannot patch the system.");
                    throw new ApplicationException($"[HProcMonitor.Hooks.Init] Cannot " +
                        $"patch the system.");
                }

                // Patch through reflection
                _hSceneProcType = Type.GetType("HSceneProc, Assembly-CSharp");

                /*_hsHookInstance.Patch(_hSceneProcType.GetMethod(
                    "OnDestroy", AccessTools.all),
                    prefix: new HarmonyMethod(typeof(Hooks),
                        nameof(Hooks.OnDestroyPrefix)));

                _hsHookInstance.Patch(_hSceneProcType.GetMethod(
                    "SetShortcutKey", AccessTools.all),
                    postfix: new HarmonyMethod(
                        typeof(Hooks), nameof(Hooks.SetShortcutKeyPostfix)));*/
#if DEBUG
                Utilities._Log.Info($"UTIL0006: [HProcMonitor] Patch seams OK.");
#endif
            }

            /// <summary>
            /// Hook into HSceneProc SetShortcutKey load slate in HSceneProc Start method
            /// </summary>
            /// <param name="__instance">object instance of HSceneProc</param>
            [HarmonyPostfix]
            [HarmonyPatch(typeof(HSceneProc), nameof(HSceneProc.SetShortcutKey))]
            private static void SetShortcutKeyPostfix(
                object __instance,
                List<ChaControl> ___lstFemale,
                ChaControl ___male,
                HSprite ___sprite)
            {
                if (Kuuhou)
                {
                    Utilities._Log.Warning($"[HProcMonitor] [SetShortcutKey] " +
                        $"Already loaded.");
                    return;
                }
#if DEBUG
                Utilities._Log.Info($"[HProcMonitor] [SetShortcutKey] " +
                    $"Loading ...");
#endif
                var hsceneTraverse = Traverse.Create(__instance);
                var flags = hsceneTraverse
                        .Field<HFlag>("flags").Value;
                Kuuhou = true;
                Heroines = flags.lstHeroine;
                HFlags = flags;
                Player = ___male;

                OnHSceneFinishedLoading?.Invoke(null,
                    new HSceneFinishedLoadingEventArgs(
                        __instance, ___lstFemale, ___male));
            }

            /// <summary>
            /// Hook into HSceneProc OnDestroy
            /// </summary>
            [HarmonyPostfix]
            [HarmonyPatch(typeof(HSceneProc), nameof(HSceneProc.OnDestroy))]
            private static void OnDestroyPrefix()
            {
                OnHSceneExiting?.Invoke(null, null);
                Nakadashi = false;
                Kuuhou = false;
                Heroines = null;
                HFlags = null;
                Player = null;

                _hsHookInstance.UnpatchSelf();
                _hsHookInstance = null;
            }
        }
        #endregion

        internal static Harmony _hsHookInstance;
        internal static Type _hSceneProcType;

        #region Properties
        /// <summary>
        /// HProcMonitor Hooks are loaded if true
        /// </summary>
        public static bool Kuuhou { get; internal set; } = false;

        /// <summary>
        /// True if we are inside an HScene
        /// </summary>
        public static bool Nakadashi { get; internal set; } = false;
        public static bool Loading { get; internal set; } = false;
        public static List<Heroine> Heroines { get; internal set; }
        public static ChaControl Player { get; internal set; }
        public static HFlag HFlags { get; internal set; }
        #endregion

        #region events
        public static event EventHandler OnHSceneStartLoading;
        public static event EventHandler OnHSceneExiting;

        public static event EventHandler<HSceneFinishedLoadingEventArgs>
            OnHSceneFinishedLoading;
        public class HSceneFinishedLoadingEventArgs : EventArgs
        {
            public object ObjectInstance { get; }
            public List<ChaControl> Females { get; }
            public ChaControl Male { get; }
            public HSceneFinishedLoadingEventArgs(object instance,
                List<ChaControl> lstFemale, ChaControl male)
            {
                ObjectInstance = instance;
                Females = lstFemale;
                Male = male;
            }
        }

        internal static void InvokeOnHSceneStartLoading(object _sender, EventArgs _args)
        {
            OnHSceneStartLoading?.Invoke(_sender, _args);
        }
        #endregion

        #region Public Methods
        public static void Init()
        {
            //mother = obj;

            OnHSceneStartLoading += (_sender, _args) =>
            {
                Loading = true;
                Utilities._Log.Info($"[HProcMonitor.Init] OnHSceneStartLoading.");
            };

            OnHSceneFinishedLoading += (_sender, _args) =>
            {
                Loading = false;
                Utilities._Log.Info($"[HProcMonitor.Init] OnHSceneFinishedLoading.");
            };

            OnHSceneExiting += (_sender, _args) =>
            {
                Utilities._Log.Info($"[HProcMonitor.Init] OnHSceneExiting.");
            };
        }
        #endregion

        #region Private Methods
        internal static void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == "HProc")
            {
                Nakadashi = true;
                Hooks.Init();
                InvokeOnHSceneStartLoading(null, null);
            }
        }
        #endregion
    }
}
