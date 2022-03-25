using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_HostileNonHostiles : Alert_Custom_Pawns
{
    public Alert_HostileNonHostiles() : base(Potentials())
    {
        defaultPriority = AlertPriority.Critical;
        defaultLabel = "hostiles";
        defaultExplanation = "There are hostile things that typically aren't!";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_Spawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (p.Faction != null && p.Faction.HostileTo(Faction.OfPlayer))
        {
            return false;
        }

        if (p.HostileTo(Faction.OfPlayer))
        {
            return true;
        }

        return false;
    }
}