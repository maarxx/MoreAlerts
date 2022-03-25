using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_UnusedResourcePermits : Alert_Custom_Pawns
{
    public Alert_UnusedResourcePermits() : base(Potentials())
    {
        defaultPriority = AlertPriority.Medium;
        defaultLabel = "unused resource permits";
        defaultExplanation = "Some colonists have unused resource drop permits.";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_FreeColonistsSpawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (!p.royalty.HasAidPermit || p.IsQuestLodger())
        {
            return false;
        }

        foreach (var permit in p.royalty.AllFactionPermits)
        {
            if (permit.OnCooldown)
            {
                continue;
            }

            if (permit.Permit.defName == "SteelDrop")
            {
                return true;
            }

            if (permit.Permit.defName == "FoodDrop")
            {
                return true;
            }

            if (permit.Permit.defName == "SilverDrop")
            {
                return true;
            }

            if (permit.Permit.defName == "GlitterMedDrop")
            {
                return true;
            }
        }

        return false;
    }
}