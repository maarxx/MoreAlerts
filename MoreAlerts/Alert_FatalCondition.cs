using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_FatalCondition : Alert_Custom_AllPawnsOfPlayerFaction
    {

        public Alert_FatalCondition()
        {
            this.defaultPriority = AlertPriority.High;
            this.defaultLabel = "fatal conditions";
            this.defaultExplanation = "Some colonists have fatal conditions.";
        }

        public override TaggedString GetExplanation()
        {
            GetAffectedThings();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.defaultExplanation);
            stringBuilder.AppendLine();
            foreach (Thing current in this.affectedThings)
            {
                stringBuilder.AppendLine("    " + current.Label + ", " + getCompSeverity(current as Pawn));
            }
            return stringBuilder.ToString().TrimEnd('\n'); ;
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (getCompSeverity(p) > 0f)
            {
                return true;
            }
            return false;
        }

        private static float getCompSeverity(Pawn p)
        {
            foreach (Hediff h in p.health.hediffSet.hediffs)
            {
                if (h.Visible && h is HediffWithComps)
                {
                    HediffWithComps hwc = (HediffWithComps)h;
                    if (!(h.def.lethalSeverity > 0))
                    {
                        continue;
                    }
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
                        Log.Message(p.Label + ": " + h.Label);
                        return h.Severity;
                    }
                }
            }
            return 0f;

        }

        protected override void sortAffectedThings()
        {
            this.affectedThings.Sort(compareTwoPawnSeverity);
        }

        private static int compareTwoPawnSeverity(Thing p1, Thing p2)
        {
            float q1 = getCompSeverity(p1 as Pawn);
            float q2 = getCompSeverity(p2 as Pawn);
            if (q1 == q2)
            {
                return 0;
            }
            return ((q1 < q2) ? 1 : -1);
        }
    }
}
