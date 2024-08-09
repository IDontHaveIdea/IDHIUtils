// Ignore Spelling: Utils

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IDHIUtils
{
    public static class Desires
    {
        //private static Game _gameManager;
        
        public static Dictionary<DesireType, int> GetDesires(SaveData.Heroine heroine)
        {
            var actCtrl = SingletonInitializer<ActionScene>.instance.actCtrl;
            Dictionary<DesireType, int> dictDesire = [];

            if (actCtrl != null)
            {
                var sortedDesires = Enum.GetValues(typeof(DesireType)).Cast<DesireType>()
                    .Select(i => new { id = i, value = actCtrl.GetDesire((int)i, heroine) })
                    .Where(x => x.value > 5)
                    .OrderByDescending(x => x.value)
                    .Take(8);

                foreach (var desire in sortedDesires)
                {
                    dictDesire.Add(desire.id, desire.value);
                }

                return dictDesire;
            }

            return null;
        }

        public static void GetDesiresBad(SaveData.Heroine heroine)
        {
            //Console.WriteLine("DESIRE");
            var desireInfo = heroine.desireInfo;
            var data = new StringBuilder();

            if (desireInfo != null)
            {
                foreach (var e in  desireInfo.dicDesire)
                {
                    data.AppendLine($"ID: {e.Key} VALUE: {e.Value.desire}");
                }
            }

        }
    }
}

/*
public void Init()
    {
        dicTarget.Clear();
        foreach (Heroine item in Game.saveData.heroineList.Where((Heroine v) => v.fixCharaID == 0))
        {
            DesireInfo desireInfo = item.desireInfo;
            if (desireInfo == null)
            {
                DesireInfo desireInfo3 = (item.desireInfo = new DesireInfo(dicBaseInfo, dicPersonalityInfo[item.personality], item.clubActivities));
                desireInfo = desireInfo3;
            }
            dicTarget[item] = desireInfo;
        }
    }
 */
