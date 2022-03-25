using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_Insects : Alert_Custom_Pawns
{
    public Alert_Insects() : base(Potentials())
    {
        defaultPriority = AlertPriority.Critical;
        defaultLabel = "insects";
        defaultExplanation = "There are insects!";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_Spawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (p.Faction != null && p.Faction.def == FactionDefOf.Insect && !p.Downed)
        {
            return true;
        }

        return false;
    }
}