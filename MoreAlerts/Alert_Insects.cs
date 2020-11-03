using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_Insects : Alert_Custom_Spawned
    {

        public Alert_Insects()
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
