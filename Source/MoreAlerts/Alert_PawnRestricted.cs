using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_PawnRestricted : Alert_Custom_Pawns
{
    public Alert_PawnRestricted() : base(Potentials())
    {
        defaultLabel = "restricted pawns";
        defaultExplanation = "Some pawns are restricted!";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_FreeColonistsSpawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        var area = p.playerSettings.AreaRestriction;
        if (area != null && area.Label != "Joy" && area.Label != "Medi" && area.Label != "ToxicH")
        {
            return true;
        }

        return false;
    }
}