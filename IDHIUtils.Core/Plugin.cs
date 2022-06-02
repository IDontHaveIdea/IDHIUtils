//
// Utilities
//

using System;

using KKAPI;
using UnityEngine.SceneManagement;

namespace IDHIUtils
{
    /// <summary>
    /// Initializations needed for the utilities
    ///     SvgColor - initialize lookup table
    ///     HProcMonitor - initialize hooks and register to ScreenManager event sceneLoaded
    /// </summary>
    public partial class Utilities
    {
        internal static Logg _Log = new();

        private void Awake()
        {
            _Log.LogSource = base.Logger;
#if DEBUG
            _Log.Enabled = true;
#endif
            SvgColor.Init();
            KoikatuAPI.Quitting += OnGameExit;
        }

        private void Start()
        {
            HProcMonitor.Init();
            SceneManager.sceneLoaded += HProcMonitor.SceneLoaded;
        }

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


    }
}
