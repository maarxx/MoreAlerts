using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MoreAlerts
{
    class Alert_DownedForeigners : Alert_Custom_Spawned
    {

        public Alert_DownedForeigners()
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
                if (p.Faction != null && p.Faction != Faction.OfPlayer) { return true; }
            }
            return false;
        }
    }
}
