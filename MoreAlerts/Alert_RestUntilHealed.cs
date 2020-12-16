using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_RestUntilHealed : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_FreeColonistsSpawned; });
            return pots;
        }

        public Alert_RestUntilHealed() : base(Potentials())
        {
            this.defaultPriority = AlertPriority.Medium;
            this.defaultLabel = "resting until healed";
            this.defaultExplanation = "Some colonists are resting until healed.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.CurJob != null && p.CurJob.def != null && p.CurJob.playerForced && p.CurJob.def.reportString == "lying down.")
            {
                return true;
            }
            return false;
        }

    }
}
