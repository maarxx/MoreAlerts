using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_RestUntilHealed : Alert_Custom_Pawns
{
    public Alert_RestUntilHealed() : base(Potentials())
    {
        defaultPriority = AlertPriority.Medium;
        defaultLabel = "resting until healed";
        defaultExplanation = "Some colonists are resting until healed.";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_FreeColonistsSpawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (p.CurJob is { def.reportString: "lying down.", playerForced: true })
        {
            return true;
        }

        return false;
    }
}