using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_PawnCold : Alert_Custom_Pawns
{
    public Alert_PawnCold() : base(Potentials())
    {
        defaultLabel = "cold pawns";
        defaultExplanation = "Some pawns are cold!";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>>
        {
            () => PawnsFinder.AllMaps_FreeColonistsAndPrisonersSpawned
        };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        var minComfortTemp = p.ComfortableTemperatureRange().min;
        GenTemperature.TryGetAirTemperatureAroundThing(p, out var curTemp);
        if (curTemp < minComfortTemp)
        {
            return true;
        }

        return false;
    }
}