//
// Utilities
//

using System;

using UnityEngine.SceneManagement;

using BepInEx.Logging;

using KKAPI;


namespace IDHIUtils
{
    /// <summary>
    /// Initializations needed for the utilities
    ///     SvgColor - initialize lookup table
    ///     HProcMonitor - initialize hooks and register to ScreenManager event sceneLoaded
    /// </summary>
    public partial class Utilities
    {
        #region Private Fields
        internal static Logg _Log = new();
        #endregion

        #region Unity Methods
        private void Awake()
        {
            _Log.LogSource = base.Logger;
            _Log.Level(LogLevel.Info, $"[{PluginName}] {PluginDisplayName} " +
                $"loaded.");
            ConfigEntries();
            _Log.Enabled = DebugInfo.Value;
            _Log.DebugToConsole = DebugToConsole.Value;
            SvgColor.Init();
            KoikatuAPI.Quitting += OnGameExit;
        }

        private void Start()
        {
#if KKS
            HPointInfo.Init();
            MakerInfo.Init();
#endif
            HProcMonitor.Init();
            SceneManager.sceneLoaded += HProcMonitor.SceneLoaded;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Game exit event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void OnGameExit(object sender, EventArgs e)
        {
            _Log.Info($"[OnGameExit] Exiting game.");
            // Close special log file.
            Logg.Close();
        }
        #endregion
    }
}
