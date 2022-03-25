using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal struct Thing_withMeta
{
    public Thing thing;
    public object[] meta;
}

internal abstract class Alert_Custom_Pawns_withMeta : Alert_Custom_Pawns
{
    protected List<Thing_withMeta> affectedThingsWithMeta = new List<Thing_withMeta>();

    public Alert_Custom_Pawns_withMeta(List<Func<List<Pawn>>> potentialTargets) : base(potentialTargets)
    {
        //
    }

    protected override void GetAffectedThings()
    {
        var curTick = Find.TickManager.TicksGame;
        if (lastTick + 10 > curTick)
        {
            return;
        }

        affectedThingsWithMeta.Clear();
        foreach (var flp in potentialTargets)
        {
            var lp = flp.Invoke();
            foreach (var p in lp)
            {
                //if (isPawnAffected(p))
                //{
                //    affectedThings.Add(p);
                //}
                considerToAddPawnWithMeta(p);
            }
        }

        SortAffectedThings();
    }

    protected abstract void considerToAddPawnWithMeta(Pawn p);

    protected override bool isPawnAffected(Pawn p)
    {
        //space blank, not using anymore, see above
        throw new NotImplementedException();
    }

    public override AlertReport GetReport()
    {
        GetAffectedThings();
        var actualThings = new List<Thing>();
        foreach (var twm in affectedThingsWithMeta)
        {
            actualThings.Add(twm.thing);
        }

        return AlertReport.CulpritsAre(actualThings);
    }

    public abstract override string GetLabel();

    public abstract override TaggedString GetExplanation();
}