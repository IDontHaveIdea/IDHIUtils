//
// HProcScene handle events for start and stop H Scene
// Permits that interact during H-Scene plug-ins to start disabled and changed to
// enabled status when the H-Scene loads.
//
// Ignore Spelling: Utils Kuuhou Nakadashi

using System;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

using BepInEx.Logging;
using HarmonyLib;

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
            /// <summary>
            /// Establish the hooks
            /// </summary>
            /// <exception cref="ApplicationException">Generated when patch does not 
            /// work</exception>
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
#if DEBUG
                Utilities._Log.Info($"[HProcMonitor.Hooks.Init] Patch seams OK.");
#endif
            }

            /// <summary>
            /// Prefix for HSceneProc.Start invokes OnStartLoading event with
            /// HSceneLoadingEventArgs main purpose is to provide pointers
            /// to the HSceneProc module very early in the loading process
            /// one case in a hook to HSceneProc.ChangeAnimator
            /// </summary>
            /// <param name="__instance">HSceneProc object instance</param>
            [HarmonyPrefix]
            [HarmonyPatch(typeof(HSceneProc), nameof(HSceneProc.Start))]
            private static void StartPrefix(
                object __instance)
            {
                var hsceneTraverse = Traverse.Create(__instance);
                var flags = hsceneTraverse
                        .Field<HFlag>("flags").Value;
                var sprite = hsceneTraverse.Field<HSprite>("sprite").Value;
                OnStartLoading?.Invoke(null,
                    new HSceneLoadingEventArgs(
                        __instance, flags, sprite, null, null));

            }

            /// <summary>
            /// Hook into HSceneProc SetShortcutKey load late in HSceneProc Start method.
            /// Invokes OnFinishLoading event with HSceneLoadingEventArgs
            /// </summary>
            /// <param name="__instance">HSceneProc object instance</param>
            [HarmonyPostfix]
            [HarmonyPatch(typeof(HSceneProc), nameof(HSceneProc.SetShortcutKey))]
            private static void SetShortcutKeyPostfix(
                object __instance,
                List<ChaControl> ___lstFemale,
                ChaControl ___male)
            {
                if (Kuuhou)
                {
                    Utilities._Log.Warning($"[HProcMonitor.Hooks.SetShortcutKey] " +
                        $"Already loaded.");
                    return;
                }

                var hsceneTraverse = Traverse.Create(__instance);
                var flags = hsceneTraverse
                        .Field<HFlag>("flags").Value;
                var sprite = hsceneTraverse.Field<HSprite>("sprite").Value;
                Kuuhou = true;
                Flags = flags;
                Heroines = flags.lstHeroine;
                Player = ___male;

                OnFinishedLoading?.Invoke(null,
                    new HSceneLoadingEventArgs(
                        __instance, flags, sprite, ___lstFemale, ___male));
            }

            /// <summary>
            /// Hook into HSceneProc OnDestroy invokes OnExit event
            /// </summary>
            [HarmonyPostfix]
            [HarmonyPatch(typeof(HSceneProc), nameof(HSceneProc.OnDestroy))]
            private static void OnDestroyPrefix()
            {
                Nakadashi = false;
                Kuuhou = false;
                Heroines = null;
                Flags = null;
                Player = null;
                OnExit?.Invoke(null, null);

                _hsHookInstance.UnpatchSelf();
                _hsHookInstance = null;
            }
        }
        #endregion

        internal static Harmony _hsHookInstance;

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
        public static HFlag Flags { get; internal set; }
        #endregion

        #region events
        public static event EventHandler OnInit;
        public static event EventHandler OnExit;

        public static event EventHandler<HSceneLoadingEventArgs>
            OnStartLoading;
        public static event EventHandler<HSceneLoadingEventArgs>
            OnFinishedLoading;

        public class HSceneLoadingEventArgs(object instance,
            HFlag hFlag, HSprite sprite,
            List<ChaControl> lstFemale, ChaControl male) : EventArgs
        {
            public object ObjectInstance { get; } = instance;
            public HFlag HFlag { get; } = hFlag;
            public HSprite Sprite { get; } = sprite;
            public List<ChaControl> Females { get; } = lstFemale;
            public ChaControl Male { get; } = male;
        }
        #endregion

        #region Public Methods
        public static void Init()
        {
            OnInit += (_sender, _args) =>
            {
                Loading = true;
                Utilities._Log.Info($"[HProcMonitor.Init] OnInit.");
            };


            OnStartLoading += (_sender, _args) =>
            {
                Utilities._Log.Info($"[HProcMonitor.Init] OnHSceneStartLoading.");
            };

            OnFinishedLoading += (_sender, _args) =>
            {
                Loading = false;
                Utilities._Log.Info($"[HProcMonitor.Init] OnHSceneFinishedLoading.");
            };

            OnExit += (_sender, _args) =>
            {
                Utilities._Log.Info($"[HProcMonitor.Init] OnHSceneExiting.");
            };
        }
        #endregion

        #region Private Methods
        internal static void SceneLoaded(Scene scene, LoadSceneMode _)
        {
            if (scene.name == "HProc")
            {
                Nakadashi = true;
                Hooks.Init();
                OnInit?.Invoke(null, null);
            }
        }
        #endregion
    }
}
