//
// Constants many enums from the game for reference
//
using System.Collections.Generic;

namespace IDHIUtils
{
    #region Static Classes
    public static class Constants
    {
#if KK
        public const string Prefix = "KK";
#elif KKS
        public const string Prefix = "KKS";
#endif
    }
    #endregion

    #region enums
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


    public enum HairKind
    {
        back,
        front,
        side,
        option
    }

    public enum ClothesKind
    {
        top,
        bot,
        bra,
        shorts,
        gloves,
        panst,
        socks,
        shoes_inner,
        shoes_outer
    }

    public enum ClothesSubKind
    {
        partsA,
        partsB,
        partsC
    }

    public enum CoordinateType
    {
        Plain,
        Swim,
        Pajamas,
        Bathing
    }

    public enum SiruParts
    {
        SiruKao,
        SiruFrontUp,
        SiruFrontDown,
        SiruBackUp,
        SiruBackDown
    }

    public enum Sex
    {
        Male = 0,
        Female = 1
    }

    public enum BodyShapeIdx
    {
        Height,
        HeadSize,
        NeckW,
        NeckZ,
        BustSize,
        BustY,
        BustRotX,
        BustX,
        BustRotY,
        BustSharp,
        BustForm,
        AreolaBulge,
        NipWeight,
        NipStand,
        BodyShoulderW,
        BodyShoulderZ,
        BodyUpW,
        BodyUpZ,
        BodyLowW,
        BodyLowZ,
        WaistY,
        Belly,
        WaistUpW,
        WaistUpZ,
        WaistLowW,
        WaistLowZ,
        Hip,
        HipRotX,
        ThighUpW,
        ThighUpZ,
        ThighLowW,
        ThighLowZ,
        KneeLowW,
        KneeLowZ,
        Calf,
        AnkleW,
        AnkleZ,
        ShoulderW,
        ShoulderZ,
        ArmUpW,
        ArmUpZ,
        ElbowW,
        ElbowZ,
        ArmLow
    }

    public enum FaceShapeIdx
    {
        FaceBaseW,
        FaceUpZ,
        FaceUpY,
        FaceUpSize,
        FaceLowZ,
        FaceLowW,
        ChinLowY,
        ChinLowZ,
        ChinY,
        ChinW,
        ChinZ,
        ChinTipY,
        ChinTipZ,
        ChinTipW,
        CheekBoneW,
        CheekBoneZ,
        CheekW,
        CheekZ,
        CheekY,
        EyebrowY,
        EyebrowX,
        EyebrowRotZ,
        EyebrowInForm,
        EyebrowOutForm,
        EyelidsUpForm1,
        EyelidsUpForm2,
        EyelidsUpForm3,
        EyelidsLowForm1,
        EyelidsLowForm2,
        EyelidsLowForm3,
        EyeY,
        EyeX,
        EyeZ,
        EyeTilt,
        EyeH,
        EyeW,
        EyeInX,
        EyeOutY,
        NoseTipH,
        NoseY,
        NoseBridgeH,
        MouthY,
        MouthW,
        MouthZ,
        MouthUpForm,
        MouthLowForm,
        MouthCornerForm,
        EarSize,
        EarRotY,
        EarRotZ,
        EarUpForm,
        EarLowForm
    }
    #endregion
}
