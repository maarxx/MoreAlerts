﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_UnusedResourcePermits : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_FreeColonistsSpawned; });
            return pots;
        }

        public Alert_UnusedResourcePermits() : base(Potentials())
        {
            this.defaultPriority = AlertPriority.Medium;
            this.defaultLabel = "unused resource permits";
            this.defaultExplanation = "Some colonists have unused resource drop permits.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (p.royalty.HasAidPermit && !p.IsQuestLodger())
            {
                foreach (FactionPermit permit in p.royalty.AllFactionPermits)
                {
                    if (!permit.OnCooldown)
                    {
                        if (permit.Permit.defName == "SteelDrop") { return true; }
                        if (permit.Permit.defName == "FoodDrop") { return true; }
                        if (permit.Permit.defName == "SilverDrop") { return true; }
                        if (permit.Permit.defName == "GlitterMedDrop") { return true; }
                    }
                }
            }
            return false;
        }
    }
}
