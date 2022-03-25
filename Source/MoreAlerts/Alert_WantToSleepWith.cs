using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_WantToSleepWith : Alert_Custom_Pawns
{
    public Alert_WantToSleepWith() : base(Potentials())
    {
        defaultLabel = "want to sleep with";
        defaultExplanation = "Some colonists want to sleep with others.";
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
            if (t.def.defName == "WantToSleepWithSpouseOrLover")
            {
                return true;
            }
        }

        return false;
    }
}