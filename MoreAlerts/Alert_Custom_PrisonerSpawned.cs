using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    abstract class Alert_Custom_PrisonersOfColonySpawned : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_PrisonersOfColonySpawned; });
            return pots;
        }
        public Alert_Custom_PrisonersOfColonySpawned() : base(Potentials())
        {
            //
        }
    }
}
