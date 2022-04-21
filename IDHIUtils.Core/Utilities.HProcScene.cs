using System;
using System.Collections.Generic;
using System.Text;

using HarmonyLib;

using BepInEx;

using KKAPI.Utilities;
using ActionGame;
using Manager;

namespace IDHIUtils
{
    /// <summary>
    /// Utilities that should be generic for plug-ins
    /// </summary>
    ///
    public partial class Utilities
    {
        public class HProcSceneUtil
        {
            //internal HSceneProc _hprocInstance;
            internal object _instanceObject;

            internal HFlag _flag;
            internal List<SaveData.Heroine> _heroine;
            internal ActionMap _map;
            internal SaveData.Player _player;
            internal Traverse _traverse;

            public Traverse Traverse
            {
                get
                {
                    if (_traverse == null)
                    {
                        if (_instanceObject != null)
                        {
                            _traverse = Traverse.Create(_instanceObject);
                        }
                    }
                    return _traverse; ;
                }
            }

            public HFlag Flag => _flag;
            public List<SaveData.Heroine> Heroine => _heroine;
            public ActionMap Map => _map;
            public SaveData.Player Player => _player;



            public HProcSceneUtil()
            {
            }

            public HProcSceneUtil(object hprocScene)
            {
                _instanceObject = hprocScene;
                Helper();
            }

            internal void Helper()
            {
                //_hprocInstance = (HSceneProc)_instanceObject;
                _traverse = Traverse.Create(_instanceObject);

                _flag = _traverse.Field<HFlag>("flags").Value;
                _heroine = _flag.lstHeroine;
                _player = _flag.player;
                _map = _traverse.Field<ActionMap>("map").Value;

                /*
                var dicExpAddTaii = _traverse.Field<Dictionary<int, Dictionary<int, int>>>("dicExpAddTaii").Value;
                var lstUseAnimInfo = _traverse.Field<List<HSceneProc.AnimationListInfo>[]>("lstUseAnimInfo").Value;
                var categorys = _traverse.Field<List<int>>("categorys").Value;
                var useCategorys = _traverse.Field<List<int>>("useCategorys").Value;
                var lstAnimInfo = _traverse.Field<List<HSceneProc.AnimationListInfo>[]>("lstAnimInfo").Value;
                //var lstUseAnimInfo = new List<HSceneProc.AnimationListInfo>[8];

                var checkExpAddTaii = _traverse.Method("CheckExpAddTaii", new Type[] { typeof(int), typeof(int), typeof(float) });
                var checkShopAdd = _traverse.Method("CheckShopAdd", new Type[] { typeof(HashSet<int>), typeof(int), typeof(int) });
                */
            }
        }
    }
}
