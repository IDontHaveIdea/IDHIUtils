//
// KK
//
using BepInEx;

using KKAPI;


namespace IDHIUtils
{
    [BepInDependency(KoikatuAPI.GUID, KoikatuAPI.VersionConst)]
    [BepInPlugin(PInfo.GUID, PInfo.PluginName, PInfo.Version)]
    [BepInProcess(KoikatuAPI.GameProcessName)]
    [BepInProcess(KoikatuAPI.GameProcessNameSteam)]
    public partial class Utilities
    {
    }
}
