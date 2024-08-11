//
// Utilities.Scene
// At it happens I think this is in KKAPI
// TODO: Check if they are in KKAPI

using UnityEngine.SceneManagement;


namespace IDHIUtils
{
    /// <summary>
    /// Scene helpers
    /// </summary>
    public partial class Utilities
    {
        #region Static Methods
        /// <summary>
        /// Get name of active scene 
        /// </summary>
        /// <returns></returns>
        public static string GetActiveScene()
        {
            return $"{SceneManager.GetActiveScene()}";
        }

        /// <summary>
        /// Get name of active scene 
        /// </summary>
        /// <returns></returns>
        public static string GetActiveSceneName()
        {
            return $"{SceneManager.GetActiveScene().name}";
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

        /// <summary>
        /// Get Loaded scene
        /// </summary>
        /// <returns></returns>
        public static string GetLoadSceneName()
        {
#if KKS
            return Manager.Scene.LoadSceneName;
#else
            return Manager.Scene.Instance.LoadSceneName;
#endif
        }
        #endregion
    }
}
