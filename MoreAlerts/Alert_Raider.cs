using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_Raider : Alert_Custom_Spawned
    {

        public Alert_Raider()
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "raiders";
            this.defaultExplanation = "There are raiders!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.RaceProps.Humanlike && p.Faction.HostileTo(Faction.OfPlayer))
            {
                return true;
            }
            return false;
        }
    }
}
