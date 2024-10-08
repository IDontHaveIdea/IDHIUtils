﻿//
// HSceneProcTraverse
//

using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using ActionGame;
using H;

using HarmonyLib;

using UnityEngine;

using static HSceneProc;


namespace IDHIUtils
{
    /// <summary>
    /// HSceneProcTraverse - Class to access HSceneProc fields and methods
    /// through reflection using HarmonyLib Traverse. The class does not
    /// contains definitions for everything. Is updated as needed.
    /// </summary>
    public class HSceneProcTraverse
    {
        #region Private Fields
        private Traverse _traverse;
        private object _instance;
        #endregion

        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        public AnimatorLayerCtrl alCtrl => Traverse
                    .Field<AnimatorLayerCtrl>("alCtrl").Value;
        public AnimatorLayerCtrl alCtrl1 => Traverse
                    .Field<AnimatorLayerCtrl>("alCtrl1").Value;
        public List<int> categorys => Traverse
                    .Field<List<int>>("categorys").Value;
        public List<int> useCategorys => Traverse
                    .Field<List<int>>("useCategorys").Value;
        public RuntimeAnimatorController changeRac => Traverse
                    .Field<RuntimeAnimatorController>("changeRac").Value;
        public Dictionary<int, Dictionary<int, int>> dicExpAddTaii => Traverse
                    .Field<Dictionary<int, Dictionary<int, int>>>("dicExpAddTaii").Value;
        public HFlag flags => Traverse
                    .Field<HFlag>("flags").Value;
        public HitCollisionEnableCtrl hitcollisionFemale => Traverse
                    .Field<HitCollisionEnableCtrl>("hitcollisionFemale").Value;
        public HitCollisionEnableCtrl hitcollisionFemale1 => Traverse
                    .Field<HitCollisionEnableCtrl>("hitcollisionFemale1").Value;
        public HitCollisionEnableCtrl hitcollisionMale => Traverse
                    .Field<HitCollisionEnableCtrl>("hitcollisionMale").Value;
        public Vector3 HpointJudgePos => Traverse
                    .Field<Vector3>("HpointJudgePos").Value;
        public Vector3 initPos => Traverse
                    .Field<Vector3>("initPos").Value;
        public Quaternion initRot => Traverse
                    .Field<Quaternion>("initRot").Value;
        public Lookat_dan lookDan => Traverse
                    .Field<Lookat_dan>("lookDan").Value;
        public Lookat_dan lookDan1 => Traverse
                    .Field<Lookat_dan>("lookDan1").Value;
        public List<AnimationListInfo>[] lstAnimInfo => Traverse
                    .Field<List<HSceneProc.AnimationListInfo>[]>("lstAnimInfo").Value;
        public List<AnimationListInfo>[] lstUseAnimInfo => Traverse
                    .Field<List<HSceneProc.AnimationListInfo>[]>("lstUseAnimInfo").Value;
        public List<ChaControl> lstFemale => Traverse
                    .Field<List<ChaControl>>("lstFemale").Value;
        public List<int> lstInitCategory => Traverse
                    .Field<List<int>>("lstInitCategory").Value;
        public List<MotionIK> lstMotionIK => Traverse
                    .Field<List<MotionIK>>("lstMotionIK").Value;
        public List<HActionBase> lstProc => Traverse
                    .Field<List<HActionBase>>("lstProc").Value;
        public ChaControl male => Traverse
                    .Field<ChaControl>("male").Value;
        public ChaControl male1 => Traverse
                    .Field<ChaControl>("male1").Value;
        public ActionMap map => Traverse
                    .Field<ActionMap>("map").Value;
        public Vector3 nowHpointDataPos => Traverse
                    .Field<Vector3>("nowHpointDataPos").Value;
        public string nowHpointData => Traverse
                    .Field<string>("nowHpointData").Value;
        public YureCtrl yure => Traverse
                    .Field<YureCtrl>("yure").Value;
        public YureCtrl yure1 => Traverse
                    .Field<YureCtrl>("yure1").Value;
        public YureCtrl yureMale => Traverse
                    .Field<YureCtrl>("yureMale").Value;
        public HandCtrl hand => Traverse
                    .Field<HandCtrl>("hand").Value;
        public HandCtrl hand1 => Traverse
                    .Field<HandCtrl>("hand1").Value;
        public ItemObject item => Traverse
                    .Field<ItemObject>("item").Value;
        public SiruPasteCtrl siru => Traverse
                    .Field<SiruPasteCtrl>("siru").Value;
        public SiruPasteCtrl siru1 => Traverse
                    .Field<SiruPasteCtrl>("siru1").Value;
        public ParentObjectCtrl parentObjectFemale => Traverse
                    .Field<ParentObjectCtrl>("parentObjectFemale").Value;
        public ParentObjectCtrl parentObjectFemale1 => Traverse
                    .Field<ParentObjectCtrl>("parentObjectFemale1").Value;
        public ParentObjectCtrl parentObjectMale => Traverse
                    .Field<ParentObjectCtrl>("parentObjectMale").Value;
        public HSeCtrl se1 => Traverse
                    .Field<HSeCtrl>("se1").Value;
        public DynamicBoneReferenceCtrl dynamicCtrl => Traverse
                    .Field<DynamicBoneReferenceCtrl>("dynamicCtrl").Value;
        public DynamicBoneReferenceCtrl dynamicCtrl1 => Traverse
                    .Field<DynamicBoneReferenceCtrl>("dynamicCtrl1").Value;
        public bool bChangePoint => Traverse
                    .Field<bool>("bChangePoint").Value;
        public bool actYukaTaii => Traverse
                    .Field<bool>("actYukaTaii").Value;
        public bool changeTaii => Traverse
                    .Field<bool>("changeTaii").Value;
        public bool closeInitPoint => Traverse
                    .Field<bool>("closeInitPoint").Value;
        public bool useInitPosPoint => Traverse
                    .Field<bool>("useInitPosPoint").Value;
        public HSprite sprite => Traverse
                    .Field<HSprite>("sprite").Value;
        public ShuffleRand[] voicePlayShuffle => Traverse
                    .Field<ShuffleRand[]>("voicePlayShuffle").Value;
#if KKS
        public List<HPointData> closeHpointData => Traverse
                    .Field<List<HPointData>>("closeHpointData").Value;
        public ObiCtrl ctrlObi => Traverse
                    .Field<ObiCtrl>("ctrlObi").Value;
        public HMotionEyeNeckFemale eyeneckFemale => Traverse
                    .Field<HMotionEyeNeckFemale>("eyeneckFemale").Value;
        public HMotionEyeNeckFemale eyeneckFemale1 => Traverse
                    .Field<HMotionEyeNeckFemale>("eyeneckFemale1").Value;
        public HMotionEyeNeckMale eyeneckMale => Traverse
                    .Field<HMotionEyeNeckMale>("eyeneckMale").Value;
        public HMotionEyeNeckMale eyeneckMale1 => Traverse
                    .Field<HMotionEyeNeckMale>("eyeneckMale1").Value;
#endif
#pragma warning restore IDE1006 // Naming Styles

