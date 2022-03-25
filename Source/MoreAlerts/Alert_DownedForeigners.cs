using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_DownedForeigners : Alert_Custom_Pawns
{
    public Alert_DownedForeigners() : base(Potentials())
    {
        defaultPriority = AlertPriority.Critical;
        defaultLabel = "downed foreigners";
        defaultExplanation = "There are downed foreigners!";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_Spawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (!p.Downed)
        {
            return false;
        }

        if (p.AnimalOrWildMan() && !p.HostileTo(Faction.OfPlayer))
        {
            return false;
        }

        if (p.IsPrisonerOfColony && p.guest.PrisonerIsSecure)
        {
            return false;
        }

        if (p.guest.HostFaction == Faction.OfPlayer && p.InBed())
        {
            return false;
        }

        if (p.Faction != null && p.Faction != Faction.OfPlayer)
        {
            return true;
        }

        return false;
    }
}