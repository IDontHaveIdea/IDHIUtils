//
// Extensions
//

using ActionGame.Chara;
using KKAPI.MainGame;

namespace IDHIUtils
{
    public static class UtilsExtensions
    {
        public static int MapNumber(this SaveData.Heroine self)
        {
            var nPC = self.GetNPC();
            if (nPC != null)
            {
                return nPC.mapNo;
            }

            return -1;
        }

        public static int MapNumber(this ChaControl self)
        {
            var heroine = self.GetHeroine();
            if (heroine != null)
            {
                return MapNumber(heroine);
            }

            return -1;
        }
    }
}
