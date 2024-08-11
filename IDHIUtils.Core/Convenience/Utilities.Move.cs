//
// Utilities
//
// Ignore Spelling: Utils cha

using UnityEngine;


namespace IDHIUtils
{
    /// <summary>
    /// Utilities that should be generic for plug-ins
    /// </summary>
    ///
    public partial class Utilities
    {
#if KKS
        public static Vector3? HSceneMove(HSceneProc h, ChaControl chaControl, Vector3 move)
        {
            var currentPosition = new Vector3(0, 0, 0);

            var hScene = GameObject.FindObjectOfType<HSceneProc>();
            if (hScene == null)
            {
                // Inside H Scene
                return null;
            }

            var originalPosition = h.nowHpointDataPos;

            //return false;

            return currentPosition;
        }
#endif
    }
}
