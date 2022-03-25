using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_Raider_Rocket : Alert_Custom_Pawns
{
    public Alert_Raider_Rocket() : base(Potentials())
    {
        defaultPriority = AlertPriority.Critical;
        defaultLabel = "rockets";
        defaultExplanation = "There are raiders with rocket launchers!";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_Spawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (!p.RaceProps.Humanlike || !p.Faction.HostileTo(Faction.OfPlayer))
        {
            return false;
        }

        if (p.equipment is { Primary: { } } &&
            (p.equipment.Primary.def.Equals(ThingDef.Named("Gun_DoomsdayRocket")) ||
             p.equipment.Primary.def.Equals(ThingDef.Named("Gun_TripleRocket"))))
        {
            return true;
        }

        return false;
    }
}