using System.Collections.Generic;


namespace IDHIUtils
{
    /// <summary>
    /// Scene helpers
    /// </summary>
    public partial class Utilities
    {
        /// <summary>
        /// Get name of active scene 
        /// </summary>
        /// <returns></returns>
        public static string GetActiveScene()
        {
            return $"{Manager.Scene.ActiveScene.name}";
        }

        /// <summary>
        /// Get overlay scene (dialogs, and stuff ...).
        /// </summary>
        public static string GetOverlaySceneName()
        {
#if KK
            return Manager.Scene.Instance.AddSceneName;
#else
            return Manager.Scene.AddSceneName;
#endif
        }
    }
}
