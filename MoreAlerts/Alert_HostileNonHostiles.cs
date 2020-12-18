using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MoreAlerts
{
    class Alert_HostileNonHostiles : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_Spawned; });
            return pots;
        }

        public Alert_HostileNonHostiles() : base(Potentials())
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "hostiles";
            this.defaultExplanation = "There are hostile things that typically aren't!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.Faction != null && p.Faction.HostileTo(Faction.OfPlayer))
            {
                return false;
            }
            else
            {
                if (p.HostileTo(Faction.OfPlayer))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
