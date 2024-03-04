//
// KKS entry point
//
// Ignore Spelling: Utils

using BepInEx;

using KKAPI;


namespace IDHIUtils
{
    [BepInDependency(KoikatuAPI.GUID, KoikatuAPI.VersionConst)]
    [BepInPlugin(IDHIUtilsInfo.GUID, IDHIUtilsInfo.PlugInName, IDHIUtilsInfo.Version)]
    [BepInProcess(KoikatuAPI.GameProcessName)]
    [BepInProcess(KoikatuAPI.VRProcessName)]
    public partial class Utilities : BaseUnityPlugin
    {
    }
}
