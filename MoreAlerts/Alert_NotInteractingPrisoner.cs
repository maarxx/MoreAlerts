using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_NotInteractingPrisoner : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_PrisonersOfColonySpawned; });
            return pots;
        }

        public Alert_NotInteractingPrisoner() : base(Potentials())
        {
            this.defaultLabel = "prisoners not interacting";
            this.defaultExplanation = "Some prisoners aren't being interacted!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            PrisonerInteractionModeDef pim = p.guest.interactionMode;
            if (pim == PrisonerInteractionModeDefOf.NoInteraction)
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
