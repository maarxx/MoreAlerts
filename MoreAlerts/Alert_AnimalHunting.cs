using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{

    class Alert_AnimalHunting : Alert_Critical
    {

        List<Pawn> huntingAnimals;

        int lastTick;

        public Alert_AnimalHunting()
        {
            this.defaultLabel = "X animals hunting";
            this.defaultExplanation = "Some animals are hunting you!";
            this.huntingAnimals = new List<Pawn>();
            this.lastTick = 0;
        }

        public override AlertReport GetReport()
        {
            GetHuntingPawns();
            return this.huntingAnimals.FirstOrDefault();
        }

        public override string GetLabel()
        {
            GetHuntingPawns();
            return "" + huntingAnimals.Count() + " animals hunting";
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
                huntingAnimals = new List<Pawn>();
                foreach (Pawn p in PawnsFinder.AllMaps_Spawned)
                {
                    if ( p.MentalStateDef != null && ( p.MentalStateDef.Equals(MentalStateDefOf.Manhunter) || p.MentalStateDef.Equals(MentalStateDefOf.ManhunterPermanent) ) )
                    {
                        huntingAnimals.Add(p);
                    }
                    else
                    {
                        if (p.jobs != null && p.jobs.curJob != null && p.jobs.curJob.def != null && p.jobs.curJob.def.Equals(JobDefOf.PredatorHunt) && p.jobs.curJob.targetA.Thing.Faction == Faction.OfPlayer)
                        {
                            huntingAnimals.Add(p);
                        }
                    }
                }
                lastTick = curTick;
            }
        }

    }
}
