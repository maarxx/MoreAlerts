using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_DoorBlockedOpen : Alert_Custom
    {

        public Alert_DoorBlockedOpen()
        {
            this.defaultPriority = AlertPriority.High;
            this.defaultLabel = "doors blocked open";
            this.defaultExplanation = "Some doors are blocked open by obstructing objects.";
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
                            if (bd.TryGetComp<DoorAlertInverterComp>().shouldInvertAlert)
                            {
                                // TODO
                            }
                            else if (!bd.WillCloseSoon && !bd.HoldOpen)
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
