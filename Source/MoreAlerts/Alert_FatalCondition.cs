using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_FatalCondition : Alert_Custom_Pawns_withMeta
{
    public Alert_FatalCondition() : base(Potentials())
    {
        defaultPriority = AlertPriority.High;
        defaultLabel = "fatal conditions";
        defaultExplanation = "Some colonists have fatal conditions.";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>>
        {
            () => PawnsFinder.AllMaps_SpawnedPawnsInFaction(Faction.OfPlayer),
            () => PawnsFinder.AllMaps_PrisonersOfColonySpawned
        };
        return pots;
    }

    public override TaggedString GetExplanation()
    {
        GetAffectedThings();
        SortAffectedThings();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(defaultExplanation);
        stringBuilder.AppendLine();
        foreach (var twm in affectedThingsWithMeta)
        {
            stringBuilder.AppendLine(
                $"    {twm.thing.LabelShort}, {(string)twm.meta[0]}, {(float)twm.meta[1]:00%}");
            //stringBuilder.AppendLine("    " + current.Label + ", " + getCompSeverity(current as Pawn));
        }

        return stringBuilder.ToString().TrimEnd('\n');
    }

    public override string GetLabel()
    {
        var worstTwm = affectedThingsWithMeta.First();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{affectedThingsWithMeta.Count} {defaultLabel}");
        stringBuilder.AppendLine($"{worstTwm.thing.LabelShort}, {(float)worstTwm.meta[1]:00%}");
        return stringBuilder.ToString().TrimEnd('\n');
    }

    protected override void considerToAddPawnWithMeta(Pawn p)
    {
        var twms = getCompsWithSeverity(p);
        affectedThingsWithMeta.AddRange(twms);
    }

    private static List<Thing_withMeta> getCompsWithSeverity(Pawn p)
    {
        var twms = new List<Thing_withMeta>();
        foreach (var h in p.health.hediffSet.hediffs)
        {
            //if (h.Visible && h.def.defName != "Malnutrition" && h.def.defName != "BloodLoss")
            if (!h.Visible || h.def.defName == "BloodLoss")
            {
                continue;
            }

            if (!(h.def.lethalSeverity > 0))
            {
                continue;
            }

            if (h is HediffWithComps hwc)
            {
                var compIsImmunizable = false;
                foreach (var hc in hwc.comps)
                {
                    if (hc is HediffComp_Immunizable)
                    {
                        compIsImmunizable = true;
                    }
                }

                if (!compIsImmunizable)
                {
                    twms.Add(new Thing_withMeta
                        { thing = p, meta = new object[] { hwc.LabelBase, hwc.Severity } });
                }
            }
            else
            {
                twms.Add(new Thing_withMeta { thing = p, meta = new object[] { h.LabelBase, h.Severity } });
            }
        }

        return twms;
    }

    protected override void SortAffectedThings()
    {
        affectedThingsWithMeta.Sort(compareTwoElements);
    }

    private static int compareTwoElements(Thing_withMeta t1, Thing_withMeta t2)
    {
        var q1 = (float)t1.meta[1];
        var q2 = (float)t2.meta[1];
        if (q1 == q2)
        {
            return 0;
        }

        return q1 < q2 ? 1 : -1;
    }
}