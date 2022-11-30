using System.Collections.Generic;
using System.Text;

using UnityEngine;
using MessagePack;

using H;

using HarmonyLib;


namespace IDHIUtils
{
#if KKS
    public partial class HPointInfo
    {
        #region classes
        public class Hooks
        {
            /// <summary>
            /// Retrieve information for the HPointData on the map during HScene
            /// </summary>
            /// <param name="__instance">Instance of HSceneProc</param>
            [HarmonyPostfix]
            [HarmonyPatch(typeof(HSceneProc), nameof(HSceneProc.GetCloseCategory))]
            private static void GetCloseCategoryPostfix(object __instance)
            {
                _hProcObject = __instance;
                _hProcTraverse = Traverse.Create(__instance);
                _closeHPointData = _hProcTraverse
                    .Field<List<HPointData>>("closeHpointData").Value;
                InitialPositon =
                    _hProcTraverse.Field<Vector3>("nowHpointDataPos").Value;
                InitialPositionName =
                    _hProcTraverse.Field<string>("nowHpointData").Value;

                _hPointDataPosition.Clear();
                _hPointDataName.Clear();

                foreach (var hpointData in _closeHPointData)
                {
                    _hPointDataPosition[hpointData.transform.position] = hpointData;
                    _hPointDataName[hpointData.name] = hpointData;
                }
#if DEBUG
                LogHPointDataInfo();
#endif
            }
        }
        #endregion

        #region private Fields
        private static Dictionary<Vector3, HPointData> _hPointDataPosition = new();
        private static Dictionary<string, HPointData> _hPointDataName = new();
        private static object _hProcObject = null;
        private static Traverse _hProcTraverse = null;
        private static List<HPointData> _closeHPointData;
        #endregion

        #region Properties
        public static Dictionary<Vector3, HPointData> HPointByPosition
        {
            get
            {
                if (!HProcMonitor.Nakadashi)
                {
                    return null;
                }
                return _hPointDataPosition;
            }
        }
        public static Dictionary<string, HPointData> HPointByName
        {
            get
            {
                if (!HProcMonitor.Nakadashi)
                {
                    return null;
                }
                return _hPointDataName;
            }
        }
        public static Vector3 InitialPositon { get; private set; }
        public static string InitialPositionName { get; private set; }
        #endregion

#if DEBUG
        private static void LogHPointDataInfo()
        {
            var lines = new StringBuilder();
            lines.Clear();

            foreach (var hpointData in _closeHPointData)
            {
                lines.Append($"Name: {hpointData.name} " +
                    $"position={hpointData.transform.position} " +
                    $"rotation={hpointData.transform.rotation} " +
                    $"angles={hpointData.transform.eulerAngles} " +
                    $"backup position={hpointData.backupPos} ");
                lines.Append($"categorys=" +
                    $"{Utilities.CategoryList(hpointData.category, names: true)}\n");
            }
            Utilities._Log.Info($"\n\nHPointData:\n{lines}\n");
        }
#endif
        public static void Init()
        {
            _ = Harmony.CreateAndPatchAll(typeof(Hooks));
        }
    }
#endif
}
