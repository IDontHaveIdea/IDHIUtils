//
// Utilities
//

using UnityEngine.SceneManagement;

namespace IDHIUtils
{
/// <summary>
/// </summary>
/// <remarks>
///
///
/// </remarks>
    public partial class Utilities
    {
        static internal Logg _Log = new();

        private void Awake()
        {
            _Log.LogSource = base.Logger;
            _Log.Enabled = true;
            
            // Initialize lookup table
            SvgColor.Init();
        }
        private void Start()
        {
            HProcMonitor.Init();
            SceneManager.sceneLoaded += HProcMonitor.SceneLoaded;
        }

    }
}
