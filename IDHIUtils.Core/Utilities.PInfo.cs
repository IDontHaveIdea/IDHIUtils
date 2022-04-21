using System;
using System.Collections.Generic;
using System.Text;

using HarmonyLib;

using BepInEx;

using KKAPI.Utilities;

namespace IDHIUtils
{
    /// <summary>
    /// Utilities that should be generic for plug-ins
    /// </summary>
    ///
    public partial class Utilities
    {
        public class PInfo
        {
            private PluginInfo _pluginInfo;
            private string _pluginGUID;
            private Traverse _traverse;

            public BaseUnityPlugin Instance => _pluginInfo?.Instance;

            public Version Version => _pluginInfo?.Metadata?.Version;

            public Traverse Traverse
            {
                get
                {
                    if(_traverse == null)
                    {
                        if (Instance != null)
                        {
                            _traverse = Traverse.Create(Instance);
                        }
                    }
                    return _traverse; ;
                }
            }

            public string GUID {
                get
                {
                    // return _pluginGUID != null ? _pluginGUID : null;
                    return _pluginGUID ?? null;
                }

                set
                {
                    if (_pluginGUID != value)
                    {
                        _pluginGUID = value;
                        _traverse = null;
                        GetPluginInfo();
                    }
                }
            }

            public PInfo()
            {
                _pluginGUID = "";
                _pluginInfo = null;
                _traverse = null;
            }

            public PInfo(string gID)
            {
                _pluginGUID = gID;
                _traverse = null;
                GetPluginInfo();
            }

            private void GetPluginInfo()
            {
                BepInEx.Bootstrap.Chainloader.PluginInfos.TryGetValue(_pluginGUID, out var PInfo);
                _pluginInfo = PInfo;
            }

            public bool VersionAtLeast(string version)
            {
                if(_pluginInfo == null)
                {
                    return false;
                }

                return _pluginInfo.Metadata.Version.CompareTo(new Version(version)) > -1;
            }
        }
    }
}
