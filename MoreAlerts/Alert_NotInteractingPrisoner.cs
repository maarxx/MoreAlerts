using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_NotInteractingPrisoner : Alert_Custom_PrisonersOfColonySpawned
    {

        public Alert_NotInteractingPrisoner()
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
