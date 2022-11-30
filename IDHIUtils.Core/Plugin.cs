//
// Utilities
//

using System;

using UnityEngine.SceneManagement;

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
#if DEBUG
            _Log.Enabled = true;
#endif
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
