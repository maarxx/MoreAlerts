using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_Raider_Rocket : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_Spawned; });
            return pots;
        }

        public Alert_Raider_Rocket() : base(Potentials())
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
