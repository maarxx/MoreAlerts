using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_WantToSleepWith : Alert_Custom_FreeColonistsSpawned
    {

        public Alert_WantToSleepWith()
        {
            this.defaultLabel = "want to sleep with";
            this.defaultExplanation = "Some colonists want to sleep with others.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            List<Thought> thoughts = new List<Thought>();
            p.needs.mood.thoughts.GetAllMoodThoughts(thoughts);
            foreach (Thought t in thoughts)
            {
                if (t is Thought_WantToSleepWithSpouseOrLover)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
