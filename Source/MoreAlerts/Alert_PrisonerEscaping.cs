using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_PrisonerEscaping : Alert_Custom_Pawns
{
    public Alert_PrisonerEscaping() : base(Potentials())
    {
        defaultPriority = AlertPriority.Critical;
        defaultLabel = "escaping prisoners";
        defaultExplanation = "There are prisoners escaping!";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_PrisonersOfColonySpawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (p.RaceProps.Humanlike && p.IsPrisonerOfColony && !p.guest.PrisonerIsSecure)
        {
            return true;
        }

        return false;
    }
}