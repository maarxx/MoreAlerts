using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_ImmunityDeath : Alert
    {

        List<Pawn> immunityDeath;

        int lastTick;

        public Alert_ImmunityDeath()
        {
            this.defaultLabel = "X immunity death";
            this.defaultExplanation = "Some colonists projected for immunity death.";
            this.immunityDeath = new List<Pawn>();
            this.lastTick = 0;
        }

        public override AlertReport GetReport()
        {
            GetPawnsImmunityDeath();
            return this.immunityDeath.FirstOrDefault();
        }

        public override string GetLabel()
        {
            GetPawnsImmunityDeath();
            return "" + immunityDeath.Count() + " immunity death";
        }

        public override string GetExplanation()
        {
            GetPawnsImmunityDeath();
            return base.GetExplanation();
        }

        private void GetPawnsImmunityDeath()
        {

            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            else
            {
                immunityDeath = new List<Pawn>();
                foreach (Pawn p in PawnsFinder.AllMaps_FreeColonistsAndPrisonersSpawned)
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
                                            immunityDeath.Add(p);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                lastTick = curTick;
            }
        }
    }
}
