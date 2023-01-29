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
using H;

#if KKS
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

#if KKS
                _hsHookInstance.Patch(_hSceneProcType.GetMethod(
                    "GetCloseCategory", AccessTools.all),
                    postfix: new HarmonyMethod(typeof(Hooks),
                        nameof(Hooks.GetCloseCategoryPostfix)));
#endif
                _hsHookInstance.Patch(_hSceneProcType.GetMethod(
                    "OnDestroy", AccessTools.all),
                    prefix: new HarmonyMethod(typeof(Hooks),
                        nameof(Hooks.OnDestroyPrefix)));

                _hsHookInstance.Patch(_hSceneProcType.GetMethod(
                    "SetShortcutKey", AccessTools.all),
                    postfix: new HarmonyMethod(
                        typeof(Hooks), nameof(Hooks.SetShortcutKeyPostfix)));
#if DEBUG
                Utilities._Log.Info($"UTIL0006: [HProcMonitor] Patch seams OK.");
#endif
            }

            private static void GetCloseCategoryPostfix(
                object __instance,
                List<ChaControl> ___lstFemale,
                ChaControl ___male)
            {
#if DEBUG
                Utilities._Log.Info($"[GetCloseCategory] HPoints set.");
#endif
                OnHSceneSetHPoints?.Invoke(null,
                    new HSceneSetHPointsEventArgs(
                        __instance, ___lstFemale, ___male));
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
#if KKS
                Heroines = flags.lstHeroine;
                HProcMonitor.HFlag = flags;
                Player = ___male;
#endif
                OnHSceneFinishedLoading?.Invoke(null,
                    new HSceneFinishedLoadingEventArgs(
                        __instance, ___lstFemale, ___male));
            }
        }
        #endregion

        internal static Harmony _hsHookInstance;
        internal static Type _hSceneProcType;

        #region Properties
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
        public static event EventHandler<HSceneSetHPointsEventArgs>
            OnHSceneSetHPoints;
        public class HSceneSetHPointsEventArgs : EventArgs
        {
            public object ObjectInstance { get; }
            public List<ChaControl> Females { get; }
            public ChaControl Male { get; }
            public HSceneSetHPointsEventArgs(object instance,
                List<ChaControl> lstFemale, ChaControl male)
            {
                ObjectInstance = instance;
                Females = lstFemale;
                Male = male;
            }
        }

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
                Utilities._Log.Info($"[HProcMonitor.Init] OnHSceneStartLoading.");
            };

            OnHSceneSetHPoints += (_sender, _args) =>
            {
                Utilities._Log.Info($"[HProcMonitor.Init] OnHSceneSetHPoints");
            };

            OnHSceneFinishedLoading += (_sender, _args) =>
            {
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
