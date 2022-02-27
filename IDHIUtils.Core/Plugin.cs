//
// Utilities
//

namespace IDHIUtils
{
/// <summary>
/// </summary>
/// <remarks>
///
///
/// </remarks>
    public partial class Utilities
    {
        internal Logg _log = new();

        private void Awake()
        {

            _log.LogSource = base.Logger;
            _log.Enabled = true;
            
            // Initialize lookup table
            SvgColor.Init();
        }
    }
}
