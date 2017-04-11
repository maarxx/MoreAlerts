using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_DoorHeldOpen : Alert_Custom
    {

        public Alert_DoorHeldOpen()
        {
            this.defaultLabel = "doors held open";
            this.defaultExplanation = "Some doors are marked for Hold Open.";
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
                    foreach (Building b in map.listerBuildings.allBuildingsColonist)
                    {
                        if (b is Building_Door)
                        {
                            Building_Door bd = (Building_Door)b;
                            if (bd.HoldOpen)
                            {
                                this.affectedThings.Add(bd);
                            }
                        }
                    }
                }
                lastTick = curTick;
            }
        }
    }
}
