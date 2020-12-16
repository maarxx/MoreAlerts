using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_Insects : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_Spawned; });
            return pots;
        }

        public Alert_Insects() : base (Potentials())
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "insects";
            this.defaultExplanation = "There are insects!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.Faction != null && p.Faction.def == FactionDefOf.Insect && !p.Downed)
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
