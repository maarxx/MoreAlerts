using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_DoorClosed : Alert_Custom
    {

        public Alert_DoorClosed()
        {
            this.defaultPriority = AlertPriority.High;
            this.defaultLabel = "doors closed";
            this.defaultExplanation = "Some doors are closed that should be open.";
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
                            if (!bd.TryGetComp<DoorAlertInverterComp>().shouldInvertAlert)
                            {
                                // nothing/continue
                            }
                            else if (!bd.Open)
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
