using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_Building_Damaged : Alert_Custom
{
    public Alert_Building_Damaged()
    {
        defaultPriority = AlertPriority.High;
        defaultLabel = "damaged";
        defaultExplanation = "Some buildings are damaged.";
        affectedThings = new List<Thing>();
    }

    protected override void GetAffectedThings()
    {
        var curTick = Find.TickManager.TicksGame;
        if (lastTick + 10 > curTick)
        {
            return;
        }

        affectedThings = new List<Thing>();
        foreach (var map in Find.Maps)
        {
            foreach (var t in map.listerBuildingsRepairable.RepairableBuildings(Faction.OfPlayer))
            {
                if (t.def.useHitPoints && t.HitPoints < t.MaxHitPoints && Find.CurrentMap.areaManager.Home[t.Position])
                {
                    affectedThings.Add(t);
                }
            }
        }

        SortAffectedThings();
        lastTick = curTick;
    }

    protected override void SortAffectedThings()
    {
        affectedThings.Sort(compareBuildingDamage);
    }

    private static int compareBuildingDamage(Thing p1, Thing p2)
    {
        var b2 = p2 as Building;
        if (p1 is not Building b1)
        {
            return 0;
        }

        var b1p = (float)b1.HitPoints / b1.MaxHitPoints;
        if (b2 == null)
        {
            return 0;
        }

        var b2p = (float)b2.HitPoints / b2.MaxHitPoints;
        if (b1p == b2p)
        {
            return 0;
        }

        return b1p > b2p ? 1 : -1;
    }
}