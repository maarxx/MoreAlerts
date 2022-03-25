using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_RestingBreakRisk : Alert_Custom_Pawns
{
    public Alert_RestingBreakRisk() : base(Potentials())
    {
        defaultPriority = AlertPriority.Critical;
        defaultLabel = "resting break risk";
        defaultExplanation = "Some colonists are resting and break risk.";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_FreeColonistsSpawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (p.CurJob is not { def.reportString: "lying down." } || p.needs.rest.GUIChangeArrow > 0 ||
            p.needs.rest.CurLevel is <= 0.75F or >= 0.99F)
        {
            return false;
        }

        if (!(p.needs.mood.CurLevel < p.mindState.mentalBreaker.BreakThresholdMinor))
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
               && p.health.capacities.GetLevel(PawnCapacityDefOf.Moving) > 0.16F
               && !p.health.InPainShock;
    }
}