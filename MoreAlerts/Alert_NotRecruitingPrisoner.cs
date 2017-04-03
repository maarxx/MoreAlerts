using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_NotRecruitingPrisoner : Alert_Custom_PrisonersOfColonySpawned
    {

        public Alert_NotRecruitingPrisoner()
        {
            this.defaultLabel = "prisoners not recruiting";
            this.defaultExplanation = "Some prisoners aren't being recruited!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            PrisonerInteractionMode pim = p.guest.interactionMode;
            if (pim == PrisonerInteractionMode.NoInteraction || pim == PrisonerInteractionMode.Chat)
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
