using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_DoorBlockedOpen : Alert_Custom
{
    public Alert_DoorBlockedOpen()
    {
        defaultPriority = AlertPriority.High;
        defaultLabel = "doors blocked open";
        defaultExplanation = "Some doors are blocked open by obstructing objects.";
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
            foreach (var b in map.listerBuildings.allBuildingsColonist)
            {
                if (b is not Building_Door bd)
                {
                    continue;
                }

                if (!bd.WillCloseSoon && !bd.HoldOpen)
                {
                    affectedThings.Add(bd);
                }
            }
        }

        lastTick = curTick;
    }
}