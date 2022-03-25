using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_Predator : Alert_Custom_Pawns
{
    public Alert_Predator() : base(Potentials())
    {
        defaultPriority = AlertPriority.Medium;
        defaultLabel = "predators";
        defaultExplanation = "There are predators on your map.";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_Spawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (
            p.def.race.predator
            && (
                p.Faction == null
                || p.Faction.HostileTo(Faction.OfPlayer)
            )
        )
        {
            return true;
        }

        return false;
    }
}