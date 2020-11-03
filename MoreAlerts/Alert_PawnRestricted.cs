using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_PawnRestricted : Alert_Custom_FreeColonistsSpawned
    {

        public Alert_PawnRestricted()
        {
            this.defaultLabel = "restricted pawns";
            this.defaultExplanation = "Some pawns are restricted!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            Area area = p.playerSettings.AreaRestriction;
            if (area != null && area.Label != "Joy" && area.Label != "Medi" && area.Label != "ToxicH")
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
