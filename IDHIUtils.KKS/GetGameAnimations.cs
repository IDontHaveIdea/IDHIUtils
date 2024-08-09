//
// GetGameAnimations.cs
//

using System;
using System.Collections.Generic;
using System.Text;


namespace IDHIUtils
{
    public partial class Utilities
    {
        public static void GetGameAnimations(out List<HSceneProc.AnimationListInfo>[] lstAnimimationsInfo)
        {
            lstAnimimationsInfo = new List<HSceneProc.AnimationListInfo>[8];

            var lstAssetBundleName = CommonLib.GetAssetBundleNameListFromPath("h/list/");
            lstAssetBundleName.Sort();

            if (lstAssetBundleName.Count > 0)
            {
                var prefix = "AnimationInfo_";
                var strTmp = new StringBuilder();
                for (var index1 = 0; index1 < lstAnimimationsInfo.Length; ++index1)
                {
                    lstAnimimationsInfo[index1] = [];

                    strTmp.Clear();
                    strTmp.Append(prefix).AppendFormat("{0:00}", (object)index1);
                    foreach (var assetBundleName in lstAssetBundleName)
                    {
                        if (AssetBundleCheck.IsFile(assetBundleName, strTmp.ToString())
                            && (AssetBundleCheck.IsSimulation
                                || HFlag.BundleCheck(assetBundleName, strTmp.ToString())))
                        {
                            var animationInfoData =
                                CommonLib.LoadAsset<AnimationInfoData>(
                                    assetBundleName,
                                    strTmp.ToString(),
                                    check: false);
                            AssetBundleManager.UnloadAssetBundle(assetBundleName, true);
                            if (animationInfoData != null)
                            {
                                foreach (var animationInfo in animationInfoData.param)
                                {
                                    var param = animationInfo;
                                    var animationListInfo =
                                        lstAnimimationsInfo[index1]
                                            .Find(
                                                (Predicate<HSceneProc.AnimationListInfo>)
                                                    (l => l.id == param.id));
                                    if (animationListInfo == null)
                                    {
                                        lstAnimimationsInfo[index1].Add(new HSceneProc.AnimationListInfo());
                                        animationListInfo = lstAnimimationsInfo[index1][lstAnimimationsInfo[index1].Count - 1];
                                    }

                                    animationListInfo.nameAnimation = param.nameAnimation;
                                    animationListInfo.id = param.id;
                                    animationListInfo.mode = (HFlag.EMode)index1;
                                    animationListInfo.lstCategory.Clear();
                                    animationListInfo.lstCategory.AddRange(param.lstCategory);
                                    animationListInfo.posture = param.posture;
                                    animationListInfo.kindHoushi = param.kindHoushi;
                                    animationListInfo.isExperience = param.isExperience;
                                    animationListInfo.pathMapObjectNull.assetpath = param.pathMapObjectNull.assetpath;
                                    animationListInfo.pathMapObjectNull.file = param.pathMapObjectNull.file;
                                    animationListInfo.useDesk = param.useDesk;
                                    animationListInfo.useChair = param.useChair;

                                    animationListInfo.pathMaleBase.assetpath = param.pathMaleBase.assetpath;
                                    animationListInfo.pathMaleBase.file = param.pathMaleBase.file;

                                    var paramMale1 = animationListInfo.paramMale;
                                    var paramMale2 = param.paramMale;
                                    paramMale1.lstIdLayer.Clear();
                                    paramMale1.lstIdLayer.AddRange((IEnumerable<int>)paramMale2.lstIdLayer);
                                    paramMale1.path.assetpath = paramMale2.path.assetpath;
                                    paramMale1.path.file = paramMale2.path.file;
                                    paramMale1.isHitObject = paramMale2.isHitObject;
                                    paramMale1.fileHit = paramMale2.fileHit;
                                    paramMale1.fileHitObject = paramMale2.fileHitObject;
                                    paramMale1.fileLookAt = paramMale2.fileLookAt;
                                    paramMale1.fileMotionNeck = paramMale2.fileMotionNeck;
                                    paramMale1.fileMetaballCtrl = paramMale2.fileMetaballCtrl;
                                    paramMale1.fileCondomCtrl = paramMale2.fileCondomCtrl;

                                    animationListInfo.pathFemaleBase.assetpath = param.pathFemaleBase.assetpath;
                                    animationListInfo.pathFemaleBase.file = param.pathFemaleBase.file;

                                    var paramFemale1 = animationListInfo.paramFemale;
                                    var paramFemale2 = param.paramFemale;
                                    paramFemale1.lstIdLayer.Clear();
                                    paramFemale1.lstIdLayer.AddRange((IEnumerable<int>)paramFemale2.lstIdLayer);
                                    paramFemale1.lstFrontAndBehind.Clear();
                                    paramFemale1.lstFrontAndBehind.AddRange((IEnumerable<int>)paramFemale2.lstFrontAndBehind);
                                    paramFemale1.path.assetpath = paramFemale2.path.assetpath;
                                    paramFemale1.path.file = paramFemale2.path.file;
                                    paramFemale1.isHitObject = paramFemale2.isHitObject;
                                    paramFemale1.fileHit = paramFemale2.fileHit;
                                    paramFemale1.fileHitObject = paramFemale2.fileHitObject;
                                    paramFemale1.isYure = paramFemale2.isYure;
                                    paramFemale1.fileYure = paramFemale2.fileYure;
                                    paramFemale1.fileDynamicBoneRef = paramFemale2.fileDynamicBoneRef;
                                    paramFemale1.fileMotionNeck = paramFemale2.fileMotionNeck;
                                    paramFemale1.fileSe = paramFemale2.fileSe;
                                    paramFemale1.fileSiruPaste = paramFemale2.fileSiruPaste;
                                    paramFemale1.fileAibuEnableMotion = paramFemale2.fileAibuEnableMotion;
                                    paramFemale1.fileReaction = paramFemale2.fileReaction;
                                    paramFemale1.fileItem = paramFemale2.fileItem;
                                    paramFemale1.isAnal = paramFemale2.isAnal;
                                    paramFemale1.nameCamera = paramFemale2.nameCamera;

                                    animationListInfo.numCtrl = param.numCtrl;
                                    animationListInfo.sysTaii = param.sysTaii;
                                    animationListInfo.nameCameraIdle = param.nameCameraIdle;
                                    animationListInfo.nameCameraKiss = param.nameCameraKiss;
                                    animationListInfo.lstAibuSpecialItem.Clear();
                                    animationListInfo.lstAibuSpecialItem.AddRange((IEnumerable<int>)param.lstAibuSpecialItem);
                                    animationListInfo.isFemaleInitiative = param.isFemaleInitiative;
                                    animationListInfo.houshiLoopActionW = param.houshiLoopActionW;
                                    animationListInfo.houshiLoopActionS = param.houshiLoopActionS;
                                    animationListInfo.isSplash = param.isSplash;
                                    animationListInfo.numMainVoiceID = param.numMainVoiceID;
                                    animationListInfo.numSubVoiceID = param.numSubVoiceID;
                                    animationListInfo.numVoiceKindID = param.numVoiceKindID;
                                    animationListInfo.numMaleSon = param.numMaleSon;
                                    animationListInfo.numFemaleUpperCloth = param.numFemaleUpperCloth;
                                    animationListInfo.numFemaleLowerCloth = param.numFemaleLowerCloth;
                                    animationListInfo.isRelease = param.isRelease;
                                    animationListInfo.stateRestriction = param.stateRestriction;

                                    if (param.exsitSecondInfo)
                                    {
                                        animationListInfo.pathFemaleBase1.assetpath = param.pathSecondChar.assetpath;
                                        animationListInfo.pathFemaleBase1.file = param.pathSecondChar.file;
                                        var paramFemale1_1 = animationListInfo.paramFemale1;
                                        var paramSecondChar = param.paramSecondChar;
                                        paramFemale1_1.lstIdLayer.Clear();
                                        paramFemale1_1.lstIdLayer.AddRange((IEnumerable<int>)paramSecondChar.lstIdLayer);
                                        paramFemale1_1.lstFrontAndBehind.Clear();
                                        paramFemale1_1.lstFrontAndBehind.AddRange((IEnumerable<int>)paramSecondChar.lstFrontAndBehind);
                                        paramFemale1_1.path.assetpath = paramSecondChar.path.assetpath;
                                        paramFemale1_1.path.file = paramSecondChar.path.file;
                                        paramFemale1_1.isHitObject = paramSecondChar.isHitObject;
                                        paramFemale1_1.fileHit = paramSecondChar.fileHit;
                                        paramFemale1_1.fileHitObject = paramSecondChar.fileHitObject;
                                        paramFemale1_1.isYure = paramSecondChar.isYure;
                                        paramFemale1_1.fileYure = paramSecondChar.fileYure;
                                        paramFemale1_1.fileDynamicBoneRef = paramSecondChar.fileDynamicBoneRef;
                                        paramFemale1_1.fileMotionNeck = paramSecondChar.fileMotionNeck;
                                        paramFemale1_1.fileSe = paramSecondChar.fileSe;
                                        paramFemale1_1.fileSiruPaste = paramSecondChar.fileSiruPaste;
                                        paramFemale1_1.fileAibuEnableMotion = paramSecondChar.fileAibuEnableMotion;
                                        paramFemale1_1.fileReaction = paramSecondChar.fileReaction;
                                        paramFemale1_1.fileItem = paramSecondChar.fileItem;
                                        paramFemale1_1.isAnal = paramSecondChar.isAnal;

                                        animationListInfo.numFemaleUpperCloth1 = param.numFemaleUpperCloth1;
                                        animationListInfo.numFemaleLowerCloth1 = param.numFemaleLowerCloth1;

                                        animationListInfo.mainHoushi3PShortVoicePtns = new int[4];
                                        for (var index2 = 0; index2 < param.mainHoushi3PShortVoicePtns.Length; ++index2)
                                        {
                                            animationListInfo.mainHoushi3PShortVoicePtns[index2] = param.mainHoushi3PShortVoicePtns[index2];
                                        }

                                        animationListInfo.subHoushi3PShortVoicePtns = new int[4];
                                        for (var index3 = 0; index3 < param.subHoushi3PShortVoicePtns.Length; ++index3)
                                        {
                                            animationListInfo.subHoushi3PShortVoicePtns[index3] = param.subHoushi3PShortVoicePtns[index3];
                                        }
                                    }
                                }
                            }
                            else
                            {
                                _Log.Error($"[Utilities.GetGameAnimations] Failed to get any data.");
                            }
                        }
                    }
                }
            }
        }
    }
}
