using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_BleedDeath : Alert_Custom_Pawns
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_FreeColonistsAndPrisonersSpawned; });
            return pots;
        }

        Dictionary<Pawn, int> bleeders = new Dictionary<Pawn, int>();
        public Alert_BleedDeath() : base(Potentials())
        {
            this.defaultPriority = AlertPriority.High;
            this.defaultLabel = "bleeders";
            this.defaultExplanation = "Some colonists projected to bleed out.";
        }

        protected override bool isPawnAffected(Pawn p)
        {
            /*
            if (p.Faction != Faction.OfPlayer)
            {
                return false;
            }
            */
            int ticksToBleedDeath = HealthUtility.TicksUntilDeathDueToBloodLoss(p);
            if (ticksToBleedDeath < 60000)
            {
                bleeders[p] = ticksToBleedDeath;
                return true;
            }
            else
            {
                bleeders.Remove(p);
                return false;
            }
        }

        public override string GetLabel()
        {
            GetAffectedThings();
            garbageCollectDeadPawns();
            if (bleeders.Count == 0) { return ""; } // stave off empty collection error as alert is fading
            var minBleeder = bleeders.MinBy(kvp => kvp.Value);
            if (minBleeder.Value < 12500)
            {
                this.defaultPriority = AlertPriority.Critical;
            }
            else
            {
                this.defaultPriority = AlertPriority.High;
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(affectedThings.Count() + " " + this.defaultLabel);
            stringBuilder.AppendLine(pawnBleedString(minBleeder.Key.Name.ToStringShort, minBleeder.Value));
            return stringBuilder.ToString().TrimEnd('\n'); ;
        }

        public override TaggedString GetExplanation()
        {
            GetAffectedThings();
            garbageCollectDeadPawns();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.defaultExplanation);
            stringBuilder.AppendLine();
            var sortedDict = from entry in bleeders orderby entry.Value ascending select entry;
            foreach (var bleeder in sortedDict)
            {
                stringBuilder.AppendLine("  " + pawnBleedString(bleeder.Key.Name.ToStringShort, bleeder.Value));
            }
            return stringBuilder.ToString().TrimEnd('\n');
        }

        private void garbageCollectDeadPawns()
        {
            foreach(Pawn p in bleeders.Keys)
            {
                if (p.Dead)
                {
                    bleeders.Remove(p);
                }
            }
        }

        private string pawnBleedString(string name, int bleedTicks)
        {
            return name + ", " + "TimeToDeath".Translate(bleedTicks.ToStringTicksToPeriod());
        }
    }
}
