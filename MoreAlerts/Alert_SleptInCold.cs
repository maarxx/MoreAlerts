using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_SleptInCold : Alert_Custom_FreeColonistsAndPrisonersSpawned
    {

        public Alert_SleptInCold()
        {
            defaultLabel = "Slept in Cold";
            defaultExplanation = "Colonist slept in Cold.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            List<Thought> thoughts = new List<Thought>();
            p.needs.mood.thoughts.GetAllMoodThoughts(thoughts);
            foreach (Thought t in thoughts)
            {
                if (t.def == ThoughtDefOf.SleptInCold)
                {
                    return true;
                }
            }
            if (!p.Awake() && p.AmbientTemperature < p.def.GetStatValueAbstract(StatDefOf.ComfyTemperatureMin))
            {
                return true;
            }
            return false;
        }
    }
}
