using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{

    class Alert_PawnHunting : Alert_Critical
    {

        List<Pawn> huntingPawns;

        int lastTick;

        public Alert_PawnHunting()
        {
            this.defaultLabel = "X hunting pawns";
            this.defaultExplanation = "Some pawns are hunting!";
            this.huntingPawns = new List<Pawn>();
            this.lastTick = 0;
        }

        public override AlertReport GetReport()
        {
            GetHuntingPawns();
            return this.huntingPawns.FirstOrDefault();
        }

        public override string GetLabel()
        {
            GetHuntingPawns();
            return "" + huntingPawns.Count() + " hunting pawns";
        }

        public override string GetExplanation()
        {
            GetHuntingPawns();
            return base.GetExplanation();
        }

        private void GetHuntingPawns()
        {
            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            else
            {
                huntingPawns = new List<Pawn>();
                foreach (Pawn p in PawnsFinder.AllMaps_Spawned)
                {
                    if ( p.MentalStateDef != null && ( p.MentalStateDef.Equals(MentalStateDefOf.Manhunter) || p.MentalStateDef.Equals(MentalStateDefOf.ManhunterPermanent) ) )
                    {
                        huntingPawns.Add(p);
                    }
                    else
                    {
                        if (p.jobs != null && p.jobs.curJob != null && p.jobs.curJob.def != null && p.jobs.curJob.def.Equals(JobDefOf.PredatorHunt) && p.jobs.curJob.targetA.Thing.Faction == Faction.OfPlayer)
                        {
                            huntingPawns.Add(p);
                        }
                    }
                }
                lastTick = curTick;
            }
        }

    }
}
