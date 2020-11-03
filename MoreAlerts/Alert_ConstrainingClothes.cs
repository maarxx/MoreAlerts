using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_ConstrainingClothes : Alert_Custom_FreeColonistsSpawned
    {
        public Alert_ConstrainingClothes()
        {
            this.defaultLabel = "constraining clothes";
            this.defaultExplanation = "Some nudists have constraining clothes.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            List<Thought> thoughts = new List<Thought>();
            p.needs.mood.thoughts.GetAllMoodThoughts(thoughts);
            foreach (Thought t in thoughts)
            {
                if (t.def.defName == "ClothedNudist")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
