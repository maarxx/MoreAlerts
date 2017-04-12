using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{

    class Alert_AnimalHunting : Alert_Custom_Spawned
    {

        public Alert_AnimalHunting()
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "animals hunting";
            this.defaultExplanation = "Some animals are hunting you!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.MentalStateDef != null && (p.MentalStateDef.Equals(MentalStateDefOf.Manhunter) || p.MentalStateDef.Equals(MentalStateDefOf.ManhunterPermanent)))
            {
                return true;
            }
            else if (
                    p.jobs != null
                    && p.jobs.curJob != null
                    && p.jobs.curJob.def != null
                    && p.jobs.curJob.def.Equals(JobDefOf.PredatorHunt)
                    && p.jobs.curJob.targetA != null
                    && p.jobs.curJob.targetA.Thing != null
                    && p.jobs.curJob.targetA.Thing.Faction == Faction.OfPlayer
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
