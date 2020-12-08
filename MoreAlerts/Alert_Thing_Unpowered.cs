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
    class Alert_Thing_Unpowered : Alert_Custom
    {
        public Alert_Thing_Unpowered()
        {
            this.defaultPriority = AlertPriority.High;
            this.defaultLabel = "unpowered";
            this.defaultExplanation = "Some things are unpowered.";
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
                    foreach (PowerNet pn in map.powerNetManager.AllNetsListForReading)
                    {
                        foreach (CompPowerTrader cpt in pn.powerComps)
                        {
                            if (!cpt.PowerOn && FlickUtility.WantsToBeOn(cpt.parent) && !cpt.parent.IsBrokenDown())
                            {
                                this.affectedThings.Add(cpt.parent);
                            }
                        }
                    }
                }
                lastTick = curTick;
            }
        }

    }
}
