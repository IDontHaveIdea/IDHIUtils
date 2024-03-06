// Ignore Spelling: Utils Anim Taii

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
        /// <param name="hSceneProc"></param>
        /// <param name="mode"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetExpTaii(object hSceneProc, int mode, int id)
        {
            var hsceneTraverse = Traverse.Create(hSceneProc);
            var dicExpAddTaii = hsceneTraverse
                .Field<Dictionary<int, Dictionary<int, int>>>("dicExpAddTaii").Value;

            //if (dicExpAddTaii.ContainsKey(mode) && dicExpAddTaii[mode].ContainsKey(id))
            if (dicExpAddTaii.TryGetValue(mode, out var dictMode))
            {
                if (dictMode.TryGetValue(id, out var value))
                {
                    return value;
                }
            }
            return 0;
        }
        #endregion
    }
}
