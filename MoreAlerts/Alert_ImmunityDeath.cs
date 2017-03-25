using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_ImmunityDeath : Alert_Custom_FreeColonistsAndPrisonersSpawned
    {

        public Alert_ImmunityDeath()
        {
            this.defaultLabel = "immunity death";
            this.defaultExplanation = "Some colonists projected for immunity death.";
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
                            HediffComp_Immunizable hci = (HediffComp_Immunizable)hc;
                            if (hci.Immunity > 0 && hci.Immunity < 1)
                            {
                                float daysToImmune = (1 - hci.Immunity) / hci.Props.immunityPerDaySick;
                                float daysToDeath = (1 - h.Severity) / hci.Props.severityPerDayNotImmune;
                                if (daysToDeath < daysToImmune)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

    }
}
