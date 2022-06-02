using System;
using System.Collections.Generic;

using ActionGame;

using HarmonyLib;

using UnityEngine;

using static HSceneProc;


namespace IDHIUtils
{
    public class HSceneProcTraverse
    {
        private static Vector3 initVector = new(9999, 9999, 9999);
        private Traverse _traverse;
        private object _instance;

        private AnimatorLayerCtrl _alCtrl;
        private AnimatorLayerCtrl _alCtrl1;
        private List<int> _categorys;
        private List<int> _useCategorys;
        private RuntimeAnimatorController _changeRac;
        private Traverse _CheckExpAddTaii;
        private Traverse _CheckShopAdd;
        private Dictionary<int, Dictionary<int, int>> _dicExpAddTaii;
        private HFlag _flags;
        private HitCollisionEnableCtrl _hitcollisionFemale;
        private HitCollisionEnableCtrl _hitcollisionFemale1;
        private HitCollisionEnableCtrl _hitcollisionMale;
        private Lookat_dan _lookDan;
        private Lookat_dan _lookDan1;
        private List<AnimationListInfo>[] _lstAnimInfo;
        private List<AnimationListInfo>[] _lstUseAnimInfo;
        private List<ChaControl> _lstFemale;
        private List<MotionIK> _lstMotionIK;
        private List<HActionBase> _lstProc;
        private ChaControl _male;
        private ChaControl _male1;
        private ActionMap _map;
        private Vector3 _nowHpointDataPos = initVector;
        private string _nowHpointData;

#pragma warning disable IDE1006 // Naming Styles
        public AnimatorLayerCtrl alCtrl
        {
            get
            {
                if (_alCtrl == null)
                {
                    _alCtrl = Traverse
                        .Field<AnimatorLayerCtrl>("alCtrl").Value;
                }
                return _alCtrl;
            }
        }
        public AnimatorLayerCtrl alCtrl1
        {
            get
            {
                if (_alCtrl1 == null)
                {
                    _alCtrl1 = Traverse
                        .Field<AnimatorLayerCtrl>("alCtrl1").Value;
                }
                return _alCtrl1;
            }
        }
        public List<int> categorys
        {
            get
            {
                if (_categorys == null)
                {
                    _categorys = Traverse
                        .Field<List<int>>("categorys").Value;
                }
                return _categorys;
            }
        }
        public List<int> useCategorys
        {
            get
            {
                if (_useCategorys == null)
                {
                    _useCategorys = Traverse
                        .Field<List<int>>("useCategorys").Value;
                }
                return _useCategorys;
            }
        }
        public RuntimeAnimatorController changeRac
        {
            get
            {
                if (_changeRac == null)
                {
                    _changeRac = Traverse
                        .Field<RuntimeAnimatorController>("changeRac").Value;

                }
                return _changeRac;
            }
        }
        public Traverse CheckExpAddTaii
        {
            get
            {
                if (_CheckExpAddTaii == null)
                {
                    _CheckExpAddTaii = Traverse
                        .Method("CheckExpAddTaii",
                            new Type[] { typeof(int), typeof(int), typeof(float) });
                }
                return _CheckExpAddTaii;
            }
        }
        public Traverse CheckShopAdd
        {
            get
            {
                if (_CheckShopAdd == null)
                {
                    _CheckShopAdd = Traverse
                        .Method("CheckShopAdd",
                    new Type[] { typeof(HashSet<int>), typeof(int), typeof(int) });
                }
                return _CheckShopAdd;
            }
        }
        public Dictionary<int, Dictionary<int, int>> dicExpAddTaii
        {
            get
            {
                if (_dicExpAddTaii == null)
                {
                    _dicExpAddTaii = Traverse
                        .Field<Dictionary<int, Dictionary<int, int>>>("dicExpAddTaii").Value;
                }
                return _dicExpAddTaii;
            }
        }
        public HFlag flags
        {
            get
            {
                if (_flags == null)
                {
                    _flags = Traverse
                        .Field<HFlag>("flags").Value;
                }
                return _flags;
            }
        }
        public HitCollisionEnableCtrl hitcollisionFemale
        {
            get 
            {
                if (_hitcollisionFemale == null)
                {
                    _hitcollisionFemale = Traverse
                        .Field<HitCollisionEnableCtrl>("hitcollisionFemale").Value;
                }
                return _hitcollisionFemale;
            }
        }
        public HitCollisionEnableCtrl hitcollisionFemale1
        {
            get
            {
                if (_hitcollisionFemale1 == null)
                {
                    _hitcollisionFemale1 = Traverse
                        .Field<HitCollisionEnableCtrl>("hitcollisionFemale1").Value;
                }
                return _hitcollisionFemale1;
            }
        }
        public HitCollisionEnableCtrl hitcollisionMale
        {
            get
            {
                if (_hitcollisionMale == null)
                {
                    _hitcollisionMale = Traverse
                        .Field<HitCollisionEnableCtrl>("hitcollisionMale").Value;
                }
                return _hitcollisionMale;
            }
        }
        public Lookat_dan lookDan
        {
            get
            {
                if (_lookDan == null)
                {
                    _lookDan = Traverse
                        .Field<Lookat_dan>("lookDan").Value;
                }
                return _lookDan;
            }
        }
        public Lookat_dan lookDan1
        {
            get
            {
                if (_lookDan1 == null)
                {
                    _lookDan1 = Traverse
                        .Field<Lookat_dan>("lookDan1").Value;
                }
                return _lookDan1;
            }
        }
        public List<AnimationListInfo>[] lstAnimInfo
        {
            get
            {
                if (_lstAnimInfo == null)
                {
                    _lstAnimInfo = Traverse
                        .Field<List<HSceneProc.AnimationListInfo>[]>("lstAnimInfo").Value;
                }
                return _lstAnimInfo;
            }
        }
        public List<AnimationListInfo>[] lstUseAnimInfo
        {
            get
            {
                if (_lstUseAnimInfo == null)
                {
                    _lstUseAnimInfo = Traverse
                        .Field<List<HSceneProc.AnimationListInfo>[]>("lstUseAnimInfo").Value;
                }
                return _lstUseAnimInfo;
            }
        }
        public List<ChaControl> lstFemale
        {
            get
            {
                if (_lstFemale == null)
                {
                    _lstFemale = Traverse
                        .Field<List<ChaControl>>("lstFemale").Value;

                }
                return _lstFemale;
            }
        }
        public List<MotionIK> lstMotionIK
        {
            get
            {
                if (_lstMotionIK == null)
                {
                    _lstMotionIK = Traverse
                        .Field<List<MotionIK>>("lstMotionIK").Value;
                }
                return _lstMotionIK;
            }
        }
        public List<HActionBase> lstProc
        {
            get
            {
                if (_lstProc == null)
                {
                    _lstProc = Traverse
                        .Field<List<HActionBase>>("lstProc").Value;
                }
                return _lstProc;
            }
        }
        public ChaControl male
        {
            get
            {
                if (_male == null)
                {
                    _male = Traverse
                        .Field<ChaControl>("male").Value;
                }
                return _male;
            }
        }
        public ChaControl male1
        {
            get
            {
                if (_male1 == null)
                {
                    _male1 = Traverse
                        .Field<ChaControl>("male1").Value;
                }
                return _male1;
            }

        }
        public ActionMap map
        {
            get
            {
                if (_map == null)
                {
                    _map = Traverse
                        .Field<ActionMap>("map").Value;

                }
                return _map;
            }
        }
        public Vector3 nowHpointDataPos
        {
            get
            {
                if (_nowHpointDataPos == initVector)
                {
                    _nowHpointDataPos = Traverse
                        .Field<Vector3>("nowHpointDataPos").Value;
                }
                return _nowHpointDataPos;
            }
        }
        public string nowHpointData
        {
            get
            {
                if (_nowHpointData == null)
                {
                    _nowHpointData = Traverse
                        .Field<string>("nowHpointData").Value;
                }
                return _nowHpointData;
            }
        }
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


