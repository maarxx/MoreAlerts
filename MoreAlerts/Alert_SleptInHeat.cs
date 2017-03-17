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
            defaultLabel = "Uncomfortably Hot";
            defaultExplanation = "Colonist is uncomfortably hot.";
        }

        protected override ThoughtDef Thought => ThoughtDefOf.SleptInHeat;

    }
}
