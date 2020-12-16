using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_PrisonerEscaping : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_PrisonersOfColonySpawned; });
            return pots;
        }

        public Alert_PrisonerEscaping() : base(Potentials())
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "escaping prisoners";
            this.defaultExplanation = "There are prisoners escaping!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.RaceProps.Humanlike && p.IsPrisonerOfColony && !p.guest.PrisonerIsSecure)
            {
                return true;
            }
            return false;
        }

    }
}
