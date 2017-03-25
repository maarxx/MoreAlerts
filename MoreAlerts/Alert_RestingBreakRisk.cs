using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_RestingBreakRisk : Alert_Custom_FreeColonistsSpawned
    {

        public Alert_RestingBreakRisk()
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "resting break risk";
            this.defaultExplanation = "Some colonists are resting and break risk.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.CurJob.def.reportString == "lying down." && !(p.needs.rest.GUIChangeArrow > 0) && p.needs.rest.CurLevel > 0.75F)
            {
                if (p.needs.mood.CurLevel < p.mindState.mentalBreaker.BreakThresholdMinor)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
