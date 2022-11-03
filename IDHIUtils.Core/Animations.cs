using System.Collections.Generic;

using HarmonyLib;

namespace IDHIUtils
{
    public partial class Utilities
    {
        #region Static Methods
        /// <summary>
        /// Count all animations for every category
        /// </summary>
        /// <param name="lstAnimInfo"></param>
        /// <returns></returns>
        public static int CountAnimations(
            List<HSceneProc.AnimationListInfo>[] lstAnimInfo)
        {
            var count = 0;

            foreach (var c in lstAnimInfo)
            {
                count += c.Count;
            }
            return count;
        }

        /// <summary>
        /// Get experience needed for position
        /// </summary>
        /// <param name="hsceneProc"></param>
        /// <param name="mode"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetExpTaii(object hsceneProc, int mode, int id)
        {
            var hsceneTraverse = Traverse.Create(hsceneProc);
            var dicExpAddTaii = hsceneTraverse
                .Field<Dictionary<int, Dictionary<int, int>>>("dicExpAddTaii").Value;

            if (dicExpAddTaii.ContainsKey(mode) && dicExpAddTaii[mode].ContainsKey(id))
            {
                return dicExpAddTaii[mode][id];
            }
            return 0;
        }
        #endregion
    }
}
