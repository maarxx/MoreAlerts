using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace MoreAlerts
{
    abstract class Alert_Custom : Alert_MaybeCritical
    {

        protected List<Thing> affectedThings = new List<Thing>();
        protected int lastTick = 0;

        public Alert_Custom()
        {
            this.defaultPriority = AlertPriority.Medium;
        }

        public override AlertReport GetReport()
        {
            GetAffectedThings();
            return AlertReport.CulpritsAre(affectedThings);
        }

        public override string GetLabel()
        {
            GetAffectedThings();
            return "" + affectedThings.Count() + " " + defaultLabel;
        }

        public override TaggedString GetExplanation()
        {
            GetAffectedThings();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.defaultExplanation);
            stringBuilder.AppendLine();
            foreach (Thing current in this.affectedThings)
            {
                stringBuilder.AppendLine("    " + current.Label);
            }
            return stringBuilder.ToString().TrimEnd('\n'); ;
        }

        protected abstract void GetAffectedThings();

        protected virtual void sortAffectedThings()
        {
            // this space intentionally left blank
            // method is technically implemented
            // this behavior is not required
            // subclasses can override
        }
    }
}
