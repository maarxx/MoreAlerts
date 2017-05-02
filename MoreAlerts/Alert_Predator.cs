using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_Predator : Alert_Custom_Spawned
    {

        public Alert_Predator()
        {
            this.defaultPriority = AlertPriority.Medium;
            this.defaultLabel = "predators";
            this.defaultExplanation = "There are predators on your map.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (
                    p.def.race.predator
                    && (
                        p.Faction == null
                        || p.Faction.HostileTo(Faction.OfPlayer)
                        )
                )
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
