using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_Raider : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_Spawned; });
            return pots;
        }

        public Alert_Raider() : base(Potentials())
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "raiders";
            this.defaultExplanation = "There are raiders!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.RaceProps.Humanlike && p.Faction.HostileTo(Faction.OfPlayer) && !p.IsPrisonerOfColony)
            {
                return true;
            }
            return false;
        }
    }
}
