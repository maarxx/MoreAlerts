using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_PrisonerEscaping : Alert_Custom_PrisonersOfColonySpawned
    {

        public Alert_PrisonerEscaping()
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
