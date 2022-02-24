using BepInEx;
using KKAPI;


namespace IDHIUtils
{
    [BepInDependency(KoikatuAPI.GUID, KoikatuAPI.VersionConst)]
    [BepInPlugin(PInfo.GUID, PInfo.PluginName, PInfo.Version)]
    [BepInProcess(KoikatuAPI.GameProcessName)]
    public partial class Utilities
    {
    }
}
