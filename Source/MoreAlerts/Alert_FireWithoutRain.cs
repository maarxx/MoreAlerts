using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_FireWithoutRain : Alert_Custom
{
    public Alert_FireWithoutRain()
    {
        defaultLabel = "fire on map";
        defaultExplanation = "There is fire on the map, without rain!";
        defaultPriority = AlertPriority.Critical;
    }

    protected override void GetAffectedThings()
    {
        var curTick = Find.TickManager.TicksGame;
        if (lastTick + 10 > curTick)
        {
            return;
        }

        lastTick = curTick;
        foreach (var map in Find.Maps)
        {
            affectedThings.Clear();
            if (map.weatherManager.curWeather.rainRate > 0)
            {
                return;
            }

            if (map.fireWatcher.FireDanger <= 0)
            {
                return;
            }

            affectedThings.AddRange(map.listerThings.ThingsOfDef(ThingDefOf.Fire));
        }
    }
}