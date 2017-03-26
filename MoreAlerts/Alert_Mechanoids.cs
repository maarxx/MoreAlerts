using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_Mechanoids : Alert_Custom_Spawned
    {

        public Alert_Mechanoids()
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "mechanoids";
            this.defaultExplanation = "There are mechanoids!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.Label.Contains("Mechanoid"))
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
