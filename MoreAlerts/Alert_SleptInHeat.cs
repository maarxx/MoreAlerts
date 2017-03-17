using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    public class Alert_SleptInHeat : Alert_Thought
    {

        public Alert_SleptInHeat()
        {
            defaultLabel = "Slept in Heat";
            defaultExplanation = "Colonist slept in heat.";
        }

        protected override ThoughtDef Thought => ThoughtDefOf.SleptInHeat;

    }
}
