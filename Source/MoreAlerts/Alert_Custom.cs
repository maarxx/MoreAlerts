using System.Collections.Generic;
using System.Text;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal abstract class Alert_Custom : Alert_MaybeCritical
{
    protected List<Thing> affectedThings = new List<Thing>();
    protected int lastTick = 0;

    public Alert_Custom()
    {
        defaultPriority = AlertPriority.Medium;
    }

    public override AlertReport GetReport()
    {
        GetAffectedThings();
        return AlertReport.CulpritsAre(affectedThings);
    }

    public override string GetLabel()
    {
        GetAffectedThings();
        return $"{affectedThings.Count} {defaultLabel}";
    }

    public override TaggedString GetExplanation()
    {
        GetAffectedThings();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(defaultExplanation);
        stringBuilder.AppendLine();
        foreach (var current in affectedThings)
        {
            stringBuilder.AppendLine($"    {current.Label}");
        }

        return stringBuilder.ToString().TrimEnd('\n');
    }

    protected abstract void GetAffectedThings();

    protected virtual void SortAffectedThings()
    {
        // this space intentionally left blank
        // method is technically implemented
        // this behavior is not required
        // subclasses can override
    }
}