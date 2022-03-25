using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_WastingPsychicHelmet : Alert_Custom_Pawns
{
    public Alert_WastingPsychicHelmet() : base(Potentials())
    {
        defaultLabel = "wasting psychic helmets";
        defaultExplanation = "Some colonists are pointlessly wearing psychic helmets.";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_FreeColonistsSpawned };
        return pots;
    }

    private static bool isBadPsychicEvent(Map map)
    {
        if (map.gameConditionManager.ConditionIsActive(GameConditionDefOf.PsychicDrone))
        {
            return true;
        }

        var emanators = map.listerThings.ThingsInGroup(ThingRequestGroup.ConditionCauser); // PROBABLY WRONG
        if (emanators.Any())
        {
            return true;
        }

        return false;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (isBadPsychicEvent(p.Map))
        {
            return false;
        }

        foreach (var a in p.apparel.WornApparel)
        {
            if (a.def.defName == "Apparel_PsychicFoilHelmet")
            {
                return true;
            }
        }

        return false;
    }
}