﻿//
// KKS entry point
//
using BepInEx;
using KKAPI;


namespace IDHIUtils
{
    [BepInDependency(KoikatuAPI.GUID, KoikatuAPI.VersionConst)]
    [BepInPlugin(GUID, PluginName, Version)]
    [BepInProcess(KoikatuAPI.GameProcessName)]
    public partial class Utilities : BaseUnityPlugin
    {
    }
}
