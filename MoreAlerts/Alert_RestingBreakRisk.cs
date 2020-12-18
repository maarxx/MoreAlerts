using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_RestingBreakRisk : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_FreeColonistsSpawned; });
            return pots;
        }

        public Alert_RestingBreakRisk() : base(Potentials())
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "resting break risk";
            this.defaultExplanation = "Some colonists are resting and break risk.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.CurJob != null && p.CurJob.def != null && p.CurJob.def.reportString == "lying down." && !(p.needs.rest.GUIChangeArrow > 0) && p.needs.rest.CurLevel > 0.75F && p.needs.rest.CurLevel < 0.99F)
            {
                if (p.needs.mood.CurLevel < p.mindState.mentalBreaker.BreakThresholdMinor)
                {
                    if (pawnCanMove(p))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool pawnCanMove(Pawn p)
        {
            return p.health.capacities.CanBeAwake
                   && p.health.capacities.GetLevel(PawnCapacityDefOf.Moving) > 0.16F
                   && !p.health.InPainShock;
        }
    }
}
