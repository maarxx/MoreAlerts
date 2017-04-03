using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_RestUntilHealed : Alert_Custom_FreeColonistsSpawned
    {

        public Alert_RestUntilHealed()
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
