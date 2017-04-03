using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_PawnHot : Alert_Custom_FreeColonistsAndPrisonersSpawned
    {

        public Alert_PawnHot()
        {
            this.defaultLabel = "hot pawns";
            this.defaultExplanation = "Some pawns are hot!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            float maxComfortTemp = p.ComfortableTemperatureRange().max;
            float curTemp = 999;
            GenTemperature.TryGetAirTemperatureAroundThing(p, out curTemp);
            if (curTemp > maxComfortTemp)
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
