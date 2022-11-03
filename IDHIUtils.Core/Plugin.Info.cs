using System.Reflection;

using IDHIUtils;

#region Assembly attributes

/*
 * These attributes define various meta-information of the generated DLL.
 * In general, you don't need to touch these. Instead, edit the values in Info.
 */
[assembly: AssemblyTitle(Constants.Prefix + "_" + Info.PluginName + " (" + Info.GUID + ")")]
[assembly: AssemblyProduct(Constants.Prefix + "_" + Info.PluginName)]
[assembly: AssemblyVersion(Info.Version)]
[assembly: AssemblyFileVersion(Info.Version)]

#endregion Assembly attributes

//
// Login ID: UTIL0001
//


namespace IDHIUtils
{
    public class Info
    {
        #region Public Fields
        public const string GUID = "com.ihavenoidea.idhiutils";
        public const string Version = "1.0.1.1";
#if DEBUG
        public const string PluginDisplayName = "IDHI Utilities (Debug)";
#else
        public const string PluginDisplayName = "IDHI Utilities";
#endif
        public const string PluginName = "IDHIUtils";
        #endregion
    }

    /*public partial class Utilities
    {
        public const string GUID = "com.ihavenoidea.idhiutils";
        public const string Version = "1.0.1.0";
#if DEBUG
        public const string PluginDisplayName = "IDHI Utilities (Debug)";
#else
        public const string PluginDisplayName = "IDHI Utilities";
#endif
        public const string PluginName = "IDHIUtils";
    }*/
}
