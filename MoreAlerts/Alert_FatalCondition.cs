using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_FatalCondition : Alert_Custom_Pawns_withMeta
    {
        static List<Func<List<Pawn>>> Potentials()
        {
            List<Func<List<Pawn>>> pots = new List<Func<List<Pawn>>>();
            pots.Add(delegate { return PawnsFinder.AllMaps_SpawnedPawnsInFaction(Faction.OfPlayer); });
            pots.Add(delegate { return PawnsFinder.AllMaps_PrisonersOfColonySpawned; });
            return pots;
        }

        public Alert_FatalCondition() : base(Potentials())
        {
            this.defaultPriority = AlertPriority.High;
            this.defaultLabel = "fatal conditions";
            this.defaultExplanation = "Some colonists have fatal conditions.";
        }

        public override TaggedString GetExplanation()
        {
            GetAffectedThings();
            SortAffectedThings();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.defaultExplanation);
            stringBuilder.AppendLine();
            foreach (Thing_withMeta twm in this.affectedThingsWithMeta)
            {
                stringBuilder.AppendLine("    " + twm.thing.LabelShort + ", " + (string)(twm.meta[0]) + ", " + ((float)(twm.meta[1])).ToString("00%"));
                //stringBuilder.AppendLine("    " + current.Label + ", " + getCompSeverity(current as Pawn));
            }
            return stringBuilder.ToString().TrimEnd('\n');
        }

        public override string GetLabel()
        {
            Thing_withMeta worstTwm = affectedThingsWithMeta.First();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("" + affectedThingsWithMeta.Count() + " " + defaultLabel);
            stringBuilder.AppendLine("" + worstTwm.thing.LabelShort + ", " + ((float)(worstTwm.meta[1])).ToString("00%"));
            return stringBuilder.ToString().TrimEnd('\n');
        }

        protected override void considerToAddPawnWithMeta(Pawn p)
        {
            List<Thing_withMeta> twms = getCompsWithSeverity(p);
            this.affectedThingsWithMeta.AddRange(twms);
        }

        private static List<Thing_withMeta> getCompsWithSeverity(Pawn p)
        {
            List<Thing_withMeta> twms = new List<Thing_withMeta>();
            foreach (Hediff h in p.health.hediffSet.hediffs)
            {
                //if (h.Visible && h.def.defName != "Malnutrition" && h.def.defName != "BloodLoss")
                if (h.Visible && h.def.defName != "BloodLoss")
                {
                    if (h.def.lethalSeverity > 0)
                    {
                        if (h is HediffWithComps)
                        {
                            HediffWithComps hwc = (HediffWithComps)h;
                            bool compIsImmunizable = false;
                            foreach (HediffComp hc in hwc.comps)
                            {
                                if (hc is HediffComp_Immunizable)
                                {
                                    compIsImmunizable = true;
                                }
                            }
                            if (!compIsImmunizable)
                            {
                                twms.Add(new Thing_withMeta() { thing = p, meta = (new object[] { h.LabelBase, h.Severity }) });
                            }

                        }
                        else
                        {
                            twms.Add(new Thing_withMeta() { thing = p, meta = (new object[] { h.LabelBase, h.Severity }) });
                        }
                    }
                }
            }
            return twms;
        }

        protected override void SortAffectedThings()
        {
            this.affectedThingsWithMeta.Sort(compareTwoElements);
        }

        private static int compareTwoElements(Thing_withMeta t1, Thing_withMeta t2)
        {
            float q1 = (float)(t1.meta[1]);
            float q2 = (float)(t2.meta[1]);
            if (q1 == q2)
            {
                return 0;
            }
            return ((q1 < q2) ? 1 : -1);
        }
    }
}
