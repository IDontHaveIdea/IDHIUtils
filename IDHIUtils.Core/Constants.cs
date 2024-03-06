//
// Constants many enums from the game for reference
//
// Ignore Spelling: Utils Siru

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

    #region enum Definitions
    public enum DesireType
    {
        None = -1,
        ChangeClothes = 0,
        GoToToilet = 1,
        TakeShower = 2,
        HaveMeal = 3,
        HMasturbate = 4,
        HWithPlayer = 5,
        DoClubActivities = 6,
        TalkWithGirls = 7,
        TalkWithPlayer = 8,
        Read = 9,
        FiddleWithSmartphone = 10,
        GameOnSmartphone = 11,
        TakeSelfie = 12,
        ListenToMusic = 13,
        DancePractice = 14,
        ImproveMyAppearance = 15,
        Drink = 16,
        ChangeMyMind = 17,
        Exercise = 18,
        CharaSpecificBehavior = 19,
        GetAway = 20,
        Study = 21,
        Sleep = 22,
        FollowMe = 23,
        Request = 24,
        Shy = 25,
        Lesbian = 26,
        LesbianPartner = 27,
        AskPlayerToTalk = 28,
        AskPlayerForH = 29,
        FidgetingWaiting = 30,
        S31 = 31,
        S32 = 32,
        S33 = 33,
        S34 = 34,
        S35 = 35,
        S36 = 36,
        S37 = 38,
        S39 = 39,
        S40 = 40,
        S41 = 41,
        S42 = 42,
        S43 = 43,
        S44 = 44,
        S45 = 45,
        S46 = 46,
        S47 = 47,
        S48 = 48,
        S49 = 49,
        S50 = 50,
        S51 = 51,
        S52 = 52,
        S53 = 53,
        SMasturbate = 54
    }

    public enum HeroineStatus
    {
        Unknown,
        Safe,
        Risky,
        Pregnant,
        OnLeave
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
        BenchBlowjob = 12,
        Bookshelf = 1002,
        MischievousCaress = 1003,
        Pool = 1004,
        Fence = 1006,
        PiledriverMissionary = 1008,
        BoxDoggy = 1009,
        CornerMasturbation = 1010,
        SeatedMasturbation = 1011,
        StandingMasturbation = 1012,
        BedMasturbation = 1014,
        TennisNetMasturbation = 1015,
        Dildo = 1016,
        Rotor = 1017,
        LesbianLieDown = 1100,
        LesbianChair = 1101,
        Groping = 1102,
        StraddleBench = 1200,
        SofaCowgirl = 1201,
        TennisNet = 1300,
        TableTennis = 1301,
        AgainstWall = 1302,
        BananaBoat = 1303,
        Crowded = 1304,
        DeskSquatting = 1305,
        Tub = 1306,
        PoolFloats = 1307,
        ToiletPeeping = 2000,
        ShowerPeeping = 2001,
        ToiletMasturbation = 2003,
        ShowerMasturbation = 2004,
        LieDown3P = 3000,
        Sitting3P = 3001
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
