using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_Raider_Rocket : Alert_Custom_Spawned
    {

        public Alert_Raider_Rocket()
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "rockets";
            this.defaultExplanation = "There are raiders with rocket launchers!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.RaceProps.Humanlike && p.Faction.HostileTo(Faction.OfPlayer))
            {
                if (p.equipment != null && p.equipment.Primary != null && ( p.equipment.Primary.def.Equals(ThingDef.Named("Gun_DoomsdayRocket")) || p.equipment.Primary.def.Equals(ThingDef.Named("Gun_TripleRocket")) ) )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
