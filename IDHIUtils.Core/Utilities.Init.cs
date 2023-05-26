//
// Utilities
//
// Ignore Spelling: Utils


namespace IDHIUtils
{
    /// <summary>
    /// Utilities that should be generic for plug-ins
    /// </summary>
    ///
    public partial class Utilities
    {
        public static void Init()
        {
#if KKS
            HPointInfo.Init();
            MakerInfo.Init();
            Maps.Init();
#endif
            HProcMonitor.Init();
        }
    }
}
