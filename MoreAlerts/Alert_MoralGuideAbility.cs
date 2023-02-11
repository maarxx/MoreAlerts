using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_MoralGuideAbility : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_FreeColonistsSpawned; });
            return pots;
        }

        public Alert_MoralGuideAbility() : base(Potentials())
        {
            this.defaultLabel = "moral guide ability";
            this.defaultExplanation = "Moral Guide has ability ready.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            Ability ability = p.abilities.GetAbility(DefDatabase<AbilityDef>.GetNamed("Convert"), true);
            if (ability != null && ability.CooldownTicksRemaining <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
