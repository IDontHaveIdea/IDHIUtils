﻿//
// HPoint information during the H-Scene
//
// Ignore Spelling: Utils
/*
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

using ActionGame;
using ActionGame.H;
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
                //_hProcObject = __instance;
                _hProcTraverse = Traverse.Create(__instance);
                _closeHPointData = _hProcTraverse
                    .Field<List<HPointData>>("closeHpointData").Value;
                InitialPosition =
                    _hProcTraverse.Field<OpenHData.Data>("dataH").Value.position;
                InitialRotation =
                    _hProcTraverse.Field<OpenHData.Data>("dataH").Value.rotation;
#if KKS
                InitialNowPosition =
                    _hProcTraverse.Field<Vector3>("nowHpointDataPos").Value;
#else
                InitialPosition =
                    _hProcTraverse.Field<OpenHData.Data>("dataH").Value.position;
                InitialPositionName = "HPointBase";
#endif

                _hPointDataPosition.Clear();
                _hPointDataName.Clear();

                foreach (var hPointData in _closeHPointData)
                {
                    _hPointDataPosition[hPointData.transform.position] = hPointData;
                    _hPointDataName[hPointData.name] = hPointData;
                }
                //HPointDataList(__instance);
#if DEBUG
                LogHPointDataInfo(_closeHPointData);
                //LogHPointDataInfo(_lstHPointData);
#endif
            }
        }
#endregion

        #region private Fields
        private static readonly Dictionary<Vector3, HPointData> _hPointDataPosition = new();
        private static readonly Dictionary<string, HPointData> _hPointDataName = new();
        private static Traverse _hProcTraverse = null;
        private static List<HPointData> _closeHPointData;
        private static List<HPointData> _lstHPointData = new();
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
        public static Vector3 InitialPosition { get; private set; }
        public static Vector3 InitialNowPosition { get; private set; }
        public static string InitialPositionName { get; private set; }
        public static Quaternion InitialRotation { get; private set; }
        #endregion

#if DEBUG
        private static void LogHPointDataInfo(List<HPointData> hPointData)
        {
            var lines = new StringBuilder();
            lines.Clear();

            lines.Append($"Initial position name={InitialPositionName} position=" +
                $"{InitialPosition}\n");
            foreach (var hpointData in hPointData)
            {
                lines.Append($"Name: {hpointData.name} " +
                    $"position={hpointData.transform.position} " +
                    $"rotation={hpointData.transform.rotation} " +
                    $"angles={hpointData.transform.eulerAngles} " +
                    $"backup position={hpointData.backupPos} ");
                lines.Append($"categorys=" +
                    $"{Utilities.CategoryList(hpointData.category, names: true)}\n");
            }
            Utilities._Log.Level(BepInEx.Logging.LogLevel.Info, $"\n\nHPointData:\n{lines}\n");
        }
#endif
        public static void Init()
        {
            _ = Harmony.CreateAndPatchAll(typeof(Hooks));
        }

        public static string GetName(Vector3 position)
        {
            var name = "Unknown";

            if (position == InitialPosition)
            {
                return InitialPositionName;
            }

            if (HPointByPosition.TryGetValue(position, out var hPoint))
            {
                return hPoint.name;
            }

            return name;
        }

        public static Vector3 GetPosition(string name)
        {
            var position = new Vector3(-1, -1, -1);

            if (name == InitialPositionName)
            {
                return InitialPosition;
            }

            if (HPointByName.TryGetValue(name, out var hPoint))
            {
                return hPoint.transform.position;
            }
            return position;
        }

        private static void HPointDataList(object __instance)
        {
            #region get needed fields using reflection
            var hSceneTraverse = Traverse.Create(__instance);

            var categorys = hSceneTraverse.Field<List<int>>("categorys").Value;
            var map = hSceneTraverse
                .Field<ActionMap>("map").Value;
            #endregion

            StringBuilder sbTmp = new("HPoint_");

            //if (categorys.Any(c => c >= 1010 && c < 1100)
            //    || categorys.Any(c => c >= 1100 && c < 1200))

            if (categorys.Any(c => c >= 1010 && c < 1200))
            {
                sbTmp.Append("Add_");
            }
            else if (categorys.Any(c => c >= 3000 && c < 4000))
            {
                sbTmp.Append("3P_");
            }

            var gameObjectList =
                GlobalMethod.LoadAllFolder<GameObject>("h/common/",
                    sbTmp.ToString() + map.no.ToString());

            if (gameObjectList == null || gameObjectList.Count == 0)
            {
                return;
            }

            var componentsInChildren = gameObjectList[gameObjectList.Count - 1]
                .GetComponentsInChildren<HPointData>(true);
            var component = gameObjectList[gameObjectList.Count - 1]
                .GetComponent<HPointOmitObject>();
            var hPointDataArray = componentsInChildren;

            for (var index1 = 0; index1 < hPointDataArray.Length; ++index1)
            {
                hPointDataArray[index1].BackUpPosition();
            }

            // Loop through special animations and add any missing
            // special category to the used category list
            //foreach (var hPointData in componentsInChildren.Where(
            //    x => x.category.Any(c => (c == 12) || (c >= 1000 && c < 1999))))

            // Valid area for HPoint
            //float area = flags.HpointSearch * flags.HpointSearch;


            // Loop through regular and special animations
            foreach (var hPointData in componentsInChildren.Where(
                x => x.category.Any(c => (c <= 1099))))
            {
                if (!component.list.Contains(hPointData.gameObject))
                {
                    var category = hPointData.category[0];
                    //float sqrMagnitude =
                    //    (hPointData.transform.position - flags.HpointJudgePos).sqrMagnitude;
                    //if (!(sqrMagnitude > area))
                    //{
                    if (!_lstHPointData.Contains(hPointData))
                        {
                            _lstHPointData.Add(hPointData);
                        }
                    //}
                }
            }
        }
    }
#endif
}
*/
