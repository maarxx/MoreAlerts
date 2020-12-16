using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_PawnCold : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_FreeColonistsAndPrisonersSpawned; });
            return pots;
        }

        public Alert_PawnCold() : base(Potentials())
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
