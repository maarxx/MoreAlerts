using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_ConstrainingClothes : Alert_Custom_Pawns
{
    public Alert_ConstrainingClothes() : base(Potentials())
    {
        defaultLabel = "constraining clothes";
        defaultExplanation = "Some nudists have constraining clothes.";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_FreeColonistsSpawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        var thoughts = new List<Thought>();
        p.needs.mood.thoughts.GetAllMoodThoughts(thoughts);
        foreach (var t in thoughts)
        {
            if (t.def.defName == "ClothedNudist")
            {
                return true;
            }
        }

        return false;
    }
}