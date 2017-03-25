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
            foreach (Thought_Situational ts in p.needs.mood.thoughts.situational.GetSituationalThoughtsAffectingMood())
            {
                if (ts is Thought_WantToSleepWithSpouseOrLover)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
