//
// Plugin.Info.cs
//

using System;
using System.Reflection;

using IDHIUtils;

#region Assembly attributes
/*
 * These attributes define various meta-information of the generated DLL.
 */
[assembly: AssemblyTitle(Constants.Prefix + "_" + IDHIUtilsInfo.PluginName + " (" + IDHIUtilsInfo.GUID + ")")]
[assembly: AssemblyProduct(Constants.Prefix + "_" + IDHIUtilsInfo.PluginName)]
[assembly: AssemblyVersion(IDHIUtilsInfo.Version)]
[assembly: AssemblyFileVersion(IDHIUtilsInfo.Version)]
#endregion Assembly attributes

//
// Login ID: UTIL0001
//


namespace IDHIUtils
{
    [Obsolete("Use IDHIUtilsInfo")]
    public partial class Info
    {
        #region Public Fields
        public const string GUID = "com.ihavenoidea.idhiutils";
        public const string Version = "1.0.4.0";
#if DEBUG
        public const string PluginDisplayName = "IDHI Utilities (Debug)";
#else
        public const string PluginDisplayName = "IDHI Utilities";
#endif
        public const string PluginName = "IDHIUtils";
        #endregion
    }

    public partial class IDHIUtilsInfo
    {
        #region Public Fields
        public const string GUID = "com.ihavenoidea.idhiutils";
        public const string Version = "1.1.0.0";
        public const string LitJSONVersion = "0.20.0.0";
#if DEBUG
        public const string PluginDisplayName = "IDHI Utilities (Debug)";
#else
        public const string PluginDisplayName = "IDHI Utilities";
#endif
        public const string PluginName = "IDHIUtils";
        #endregion
    }

}
