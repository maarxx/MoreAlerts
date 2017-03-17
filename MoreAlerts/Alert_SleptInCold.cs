using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    public class Alert_SleptInCold : Alert_Thought
    {

        public Alert_SleptInCold()
        {
            defaultLabel = "Slept in Cold";
            defaultExplanation = "Colonist slept in Cold.";
        }

        protected override ThoughtDef Thought => ThoughtDefOf.SleptInCold;

    }
}
