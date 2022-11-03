using System;
using System.Collections.Generic;

using ActionGame;

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
        private static Vector3 _initVector = new(9999, 9999, 9999);
        private Traverse _traverse;
        private object _instance;

        private AnimatorLayerCtrl _alCtrl;
        private AnimatorLayerCtrl _alCtrl1;
        private List<int> _categorys;
        private List<int> _useCategorys;
        private RuntimeAnimatorController _changeRac;
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
        private Vector3 _nowHpointDataPos = _initVector;
        private string _nowHpointData;
        private YureCtrl _yure;
        private YureCtrl _yure1;
        private YureCtrl _yureMale;
        private HandCtrl _hand;
        private HandCtrl _hand1;
        private ItemObject _item;
        private SiruPasteCtrl _siru;
        private SiruPasteCtrl _siru1;
        private ParentObjectCtrl _parentObjectFemale;
        private ParentObjectCtrl _parentObjectFemale1;
        private ParentObjectCtrl _parentObjectMale;
        private HSeCtrl _se1;
        private DynamicBoneReferenceCtrl _dynamicCtrl;
        private DynamicBoneReferenceCtrl _dynamicCtrl1;
        private bool _bChangePoint;
        private bool _actYukaTaii;
        private bool _changeTaii;
        private HSprite _sprite;
        private ShuffleRand[] _voicePlayShuffle;
        private Traverse _CheckExpAddTaii;
        private Traverse _CheckShopAdd;
        private Traverse _SetLocalPosition;
        private Traverse _SetBoneOffset;
        private Traverse _CalcParameter;
#if KKS
        private ObiCtrl _ctrlObi;
        private HMotionEyeNeckFemale _eyeneckFemale;
        private HMotionEyeNeckFemale _eyeneckFemale1;
        private HMotionEyeNeckMale _eyeneckMale;
        private HMotionEyeNeckMale _eyeneckMale1;