        public HSceneProcTraverse(object instance)
        {
            Helper(instance);
        }

        private void Helper(object instance)
        {
            _instance = instance;


            /*

            var yure = hsceneTraverse
                .Field<YureCtrl>("yure").Value;
            var yure1 = hsceneTraverse
                .Field<YureCtrl>("yure1").Value;
            var yureMale = hsceneTraverse
                .Field<YureCtrl>("yureMale").Value;

            var hand = hsceneTraverse
                .Field<HandCtrl>("hand").Value;
            var hand1 = hsceneTraverse
                .Field<HandCtrl>("hand1").Value;

            var item = hsceneTraverse
                .Field<ItemObject>("item").Value;

            var ctrlObi = hsceneTraverse
                .Field<ObiCtrl>("ctrlObi").Value;

            var siru = hsceneTraverse
                .Field<SiruPasteCtrl>("siru").Value;
            var siru1 = hsceneTraverse
                .Field<SiruPasteCtrl>("siru1").Value;

            var parentObjectFemale = hsceneTraverse
                .Field<ParentObjectCtrl>("parentObjectFemale").Value;
            var parentObjectFemale1 = hsceneTraverse
                .Field<ParentObjectCtrl>("parentObjectFemale1").Value;
            var parentObjectMale = hsceneTraverse
                .Field<ParentObjectCtrl>("parentObjectMale").Value;

            var eyeneckFemale = hsceneTraverse
                .Field<HMotionEyeNeckFemale>("eyeneckFemale").Value;
            var eyeneckFemale1 = hsceneTraverse
                .Field<HMotionEyeNeckFemale>("eyeneckFemale1").Value;
            var eyeneckMale = hsceneTraverse
                .Field<HMotionEyeNeckMale>("eyeneckMale").Value;
            var eyeneckMale1 = hsceneTraverse
                .Field<HMotionEyeNeckMale>("eyeneckMale1").Value;

            var se1 = hsceneTraverse
                .Field<HSeCtrl>("se1").Value;


            var dynamicCtrl = hsceneTraverse
                .Field<DynamicBoneReferenceCtrl>("dynamicCtrl").Value;
            var dynamicCtrl1 = hsceneTraverse
                .Field<DynamicBoneReferenceCtrl>("dynamicCtrl1").Value;

            var bChangePoint = hsceneTraverse
                .Field<bool>("bChangePoint").Value;

            var actYukaTaii = hsceneTraverse
                .Field<bool>("actYukaTaii").Value;
            var changeTaii = hsceneTraverse
                .Field<bool>("actYukaTaii").Value;

            var sprite = hsceneTraverse
                .Field<HSprite>("sprite").Value;

            var voicePlayShuffle = hsceneTraverse
                .Field<ShuffleRand[]>("voicePlayShuffle").Value;

            var SetLocalPosition = hsceneTraverse
                .Method("SetLocalPosition",
                    new Type[] { typeof(AnimationListInfo) });

            var SetBoneOffset = hsceneTraverse
                .Method("SetBoneOffset",
                    new Type[] { typeof(AnimationListInfo), typeof(AnimationListInfo) });

            var SetMapObject = hsceneTraverse
                .Method("SetMapObject",
                    new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) });

            var SetClothStateStartMotion = hsceneTraverse
                .Method("SetClothStateStartMotion",
                    new Type[] { typeof(int) });
            */


        }
    }
}
