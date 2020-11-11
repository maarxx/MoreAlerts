using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_ImmunityCondition : Alert_Custom_AllPawnsOfPlayerFaction
    {

        public Alert_ImmunityCondition()
        {
            this.defaultPriority = AlertPriority.High;
            this.defaultLabel = "immunity conditions";
            this.defaultExplanation = "Some colonists have immunity conditions.";
        }

        public override TaggedString GetExplanation()
        {
            GetAffectedThings();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.defaultExplanation);
            stringBuilder.AppendLine();
            foreach (Thing current in this.affectedThings)
            {
                stringBuilder.AppendLine("    " + current.Label + ", " + quantifySeverity(current as Pawn));
            }
            return stringBuilder.ToString().TrimEnd('\n'); ;
        }

        protected override bool isPawnAffected(Pawn p)
        {
            foreach (Hediff h in p.health.hediffSet.hediffs)
            {
                if (h.Visible && h is HediffWithComps)
                {
                    HediffWithComps hwc = (HediffWithComps)h;
                    foreach (HediffComp hc in hwc.comps)
                    {
                        if (hc is HediffComp_Immunizable)
                        {
                            // Artery Blockage is HediffComp_Immunizable but Never Has Immunity?
                            // Filter Using Immunity > 0
                            HediffComp_Immunizable hci = hc as HediffComp_Immunizable;
                            if (hci.Immunity > 0 && hci.Immunity < 100)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        protected override void sortAffectedThings()
        {
            this.affectedThings.Sort(compareTwoPawnSeverity);
        }

        private static int compareTwoPawnSeverity(Thing p1, Thing p2)
        {
            float q1 = quantifySeverity(p1 as Pawn);
            float q2 = quantifySeverity(p2 as Pawn);
            if (q1 == q2)
            {
                return 0;
            }
            return ((q1 < q2) ? 1 : -1);
        }

        private static float quantifySeverity(Pawn p)
        {
            float quant = 0;
            foreach (Hediff h in p.health.hediffSet.hediffs)
            {
                if (h.Visible && h is HediffWithComps)
                {
                    HediffWithComps hwc = (HediffWithComps)h;
                    foreach (HediffComp hc in hwc.comps)
                    {
                        if (hc is HediffComp_Immunizable)
                        {
                            HediffComp_Immunizable hci = (HediffComp_Immunizable)hc;
                            if (hci.Immunity > 0 && hci.Immunity < 1)
                            {
                                float daysToImmune = (1 - hci.Immunity) / hci.Props.immunityPerDaySick;
                                float daysToDeath = (1 - h.Severity) / hci.Props.severityPerDayNotImmune;
                                float newQuant = daysToImmune - daysToDeath;
                                if (h.Severity > 0.4f)
                                {
                                    newQuant += 1000;
                                    if (h.Severity > 0.8f)
                                    {
                                        newQuant += 10000;
                                    }
                                }
                                if (newQuant > quant)
                                {
                                    quant = newQuant;
                                }
                            }
                        }
                    }
                }
            }
            return quant;
        }
    }
}
