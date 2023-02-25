using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_WantToSleepWith : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_FreeColonistsSpawned; });
            return pots;
        }

        public Alert_WantToSleepWith() : base (Potentials())
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
                if (t.def.defName == "WantToSleepWithSpouseOrLover")
                {
                    return true;
                }
            }
            return false;
        }

    }
}
