using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_SleptInHeat : Alert_Custom_Pawns
{
    public Alert_SleptInHeat() : base(Potentials())
    {
        defaultLabel = "Slept in Heat";
        defaultExplanation = "Colonist slept in heat.";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>>
        {
            () => PawnsFinder.AllMaps_FreeColonistsAndPrisonersSpawned
        };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        var thoughts = new List<Thought>();
        p.needs.mood.thoughts.GetAllMoodThoughts(thoughts);
        foreach (var t in thoughts)
        {
            if (t.def == ThoughtDefOf.SleptInHeat)
            {
                return true;
            }
        }

        if (!p.Awake() && p.AmbientTemperature > p.def.GetStatValueAbstract(StatDefOf.ComfyTemperatureMax))
        {
            return true;
        }

        return false;
    }
}