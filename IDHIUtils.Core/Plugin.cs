using BepInEx;


namespace IDHIUtils
{
    /// <summary>
    /// </summary>
    /// <remarks>
    ///
    ///
    /// </remarks>
    public partial class Utilities : BaseUnityPlugin
    {
        private void Awake()
        {
            Log.SetLogSource(base.Logger);
        }
    }
}