        public object Instance => _instance;
        public Traverse Traverse
        {
            get
            {
                if (_traverse == null)
                {
                    if (Instance != null)
                    {
                        _traverse = Traverse.Create(Instance);
                    }
                }
                return _traverse; ;
            }
        }

        public Traverse TCalcParameter => Traverse
                    .Method("CalcParameter",
                        [typeof(HScene.AddParameter)]);
        public Traverse TCheckExpAddTaii => Traverse
                    .Method("CheckExpAddTaii",
                      [typeof(int), typeof(int), typeof(float)]);
        public Traverse TCheckShopAdd => Traverse
                    .Method("CheckShopAdd",
                        [typeof(HashSet<int>), typeof(int), typeof(int)]);
        public Traverse TIsCategoryInAnimationList => Traverse
                    .Method("IsCategoryInAnimationList",
                        [typeof(int[])]);
        public Traverse TIsExperience => Traverse
                    .Method("IsExperience",
                        [typeof(int)]);
        public Traverse TSetLocalPosition => Traverse
                    .Method("SetLocalPosition",
                        [typeof(AnimationListInfo)]);
        public Traverse TSetCategory => Traverse
                    .Method("SetCategory",
                        [typeof(HPointData), typeof(bool)]);
        public Traverse TSetBoneOffset => Traverse
                    .Method("SetBoneOffset",
                        [typeof(AnimationListInfo), typeof(AnimationListInfo)]);
        #endregion Properties

        #region Constructor
        public HSceneProcTraverse(object instance)
        {
            Helper(instance);
        }
        #endregion

        #region Public Methods
        public bool CheckExpAddTaii(int mode, int id, float exp)
        {
            var result = TCheckExpAddTaii.GetValue<bool>(mode, id, exp);
            return result;
        }

        public bool CheckShopAdd(HashSet<int> buyList, int mode, int id)
        {
            var result = TCheckShopAdd.GetValue<bool>(buyList, mode, id);
            return result;
        }

        public bool IsCategoryInAnimationList(int[] categorys)
        {
            var result = TIsCategoryInAnimationList.GetValue<bool>(categorys);
            return result;
        }

        public bool IsExperience(int experience)
        {
            var result = TIsExperience.GetValue<bool>(experience);
            return result;
        }
        public void SetCategory(HPointData data, bool isSpecial = false)
        {
            TSetCategory.GetValue(data, isSpecial);
        }

        public bool SetLocalPosition(AnimationListInfo _info)
        {
            var result = TSetLocalPosition.GetValue<bool>(_info);
            return result;
        }

        public void SetBoneOffset(AnimationListInfo now, AnimationListInfo next)
        {
            TSetBoneOffset.GetValue(now, next);
        }

        public void CalcParameter(HScene.AddParameter add)
        {
            TCalcParameter.GetValue(add);
        }
        #endregion Methods

        #region Private Methods
        private void Helper(object instance)
        {
            _instance = instance;


            /*
            var SetMapObject = hsceneTraverse
                .Method("SetMapObject",
                    new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) });

            var SetClothStateStartMotion = hsceneTraverse
                .Method("SetClothStateStartMotion",
                    new Type[] { typeof(int) });
            */


        }
        #endregion
    }
}
