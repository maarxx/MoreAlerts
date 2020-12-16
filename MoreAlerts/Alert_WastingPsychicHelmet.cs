using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_WastingPsychicHelmet : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_FreeColonistsSpawned; });
            return pots;
        }

        public Alert_WastingPsychicHelmet() : base(Potentials())
        {
            this.defaultLabel = "wasting psychic helmets";
            this.defaultExplanation = "Some colonists are pointlessly wearing psychic helmets.";
        }

        private static bool isBadPsychicEvent(Map map)
        {
            if (map.gameConditionManager.ConditionIsActive(GameConditionDefOf.PsychicDrone))
            {
                return true;
            }
            List<Thing> emanators = map.listerThings.ThingsInGroup(ThingRequestGroup.ConditionCauser); // PROBABLY WRONG
            if (emanators.Any())
            {
                return true;
            }
            return false;
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (isBadPsychicEvent(p.Map))
            {
                return false;
            }

            foreach (Apparel a in p.apparel.WornApparel)
            {
                if (a.def.defName == "Apparel_PsychicFoilHelmet")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
