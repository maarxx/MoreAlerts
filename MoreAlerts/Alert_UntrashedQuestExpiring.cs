using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_UntrashedQuestExpiring : Alert
    {
        protected List<Quest> targetQuests;
        protected int lastTick = 0;
        protected Quest soonestExpiringQuest;
        protected int soonestExpiringQuestTicks;
        public Alert_UntrashedQuestExpiring()
        {
            this.defaultPriority = AlertPriority.Medium;
            this.defaultLabel = "quest expiring";
            this.defaultExplanation = "You've got undismissed quests expiring:";
            this.targetQuests = new List<Quest>();
        }

        public void GetAffectedQuests()
        {
            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            targetQuests = new List<Quest>();
            soonestExpiringQuestTicks = int.MaxValue;
            foreach (Quest q in Find.QuestManager.QuestsListForReading)
            {
                int ticksRemaining;
                if (!q.hiddenInUI
                    && !q.dismissed
                    && (q.State == QuestState.NotYetAccepted || q.State == QuestState.Ongoing)
                    && ((ticksRemaining = QuestUtility.GetQuestTicksRemaining(q)) > 0))
                {
                    targetQuests.Add(q);
                    if (ticksRemaining < soonestExpiringQuestTicks)
                    {
                        soonestExpiringQuestTicks = ticksRemaining;
                        soonestExpiringQuest = q;
                    }
                }
            }
            lastTick = curTick;
        }

        public override AlertReport GetReport()
        {
            GetAffectedQuests();
            return (targetQuests.Count > 0);
        }

        public override string GetLabel()
        {
            GetAffectedQuests();
            return "" + targetQuests.Count() + " " + defaultLabel
                + " (" + soonestExpiringQuestTicks.ToStringTicksToPeriod(shortForm: true) + ")";
        }

        public override TaggedString GetExplanation()
        {
            GetAffectedQuests();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.defaultExplanation);
            stringBuilder.AppendLine();
            foreach (Quest q in this.targetQuests)
            {
                stringBuilder.AppendLine("    " + q.name + " (" + QuestUtility.GetQuestTicksRemaining(q).ToStringTicksToPeriod() + ")");
            }
            return stringBuilder.ToString().TrimEnd('\n');
        }
    }
}
