using System;
using System.Collections.Generic;
using Verse;

namespace MoreAlerts;

internal abstract class Alert_Custom_Pawns : Alert_Custom
{
    protected List<Func<List<Pawn>>> potentialTargets;

    public Alert_Custom_Pawns(List<Func<List<Pawn>>> potentialTargets)
    {
        this.potentialTargets = potentialTargets;
    }

    protected override void GetAffectedThings()
    {
        var curTick = Find.TickManager.TicksGame;
        if (lastTick + 10 > curTick)
        {
            return;
        }

        affectedThings.Clear();
        foreach (var flp in potentialTargets)
        {
            var lp = flp.Invoke();
            foreach (var p in lp)
            {
                if (isPawnAffected(p))
                {
                    affectedThings.Add(p);
                }
            }
        }
    }

    protected abstract bool isPawnAffected(Pawn p);
}