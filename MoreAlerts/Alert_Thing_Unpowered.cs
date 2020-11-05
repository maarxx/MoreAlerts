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
                //this.affectedThings = new List<Thing>();
                for (int i = this.affectedThings.Count - 1; i >= 0; i--)
                {
                    if ((bool)this.affectedThings[i].TryGetComp<CompPowerTrader>()?.PowerOn)
                    {
                        this.affectedThings.RemoveAt(i);
                    }
                }
                Type type = typeof(PowerNet);
                FieldInfo field = type.GetField("partsWantingPowerOn", BindingFlags.NonPublic | BindingFlags.Static);
                List<CompPowerTrader> partsWantingPowerOn = (List<CompPowerTrader>)field.GetValue(Find.Maps[0].powerNetManager.AllNetsListForReading[0]);
                Log.Message("Hello from Alert_Thing_Unpowered: " + partsWantingPowerOn.Count);
                foreach (CompPowerTrader cpt in partsWantingPowerOn)
                {
                    //this.affectedThings.Add(cpt.parent);
                    if (this.affectedThings.IndexOf(cpt.parent) == -1)
                    {
                        this.affectedThings.Add(cpt.parent);
                    }
                }
                //foreach (Map map in Find.Maps)
                //{
                //    foreach (PowerNet pn in map.powerNetManager.AllNetsListForReading)
                //    {
                //        partsWantingPowerOn = (List<CompPowerTrader>)field.GetValue(Find.Maps[0].powerNetManager.AllNetsListForReading[0]);
                //        Log.Message("Hello from Alert_Thing_Unpowered: " + partsWantingPowerOn.Count);
                //        foreach (CompPowerTrader cpt in partsWantingPowerOn)
                //        {
                //            this.affectedThings.Add(cpt.parent.StoringThing());
                //        }
                //    }
                //}
                lastTick = curTick;
            }
        }

    }
}
