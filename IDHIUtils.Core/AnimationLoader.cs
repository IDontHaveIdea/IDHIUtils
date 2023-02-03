//
// AnimationLoader
//
using System;
using System.Collections.Generic;

using UnityEngine;

//using static IDHIUtils.Utilities;

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

        public Dictionary<string, Dictionary<int, Dictionary<string, int>>>
            GetExpAddTaii()
        {
            var _alDicExpAddTaii = Traverse
                    .Field<Dictionary<string,
                        Dictionary<int,
                        Dictionary<string, int>>>>("_alDicExpAddTaii").Value;
            return _alDicExpAddTaii;
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

        public List<Vector3> GetAnimationMovement(HSceneProc.AnimationListInfo anim)
        {
            if (!Installed)
            {
                return null;
            }

            return Traverse.Method("GetAnimationMovement",
                new Type[] { typeof(HSceneProc.AnimationListInfo) })?
                .GetValue<List<Vector3>>(anim);
        }

        public void LoadTestXml()
        {
            if (!Installed)
            {
                return;
            }

            Traverse.Method("LoadTestXml", new Type[] { })?.GetValue();
        }
    }
}
