using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_FireWithoutRain : Alert_Custom
    {

        public Alert_FireWithoutRain()
        {
            this.defaultLabel = "fire on map";
            this.defaultExplanation = "There is fire on the map, without rain!";
            this.defaultPriority = AlertPriority.Critical;
        }

        protected override void GetAffectedThings()
        {
            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            else
            {
                lastTick = curTick;
                foreach (Map map in Find.Maps)
                {
                    this.affectedThings.Clear();
                    if (map.weatherManager.curWeather.rainRate > 0)
                    {
                        return;
                    }
                    else if (map.fireWatcher.FireDanger <= 0)
                    {
                        return;
                    }
                    else
                    {
                        this.affectedThings.AddRange(map.listerThings.ThingsOfDef(ThingDefOf.Fire));
                    }
                }
            }
        }
    }
}
