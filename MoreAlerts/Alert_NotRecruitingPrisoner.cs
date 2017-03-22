using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_NotRecruitingPrisoner : Alert
    {

        List<Pawn> notRecruitingPrisoners;

        int lastTick;

        public Alert_NotRecruitingPrisoner()
        {
            this.defaultLabel = "X prisoners not recruiting";
            this.defaultExplanation = "Some prisoners aren't being recruited!";
            this.notRecruitingPrisoners = new List<Pawn>();
            this.lastTick = 0;
        }

        public override AlertReport GetReport()
        {
            GetNotRecruitingPrisoners();
            return this.notRecruitingPrisoners.FirstOrDefault();
        }

        public override string GetLabel()
        {
            GetNotRecruitingPrisoners();
            return "" + notRecruitingPrisoners.Count() + " not recruiting prisoners";
        }

        public override string GetExplanation()
        {
            GetNotRecruitingPrisoners();
            return base.GetExplanation();
        }

        private void GetNotRecruitingPrisoners()
        {

            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            else
            {
                notRecruitingPrisoners = new List<Pawn>();
                foreach (Pawn p in PawnsFinder.AllMaps_PrisonersOfColonySpawned)
                {
                    PrisonerInteractionMode pim = p.guest.interactionMode;
                    if (pim == PrisonerInteractionMode.NoInteraction || pim == PrisonerInteractionMode.Chat)
                    {
                        notRecruitingPrisoners.Add(p);
                    }
                }
                lastTick = curTick;
            }

        }
    }
}
