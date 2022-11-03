//
// KKS entry point
//
using BepInEx;

using KKAPI;


namespace IDHIUtils
{
    [BepInDependency(KoikatuAPI.GUID, KoikatuAPI.VersionConst)]
    [BepInPlugin(
        IDHIUtils.Info.GUID,
        IDHIUtils.Info.PluginName,
        IDHIUtils.Info.Version)]
    [BepInProcess(KoikatuAPI.GameProcessName)]
    [BepInProcess(KoikatuAPI.VRProcessName)]
    public partial class Utilities : BaseUnityPlugin
    {
    }
}
