using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_SleptInHeat : Alert_Custom_FreeColonistsAndPrisonersSpawned
    {

        public Alert_SleptInHeat()
        {
            defaultLabel = "Slept in Heat";
            defaultExplanation = "Colonist slept in heat.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            List<Thought> thoughts = new List<Thought>();
            p.needs.mood.thoughts.GetAllMoodThoughts(thoughts);
            foreach (Thought t in thoughts)
            {
                if (t.def == ThoughtDefOf.SleptInHeat)
                {
                    return true;
                }
            }
            if (!p.Awake() && p.AmbientTemperature > p.def.GetStatValueAbstract(StatDefOf.ComfyTemperatureMax))
            {
                return true;
            }
            return false;
        }
    }
}
