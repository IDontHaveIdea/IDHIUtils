using System.Reflection;

using IDHIUtils;

#region Assembly attributes

/*
 * These attributes define various meta-information of the generated DLL.
 * In general, you don't need to touch these. Instead, edit the values in Info.
 */
[assembly: AssemblyTitle(Constants.Prefix + "_" + PInfo.PluginName + " (" + PInfo.GUID + ")")]
[assembly: AssemblyProduct(Constants.Prefix + "_" + PInfo.PluginName)]
[assembly: AssemblyVersion(PInfo.Version)]
[assembly: AssemblyFileVersion(PInfo.Version)]

#endregion Assembly attributes

//
// Login ID: 0001
//


namespace IDHIUtils
{
    public struct PInfo
    {
        public const string GUID = "com.ihavenoidea.idhiutils";
        public const string Version = "0.0.1.0";
#if DEBUG
        public const string PluginDisplayName = "IDHI Utilities (Debug)";
#else
        public const string PluginDisplayName = "IDHI Utilities";
#endif
        public const string PluginName = "IDHIUtils";
    }
}
