using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_ImmunityCondition : Alert_Custom_Pawns_withMeta
{
    public Alert_ImmunityCondition() : base(Potentials())
    {
        defaultPriority = AlertPriority.High;
        defaultLabel = "immunity conditions";
        defaultExplanation = "Some colonists have immunity conditions.";
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
                $"    {twm.thing.LabelShort}, {(string)twm.meta[0]}, {(float)twm.meta[1]:00%}, {(float)twm.meta[2]:00%}");
            //stringBuilder.AppendLine("    " + current.Label + ", " + getCompSeverity(current as Pawn));
        }

        return stringBuilder.ToString().TrimEnd('\n');
    }

    public override string GetLabel()
    {
        var worstTwm = affectedThingsWithMeta.First();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{affectedThingsWithMeta.Count} {defaultLabel}");
        stringBuilder.AppendLine(
            $"{worstTwm.thing.LabelShort}, {(float)worstTwm.meta[1]:00%}, {(float)worstTwm.meta[2]:00%}");
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
            if (!h.Visible || h is not HediffWithComps hwc)
            {
                continue;
            }

            foreach (var hc in hwc.comps)
            {
                if (hc is not HediffComp_Immunizable hci)
                {
                    continue;
                }

                if (hci.Immunity is <= 0 or >= 1)
                {
                    continue;
                }

                var daysToImmune = (1 - hci.Immunity) / hci.Props.immunityPerDaySick;
                var daysToDeath = (1 - hwc.Severity) / hci.Props.severityPerDayNotImmune;
                var newQuant = daysToImmune - daysToDeath;
                twms.Add(new Thing_withMeta
                {
                    thing = p, meta = new object[] { hwc.LabelBase, hwc.Severity, hci.Immunity, newQuant }
                });
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
        var q1 = (float)t1.meta[3];
        var q2 = (float)t2.meta[3];
        if (q1 == q2)
        {
            return 0;
        }

        return q1 < q2 ? 1 : -1;
    }
}