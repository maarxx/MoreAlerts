using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MoreAlerts
{
    class Alert_Building_Damaged : Alert_Custom
    {
        public Alert_Building_Damaged()
        {
            this.defaultPriority = AlertPriority.High;
            this.defaultLabel = "damaged";
            this.defaultExplanation = "Some buildings are damaged.";
            this.affectedThings = new List<Thing>();
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
                    foreach (Thing t in map.listerBuildingsRepairable.RepairableBuildings(Faction.OfPlayer))
                    {
                        if (t.def.useHitPoints && t.HitPoints < t.MaxHitPoints && Find.CurrentMap.areaManager.Home[t.Position])
                        {
                            this.affectedThings.Add(t);
                        }
                    }
                }
                sortAffectedThings();
                lastTick = curTick;
            }
        }

        protected override void sortAffectedThings()
        {
            this.affectedThings.Sort(compareBuildingDamage);
        }

        private static int compareBuildingDamage(Thing p1, Thing p2)
        {
            Building b1 = p1 as Building;
            Building b2 = p2 as Building;
            float b1p = (float)b1.HitPoints / b1.MaxHitPoints;
            float b2p = (float)b2.HitPoints / b2.MaxHitPoints;
            if (b1p == b2p)
            {
                return 0;
            }
            return ((b1p > b2p) ? 1 : -1);
        }

    }
}
