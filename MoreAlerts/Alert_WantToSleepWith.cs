using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_WantToSleepWith : Alert
    {

        List<Pawn> wantToSleepWith;

        int lastTick;

        public Alert_WantToSleepWith()
        {
            this.defaultLabel = "X want to sleep with";
            this.defaultExplanation = "Some colonists want to sleep with others.";
            this.wantToSleepWith = new List<Pawn>();
            this.lastTick = 0;
        }

        public override AlertReport GetReport()
        {
            GetColonistsWantToSleepWith();
            return this.wantToSleepWith.FirstOrDefault();
        }

        public override string GetLabel()
        {
            GetColonistsWantToSleepWith();
            return "" + wantToSleepWith.Count() + " want to sleep with";
        }

        public override string GetExplanation()
        {
            GetColonistsWantToSleepWith();
            return base.GetExplanation();
        }

        private void GetColonistsWantToSleepWith()
        {

            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            else
            {
                wantToSleepWith = new List<Pawn>();
                foreach (Pawn p in PawnsFinder.AllMaps_FreeColonistsSpawned)
                {
                    foreach (Thought_Situational ts in p.needs.mood.thoughts.situational.GetSituationalThoughtsAffectingMood())
                    {
                        if (ts is Thought_WantToSleepWithSpouseOrLover)
                        {
                            wantToSleepWith.Add(p);
                        }
                    }
                }
                lastTick = curTick;
            }
        }
    }
}
