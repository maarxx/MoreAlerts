using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_Thing_Unpowered : Alert_Custom
{
    public Alert_Thing_Unpowered()
    {
        defaultPriority = AlertPriority.High;
        defaultLabel = "unpowered";
        defaultExplanation = "Some things are unpowered.";
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
            foreach (var pn in map.powerNetManager.AllNetsListForReading)
            {
                foreach (var cpt in pn.powerComps)
                {
                    if (!cpt.PowerOn && FlickUtility.WantsToBeOn(cpt.parent) && !cpt.parent.IsBrokenDown())
                    {
                        affectedThings.Add(cpt.parent);
                    }
                }
            }
        }

        lastTick = curTick;
    }
}