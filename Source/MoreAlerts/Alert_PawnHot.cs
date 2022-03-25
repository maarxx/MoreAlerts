using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_PawnHot : Alert_Custom_Pawns
{
    public Alert_PawnHot() : base(Potentials())
    {
        defaultLabel = "hot pawns";
        defaultExplanation = "Some pawns are hot!";
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
        var maxComfortTemp = p.ComfortableTemperatureRange().max;
        GenTemperature.TryGetAirTemperatureAroundThing(p, out var curTemp);
        if (curTemp > maxComfortTemp)
        {
            return true;
        }

        return false;
    }
}