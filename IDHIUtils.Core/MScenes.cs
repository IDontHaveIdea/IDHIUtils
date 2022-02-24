using System.Collections.Generic;


namespace IDHIUtils
{
    static public class MScenes
    {
        //
        // TODO: KK versions
        // For KK properties change they are not static.
        //

        /// <summary>
        /// Get name of active scene ()
        /// </summary>
        /// <returns></returns>
        static public string GetActiveScene()
        {
            return $"{Manager.Scene.ActiveScene.name}";
        }

        /// <summary>
        /// True screen is fading in/out
        /// </summary>
        static public bool GetIsFadeNow()
        {
#if KK
            return Manager.Scene.Instance.IsFadeNow;
#else
            return Manager.Scene.IsFadeNow;
#endif
        }

        /// <summary>
        /// True loading screen displayed
        /// </summary>
        static public bool GetIsNowLoading()
        {
#if KKS
            return Manager.Scene.IsNowLoading;
#else
            return Manager.Scene.Instance.IsNowLoading;
#endif
        }

        /// <summary>
        /// True loading screen displayed or screen is fading in/out.
        /// </summary>
        static public bool GetIsNowLoadingFade()
        {
#if KK
            return Manager.Scene.Instance.IsNowLoadingFade;
#else
            return Manager.Scene.IsNowLoadingFade;
#endif
        }

        /// <summary>
        /// Scene names on the stack.
        /// </summary>
        /// <returns></returns>
        static public List<string> GetNowSceneNames()
        {
#if KKS
            return Manager.Scene.NowSceneNames;
#else
            return Manager.Scene.Instance.NowSceneNames;
#endif
        }

        /// <summary>
        /// True an overlay screen is on.
        /// </summary>
        static public bool GetIsOverlap()
        {
#if KK
            return Manager.Scene.Instance.IsOverlap;
#else
            return Manager.Scene.IsOverlap;
#endif
        }

        /// <summary>
        /// Get loaded scene (action, h, maker, ...).
        /// </summary>
        static public string GetLoadedSceneName()
        {
#if KKS
            return Manager.Scene.LoadSceneName;
#else
            return Manager.Scene.Instance.LoadSceneName;
#endif
        }

        /// <summary>
        /// Get overlay scene (configuration, exit game, dialogs, ...).
        /// </summary>
        static public string GetOverlaySceneName()
        {
#if KK
            return Manager.Scene.Instance.AddSceneName;
#else
            return Manager.Scene.AddSceneName;
#endif
        }
    }
}
