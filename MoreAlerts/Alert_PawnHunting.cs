using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{

    class Alert_PawnHunting : Alert
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
                    //if ((p.jobs != null) && (p.jobs.curJob != null) && (p.jobs.curJob.targetA != null) && (p.jobs.curJob.def.reportString == "Melee attacking TargetA.") && (p.jobs.curJob.targetA.Thing.Faction == Faction.OfPlayer))
                    if ((p.jobs != null) && (p.jobs.curJob != null) && (p.jobs.curJob.targetA != null) && (p.jobs.curJob.def.Equals(JobDefOf.AttackMelee)) && (p.jobs.curJob.targetA.Thing.Faction == Faction.OfPlayer))
                    {
                        //Log.Message(p.jobs.curJob.def.reportString);
                        huntingPawns.Add(p);
                    }
                    else
                    {
                        if (p.MentalState.def.Equals(MentalStateDefOf.Manhunter) || p.MentalState.def.Equals(MentalStateDefOf.ManhunterPermanent))
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
