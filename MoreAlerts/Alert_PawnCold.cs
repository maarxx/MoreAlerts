using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_PawnCold : Alert_Custom_FreeColonistsAndPrisonersSpawned
    {

        public Alert_PawnCold()
        {
            this.defaultLabel = "cold pawns";
            this.defaultExplanation = "Some pawns are cold!";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            float minComfortTemp = p.ComfortableTemperatureRange().min;
            float curTemp = -999;
            GenTemperature.TryGetAirTemperatureAroundThing(p, out curTemp);
            if (curTemp < minComfortTemp)
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
