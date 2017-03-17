using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_PawnRestricted : Alert
    {

        List<Pawn> restrictedPawns;

        int lastTick;

        public Alert_PawnRestricted()
        {
            this.defaultLabel = "X restricted pawns";
            this.defaultExplanation = "Some pawns are restricted!";
            this.restrictedPawns = new List<Pawn>();
            this.lastTick = 0;
        }

        public override AlertReport GetReport()
        {
            GetRestrictedPawns();
            return this.restrictedPawns.FirstOrDefault();
        }

        public override string GetLabel()
        {
            GetRestrictedPawns();
            return "" + restrictedPawns.Count() + " restricted pawns";
        }

        public override string GetExplanation()
        {
            GetRestrictedPawns();
            return base.GetExplanation();
        }

        private void GetRestrictedPawns()
        {

            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            else
            {
                restrictedPawns = new List<Pawn>();
                foreach (Pawn p in PawnsFinder.AllMaps_FreeColonistsSpawned)
                {
                    Area_Allowed area = (Area_Allowed) p.playerSettings.AreaRestriction;
                    if (area != null && area.Label != "Psyche" && area.Label != "ToxicH")
                    {
                        restrictedPawns.Add(p);
                    }
                }
                lastTick = curTick;
            }

        }
    }
}
