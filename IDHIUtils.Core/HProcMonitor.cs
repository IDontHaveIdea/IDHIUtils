//
// HProcScene handle events for start and stop H Scene
// Enables SHCAdjustController operation is disable
// upon start and disabled on H Scene exit
//
using System;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

using KKAPI;

//using IDHIUtils;


namespace IDHIUtils
{

    //[BepInDependency(KoikatuAPI.GUID, KoikatuAPI.VersionConst)]
    //[BepInDependency(Utilities.GUID, Utilities.Version)]
    //[BepInPlugin(GUID, Name, Version)]
    //[BepInProcess(KoikatuAPI.GameProcessName)]
    public partial class HProcMonitor // : BaseUnityPlugin
    {
        static internal Harmony _hsHookInstance;
        static internal Type HSceneProcType;

        #region public properties
        /// <summary>
        /// HProcMonitor Hooks are loaded if true
        /// </summary>
        static public bool Kuuhou { get; internal set; }

        /// <summary>
        /// True if we are inside an HScene
        /// </summary>
        static public bool Nakadashi { get; internal set; }
        #endregion

        #region events
        static public event EventHandler OnHSceneStartLoading;
        static public event EventHandler OnHSceneExiting;
        static public event EventHandler<HSceneFinishedLoadingEventArgs> OnHSceneFinishedLoading;
        public class HSceneFinishedLoadingEventArgs : EventArgs
        {
            public HSceneProc Instance { get; }
            public List<ChaControl> Heroines { get; }
            public ChaControl Male { get; }
            public HSceneFinishedLoadingEventArgs(HSceneProc instance,
                List<ChaControl> lstFemale, ChaControl male)
            {
                Instance = instance;
                Heroines = lstFemale;
                Male = male;
            }
        }

        static internal void InvokeOnHSceneStartLoading(object _sender, EventArgs _args)
        {
            OnHSceneStartLoading?.Invoke(_sender, _args);
        }
        #endregion

        #region private methods
        static public void Init()
        {
            //mother = obj;

            OnHSceneStartLoading += (_sender, _args) =>
            {
                Utilities._Log.Info($"SHCA0009: [OnHSceneStartLoading]");
            };

            OnHSceneFinishedLoading += (_sender, _args) =>
            {
                Utilities._Log.Info($"SHCA0010: [OnHSceneFinishedLoading]");
            };

            OnHSceneExiting += (_sender, _args) =>
            {
                Utilities._Log.Info($"SHCA0011: [OnHSceneExiting]");
            };
        }
        #endregion

        static internal void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
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
            static internal void Init()
            {
                _hsHookInstance = Harmony.CreateAndPatchAll(typeof(Hooks));
                if (_hsHookInstance == null)
                {
                    Utilities._Log.Level(LogLevel.Error, $"SHCA0012: [CharHScene] Cannot patch the " +
                        $"system.");
                    throw new ApplicationException($"SHCA0012: [CharHScene] Cannot patch the " +
                        $"system.");
                }

                // Patch through reflection
                HSceneProcType = Type.GetType("HSceneProc, Assembly-CSharp");

                _hsHookInstance.Patch(HSceneProcType.GetMethod("OnDestroy", AccessTools.all),
                    prefix: new HarmonyMethod(typeof(Hooks), nameof(Hooks.OnDestroyPrefix)));

                _hsHookInstance.Patch(HSceneProcType.GetMethod("SetShortcutKey", AccessTools.all),
                    postfix: new HarmonyMethod(typeof(Hooks), nameof(Hooks.SetShortcutKeyPostfix)));
#if DEBUG
                Utilities._Log.Info($"SHCA0036: Patch seams OK.");
#endif
            }

            static private void OnDestroyPrefix()
            {
                OnHSceneExiting?.Invoke(null, null);
                Nakadashi = false;
                _hsHookInstance.UnpatchSelf();
                _hsHookInstance = null;
            }

            static private void SetShortcutKeyPostfix(HSceneProc __instance,
                List<ChaControl> ___lstFemale, ChaControl ___male, HSprite ___sprite)
            {
                if (Kuuhou)
                {
                    Utilities._Log.Level(LogLevel.Warning, $"SHCA0013: [SetShortcutKey] Already loaded.");
                    return;
                }
                Kuuhou = true;
                OnHSceneFinishedLoading?.Invoke(null, 
                    new HSceneFinishedLoadingEventArgs(__instance, ___lstFemale, ___male));
            }
        }
    }
}
