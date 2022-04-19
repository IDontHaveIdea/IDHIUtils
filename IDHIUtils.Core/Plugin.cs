//
// Utilities
//

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
        }

        private void Start()
        {
            HProcMonitor.Init();
            SceneManager.sceneLoaded += HProcMonitor.SceneLoaded;
        }

    }
}