#endif
        #endregion

        #region Properties
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
        public Traverse TCheckExpAddTaii
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
        public Traverse TCheckShopAdd
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
        public Traverse TSetLocalPosition
        {
            get
            {
                if (_SetLocalPosition == null)
                {
                    _SetLocalPosition = Traverse
                        .Method("SetLocalPosition",
                            new Type[] { typeof(AnimationListInfo) });

                }
                return _SetLocalPosition;
            }
        }
        public Traverse TSetBoneOffset
        {
            get
            {
                if (_SetBoneOffset == null)
                {
                    _SetBoneOffset = Traverse
                        .Method("SetBoneOffset",
                            new Type[] { typeof(AnimationListInfo), typeof(AnimationListInfo) });
                }
                return _SetBoneOffset;
            }
        }
        public Traverse TCalcParameter
        {
            get
            {
                if (_CalcParameter == null)
                {
                    _CalcParameter = Traverse
                        .Method("CalcParameter",
                            new Type[] { typeof(HScene.AddParameter) });
                }
                return _CalcParameter;
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
                if (_nowHpointDataPos == _initVector)
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
        public YureCtrl yure
        {
            get
            {
                if (_yure == null)
                {
                    _yure = Traverse
                        .Field<YureCtrl>("yure").Value;
                }
                return _yure;
            }
        }
        public YureCtrl yure1
        {
            get
            {
                if (_yure1 == null)
                {
                    _yure1 = Traverse
                        .Field<YureCtrl>("yure1").Value;
                }
                return _yure1;
            }
        }
        public YureCtrl yureMale
        {
            get
            {
                if (_yureMale == null)
                {
                    _yureMale = Traverse
                        .Field<YureCtrl>("yureMale").Value;
                }
                return _yureMale;
            }
        }
        public HandCtrl hand
        {
            get
            {
                if (_hand == null)
                {
                    _hand = Traverse
                    .Field<HandCtrl>("hand").Value;
                }
                return _hand;
            }
        }
        public HandCtrl hand1
        {
            get
            {
                if (_hand1 == null)
                {
                    _hand1 = Traverse
                    .Field<HandCtrl>("hand1").Value;
                }
                return _hand1;
            }
        }
        public ItemObject item
        {
            get
            {
                if (_item == null)
                {
                    _item = Traverse
                        .Field<ItemObject>("item").Value;
                }
                return _item;
            }
        }
        public SiruPasteCtrl siru
        {
            get
            {
                if (_siru == null)
                {
                    _siru = Traverse
                        .Field<SiruPasteCtrl>("siru").Value;
                }
                return _siru;
            }
        }
        public SiruPasteCtrl siru1
        {
            get
            {
                if (_siru1 == null)
                {
                    _siru1 = Traverse
                        .Field<SiruPasteCtrl>("siru1").Value;
                }
                return _siru1;
            }
        }
        public ParentObjectCtrl parentObjectFemale
        {
            get
            {
                if (_parentObjectFemale == null)
                {
                    _parentObjectFemale = Traverse
                        .Field<ParentObjectCtrl>("parentObjectFemale").Value;
                }
                return _parentObjectFemale;
            }
        }
        public ParentObjectCtrl parentObjectFemale1
        {
            get
            {
                if (_parentObjectFemale1 == null)
                {
                    _parentObjectFemale1 = Traverse
                        .Field<ParentObjectCtrl>("parentObjectFemale1").Value;
                }
                return _parentObjectFemale1;
            }
        }
        public ParentObjectCtrl parentObjectMale
        {
            get
            {
                if (_parentObjectMale == null)
                {
                    _parentObjectMale = Traverse
                        .Field<ParentObjectCtrl>("parentObjectMale").Value;
                }
                return _parentObjectMale;
            }
        }
        public HSeCtrl se1
        {
            get
            {
                if (_se1 == null)
                {
                    _se1 = Traverse
                        .Field<HSeCtrl>("se1").Value;
                }
                return _se1;
            }
        }
        public DynamicBoneReferenceCtrl dynamicCtrl
        {
            get
            {
                if (_dynamicCtrl == null)
                {
                    _dynamicCtrl = Traverse
                        .Field<DynamicBoneReferenceCtrl>("dynamicCtrl").Value;
                }
                return _dynamicCtrl;
            }
        }
        public DynamicBoneReferenceCtrl dynamicCtrl1
        {
            get
            {
                if (_dynamicCtrl1 == null)
                {
                    _dynamicCtrl1 = Traverse
                        .Field<DynamicBoneReferenceCtrl>("dynamicCtrl1").Value;
                }
                return _dynamicCtrl1;
            }
        }
        public bool bChangePoint
        {
            get
            {
                _bChangePoint = Traverse
                    .Field<bool>("bChangePoint").Value;
                return _bChangePoint;
            }
        }
        public bool actYukaTaii
        {
            get
            {
                _actYukaTaii = Traverse
                    .Field<bool>("actYukaTaii").Value;
                return _actYukaTaii;
            }
        }
        public bool changeTaii
        {
            get
            {
                _changeTaii = Traverse
                    .Field<bool>("changeTaii").Value;
                return _changeTaii;
            }
        }
        public HSprite sprite
        {
            get
            {
                if (_sprite == null)
                {
                    _sprite = Traverse
                        .Field<HSprite>("sprite").Value;
                }
                return _sprite;
            }
        }
        public ShuffleRand[] voicePlayShuffle
        {
            get
            {
                if (_voicePlayShuffle == null)
                {
                    _voicePlayShuffle = Traverse
                        .Field<ShuffleRand[]>("voicePlayShuffle").Value;
                }
                return _voicePlayShuffle;
            }
        }
#if KKS
        public ObiCtrl ctrlObi
        {
            get
            {
                if (_ctrlObi == null)
                {
                    _ctrlObi = Traverse
                    .Field<ObiCtrl>("ctrlObi").Value;
                }
                return _ctrlObi;
            }
        }
        public HMotionEyeNeckFemale eyeneckFemale
        {
            get
            {
                if (_eyeneckFemale == null)
                {
                    _eyeneckFemale = Traverse
                        .Field<HMotionEyeNeckFemale>("eyeneckFemale").Value;
                }
                return _eyeneckFemale;
            }
        }
        public HMotionEyeNeckFemale eyeneckFemale1
        {
            get
            {
                if (_eyeneckFemale1 == null)
                {
                    _eyeneckFemale1 = Traverse
                        .Field<HMotionEyeNeckFemale>("eyeneckFemale1").Value;
                }
                return _eyeneckFemale;
            }
        }
        public HMotionEyeNeckMale eyeneckMale
        {
            get
            {
                if (_eyeneckMale == null)
                {
                    _eyeneckMale = Traverse
                        .Field<HMotionEyeNeckMale>("eyeneckMale").Value;
                }
                return _eyeneckMale;
            }
        }
        public HMotionEyeNeckMale eyeneckMale1
        {
            get
            {
                if (_eyeneckMale1 == null)
                {
                    _eyeneckMale1 = Traverse
                        .Field<HMotionEyeNeckMale>("eyeneckMale1").Value;
                }
                return _eyeneckMale1;
            }
        }

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
        public bool SetLocalPosition(AnimationListInfo _info)
        {
            var result = TSetLocalPosition.GetValue<bool>(_info);
            return result;
        }
        public void SetBoneOffset(AnimationListInfo now, AnimationListInfo next)
        {
            TSetBoneOffset.GetValue(now, next);
        }
        public void CalckParameter(HScene.AddParameter add)
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
