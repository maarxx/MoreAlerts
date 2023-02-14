using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_ForbiddenEmptyHydroponics : Alert_Custom
    {
        public Alert_ForbiddenEmptyHydroponics()
        {
            this.defaultLabel = "idle hydroponics";
            this.defaultExplanation = "Some hydroponics are empty and forbidden.";
        }

        protected override void GetAffectedThings()
        {
            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            else
            {
                this.affectedThings = new List<Thing>();
                foreach (Map map in Find.Maps)
                {
                    foreach (Building b in map.listerBuildings.AllBuildingsColonistOfDef(DefDatabase<ThingDef>.GetNamed("HydroponicsBasin")))
                    {
                        Building_PlantGrower bpg = (Building_PlantGrower)b;
                        if (bpg.IsForbidden(Faction.OfPlayer) && !bpg.PlantsOnMe.Any())
                        {
                            this.affectedThings.Add(bpg);
                        }
                    }
                }
                lastTick = curTick;
            }
        }
    }
}
