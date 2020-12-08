using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_PrisonerBreakRisk : Alert_Custom_PrisonersOfColonySpawned
    {

        public Alert_PrisonerBreakRisk()
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "prisoner break risk";
            this.defaultExplanation = "Some prisoners are break risk.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.needs.mood.CurLevel < p.mindState.mentalBreaker.BreakThresholdExtreme ||
                p.needs.mood.CurInstantLevel < p.mindState.mentalBreaker.BreakThresholdExtreme)
            {
                if (pawnCanMove(p))
                {
                    return true;
                }
            }
            return false;
        }

        private bool pawnCanMove(Pawn p)
        {
            return p.health.capacities.CanBeAwake
                   && p.health.capacities.CapableOf(PawnCapacityDefOf.Moving)
                   && !p.health.InPainShock;
        }
    }
}
