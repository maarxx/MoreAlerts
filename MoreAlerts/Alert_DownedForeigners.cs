using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MoreAlerts
{
    class Alert_DownedForeigners : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_Spawned; });
            return pots;
        }

        public Alert_DownedForeigners() : base(Potentials())
        {
            this.defaultPriority = AlertPriority.Critical;
            this.defaultLabel = "downed foreigners";
            this.defaultExplanation = "There are downed foreigners!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.Downed)
            {
                if (p.AnimalOrWildMan() && !p.HostileTo(Faction.OfPlayer)) { return false; }
                if (p.IsPrisonerOfColony && p.guest.PrisonerIsSecure) { return false; }
                if ((p.guest.HostFaction == Faction.OfPlayer) && p.InBed()) { return false; }
                if (p.Faction != null && p.Faction != Faction.OfPlayer) { return true; }
            }
            return false;
        }
    }
}
