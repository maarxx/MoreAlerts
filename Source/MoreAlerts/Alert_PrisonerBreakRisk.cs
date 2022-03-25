using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_PrisonerBreakRisk : Alert_Custom_Pawns
{
    public Alert_PrisonerBreakRisk() : base(Potentials())
    {
        defaultPriority = AlertPriority.Critical;
        defaultLabel = "prisoner break risk";
        defaultExplanation = "Some prisoners are break risk.";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_PrisonersOfColonySpawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (!(p.needs.mood.CurLevel < p.mindState.mentalBreaker.BreakThresholdExtreme) &&
            !(p.needs.mood.CurInstantLevel < p.mindState.mentalBreaker.BreakThresholdExtreme))
        {
            return false;
        }

        if (pawnCanMove(p))
        {
            return true;
        }

        return false;
    }

    private bool pawnCanMove(Pawn p)
    {
        return p.health.capacities.CanBeAwake
               && p.health.capacities.CapableOf(PawnCapacityDefOf.Moving)
               && !p.health.InPainShock;
    }
}