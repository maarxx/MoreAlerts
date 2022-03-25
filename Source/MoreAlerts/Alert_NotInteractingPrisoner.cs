using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_NotInteractingPrisoner : Alert_Custom_Pawns
{
    public Alert_NotInteractingPrisoner() : base(Potentials())
    {
        defaultLabel = "prisoners not interacting";
        defaultExplanation = "Some prisoners aren't being interacted!";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_PrisonersOfColonySpawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        var pim = p.guest.interactionMode;
        if (pim == PrisonerInteractionModeDefOf.NoInteraction)
        {
            return true;
        }

        return false;
    }
}