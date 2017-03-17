using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_PawnCold : Alert
    {

        List<Pawn> coldPawns;

        int lastTick;

        public Alert_PawnCold()
        {
            this.defaultLabel = "X cold pawns";
            this.defaultExplanation = "Some pawns are cold!";
            this.coldPawns = new List<Pawn>();
            this.lastTick = 0;
        }

        public override AlertReport GetReport()
        {
            GetColdPawns();
            return this.coldPawns.FirstOrDefault();
        }

        public override string GetLabel()
        {
            GetColdPawns();
            return "" + coldPawns.Count() + " cold pawns";
        }

        public override string GetExplanation()
        {
            GetColdPawns();
            return base.GetExplanation();
        }

        private void GetColdPawns()
        {

            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            else
            {
                coldPawns = new List<Pawn>();
                foreach (Pawn p in PawnsFinder.AllMaps_FreeColonistsAndPrisonersSpawned)
                {
                    float minComfortTemp = p.ComfortableTemperatureRange().min;
                    float curTemp = -999;
                    GenTemperature.TryGetAirTemperatureAroundThing(p, out curTemp);
                    if (curTemp < minComfortTemp)
                    {
                        coldPawns.Add(p);
                    }
                }
                lastTick = curTick;
            }

        }
    }
}
