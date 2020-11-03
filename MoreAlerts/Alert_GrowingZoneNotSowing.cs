using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_GrowingZoneNotSowing : Alert_Custom
    {
        private int numAffectedZones;
        public Alert_GrowingZoneNotSowing()
        {
            this.defaultLabel = "growing zones disabled";
            this.defaultExplanation = "Some growing zones are not marked to allow sowing.";
            this.numAffectedZones = 0;
        }

        public override AlertReport GetReport()
        {
            GetAffectedThings();
            if (numAffectedZones > 0)
            {
                return true;
            }
            return false;
        }

        public override string GetLabel()
        {
            GetAffectedThings();
            return "" + numAffectedZones + " " + defaultLabel;
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
                this.numAffectedZones = 0;
                foreach (Map map in Find.Maps)
                {
                    foreach (Zone z in map.zoneManager.AllZones)
                    {
                        if (z is Zone_Growing)
                        {
                            Zone_Growing zg = (Zone_Growing)z;
                            if (!zg.allowSow)
                            {
                                this.numAffectedZones++;
                            }
                        }
                    }
                }
                lastTick = curTick;
            }
        }
    }
}
