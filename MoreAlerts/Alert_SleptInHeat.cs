using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_SleptInHeat : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_FreeColonistsAndPrisonersSpawned; });
            return pots;
        }

        public Alert_SleptInHeat() : base(Potentials())
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
