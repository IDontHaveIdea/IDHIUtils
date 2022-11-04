//
// AnimationLoader
//
using System;


namespace IDHIUtils
{
    /// <summary>
    /// Class to get animation keys from AnimationLoader through reflection
    /// </summary>
    public class AnimationLoader : Utilities.PInfo
    {
        public AnimationLoader() : base("essuhauled.animationloader")
        {
        }

        public string GetAnimationKey(HSceneProc.AnimationListInfo anim)
        {
            if (!Installed)
            {
                return "";
            }

            return Traverse.Method("GetAnimationKey",
                new Type[] { typeof(HSceneProc.AnimationListInfo) })?
                    .GetValue<string>(anim);
        }
    }
}
