using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_Raider : Alert_Custom_Pawns
{
    public Alert_Raider() : base(Potentials())
    {
        defaultPriority = AlertPriority.Critical;
        defaultLabel = "raiders";
        defaultExplanation = "There are raiders!";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_Spawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (p.RaceProps.Humanlike && p.Faction.HostileTo(Faction.OfPlayer) && !p.IsPrisonerOfColony)
        {
            return true;
        }

        return false;
    }
}