using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_BleedDeath : Alert_Custom_Pawns
{
    private readonly Dictionary<Pawn, int> bleeders = new Dictionary<Pawn, int>();

    public Alert_BleedDeath() : base(Potentials())
    {
        defaultPriority = AlertPriority.High;
        defaultLabel = "bleeders";
        defaultExplanation = "Some colonists projected to bleed out.";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_FreeColonistsAndPrisonersSpawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        /*
        if (p.Faction != Faction.OfPlayer)
        {
            return false;
        }
        */
        var ticksToBleedDeath = HealthUtility.TicksUntilDeathDueToBloodLoss(p);
        if (ticksToBleedDeath < 60000)
        {
            bleeders[p] = ticksToBleedDeath;
            return true;
        }

        bleeders.Remove(p);
        return false;
    }

    public override string GetLabel()
    {
        GetAffectedThings();
        garbageCollectDeadPawns();
        if (bleeders.Count == 0)
        {
            return "";
        } // stave off empty collection error as alert is fading

        var minBleeder = bleeders.MinBy(kvp => kvp.Value);
        defaultPriority = minBleeder.Value < 12500 ? AlertPriority.Critical : AlertPriority.High;

        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{affectedThings.Count} {defaultLabel}");
        stringBuilder.AppendLine(pawnBleedString(minBleeder.Key.Name.ToStringShort, minBleeder.Value));
        return stringBuilder.ToString().TrimEnd('\n');
    }

    public override TaggedString GetExplanation()
    {
        GetAffectedThings();
        garbageCollectDeadPawns();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(defaultExplanation);
        stringBuilder.AppendLine();
        var sortedDict = from entry in bleeders orderby entry.Value select entry;
        foreach (var bleeder in sortedDict)
        {
            stringBuilder.AppendLine($"  {pawnBleedString(bleeder.Key.Name.ToStringShort, bleeder.Value)}");
        }

        return stringBuilder.ToString().TrimEnd('\n');
    }

    private void garbageCollectDeadPawns()
    {
        foreach (var p in bleeders.Keys)
        {
            if (p.Dead)
            {
                bleeders.Remove(p);
            }
        }
    }

    private string pawnBleedString(string name, int bleedTicks)
    {
        return $"{name}, " + "TimeToDeath".Translate(bleedTicks.ToStringTicksToPeriod());
    }
}