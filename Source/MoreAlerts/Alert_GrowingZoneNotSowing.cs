using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_GrowingZoneNotSowing : Alert_Custom
{
    private int numAffectedZones;

    public Alert_GrowingZoneNotSowing()
    {
        defaultLabel = "growing zones disabled";
        defaultExplanation = "Some growing zones are not marked to allow sowing.";
        numAffectedZones = 0;
    }

    public override AlertReport GetReport()
    {
        GetAffectedThings();
        if (numAffectedZones > 0)
        {
            return true;
        }

        return false;
    }

    public override string GetLabel()
    {
        GetAffectedThings();
        return $"{numAffectedZones} {defaultLabel}";
    }

    protected override void GetAffectedThings()
    {
        var curTick = Find.TickManager.TicksGame;
        if (lastTick + 10 > curTick)
        {
            return;
        }

        numAffectedZones = 0;
        foreach (var map in Find.Maps)
        {
            foreach (var z in map.zoneManager.AllZones)
            {
                if (z is not Zone_Growing zg)
                {
                    continue;
                }

                if (!zg.allowSow)
                {
                    numAffectedZones++;
                }
            }
        }

        lastTick = curTick;
    }
}