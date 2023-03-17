using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_XenoRaceGuest : Alert_Custom_Pawns_withMeta
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_Spawned; });
            return pots;
        }

        public Alert_XenoRaceGuest() : base(Potentials())
        {
            this.defaultPriority = AlertPriority.High;
            this.defaultLabel = "guests";
            this.defaultExplanation = "There are guests! By xenotype or animal race: ";
        }

        public override TaggedString GetExplanation()
        {
            return GetTheBigString();
        }

        public override string GetLabel()
        {
            return GetTheBigString();
        }

        public string GetTheBigString()
        {
            var dictionary = new Dictionary<string, int>();
            string[] raceCounts = affectedThingsWithMeta
                .GroupBy(e => e.meta[0])
                .OrderBy(e => e.Count())
                .Select(e => e.Key + " " + e.Count())
                .ToArray();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string raceCount in raceCounts)
            {
                stringBuilder.AppendLine(raceCount);
            }
            return stringBuilder.ToString().TrimEnd('\n');

        }

        protected override void considerToAddPawnWithMeta(Pawn p)
        {
            string xenotype;
            if (p.Faction != null
                && p.Faction != Faction.OfPlayer
                && !p.HostileTo(Faction.OfPlayer)
                && !p.IsPrisonerOfColony
                && (xenotype = p.genes?.Xenotype?.label) != null)
            {
                this.affectedThingsWithMeta.Add(new Thing_withMeta() {
                    thing = p,
                    meta = (new object[] { xenotype })
                });
            }
        }
    }
}
