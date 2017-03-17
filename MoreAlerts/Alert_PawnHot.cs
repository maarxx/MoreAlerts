using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_PawnHot : Alert
    {

        List<Pawn> hotPawns;

        int lastTick;

        public Alert_PawnHot()
        {
            this.defaultLabel = "X hot pawns";
            this.defaultExplanation = "Some pawns are hot!";
            this.hotPawns = new List<Pawn>();
            this.lastTick = 0;
        }

        public override AlertReport GetReport()
        {
            GetHotPawns();
            return this.hotPawns.FirstOrDefault();
        }

        public override string GetLabel()
        {
            GetHotPawns();
            return "" + hotPawns.Count() + " hot pawns";
        }

        public override string GetExplanation()
        {
            GetHotPawns();
            return base.GetExplanation();
        }

        private void GetHotPawns()
        {

            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            else
            {
                hotPawns = new List<Pawn>();
                foreach (Pawn p in PawnsFinder.AllMaps_FreeColonistsAndPrisonersSpawned)
                {
                    float maxComfortTemp = p.ComfortableTemperatureRange().max;
                    float curTemp = -999;
                    GenTemperature.TryGetAirTemperatureAroundThing(p, out curTemp);
                    if (curTemp > maxComfortTemp)
                    {
                        hotPawns.Add(p);
                    }
                }
            }
            
        }
    }
}
