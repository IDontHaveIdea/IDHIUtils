//
// KK
//
// Ignore Spelling: Utils

using BepInEx;

using KKAPI;


namespace IDHIUtils
{
    [BepInDependency(KoikatuAPI.GUID, KoikatuAPI.VersionConst)]
    [BepInPlugin(IDHIUtilsInfo.GUID, IDHIUtilsInfo.PluginName, IDHIUtilsInfo.Version)]
    [BepInProcess(KoikatuAPI.GameProcessName)]
    [BepInProcess(KoikatuAPI.GameProcessNameSteam)]
    public partial class Utilities : BaseUnityPlugin
    {
    }
}
