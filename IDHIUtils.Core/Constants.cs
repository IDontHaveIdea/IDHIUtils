//
// Constants
//
using System.Collections.Generic;

namespace IDHIUtils
{
    public static class Constants
    {
#if KK
        public const string Prefix = "KK";
#elif KKS
        public const string Prefix = "KKS";
#endif
    }

    public enum PositionCategory
    {
        LieDown = 0,
        Stand = 1,
        SitChair = 2,
        BacklessChair = 3,
        SofaBench = 4,
        BacklessBench = 5,
        SchoolDesk = 6,
        Desk = 7,
        Wall = 8,
        StandPool = 9,
        SitDesk = 10,
        SquadDesk = 11,
        Pool = 1004,
        MischievousCaress = 1003,
        Ground3P = 1100,
        AquariumCrowded = 1304,
    }

    public enum ErogenousZone
    {
        None = -1,
        Lips = 0,
        Chest = 1,
        Crotch = 2,
        Anus = 3,
        Butt = 4,
        Nipples = 5
    }
}
