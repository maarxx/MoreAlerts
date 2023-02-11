using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_AnytimeFestivalReady : Alert
    {
        protected List<Precept_Ritual> targetRituals;
        protected int lastTick = 0;
        public Alert_AnytimeFestivalReady()
        {
            this.defaultPriority = AlertPriority.Medium;
            this.defaultLabel = "anytime festival ready";
            this.defaultExplanation = "There is an anytime festival ready.";
            this.targetRituals = new List<Precept_Ritual>();
        }

        public void GetReadyAnytimeFestivals()
        {
            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            targetRituals = new List<Precept_Ritual>();
            foreach (Ideo ideo in Faction.OfPlayer.ideos.AllIdeos)
            {
                for (int i = 0; i < ideo.PreceptsListForReading.Count; i++)
                {
                    Precept precept = ideo.PreceptsListForReading[i];
                    Precept_Ritual ritual = (precept as Precept_Ritual);
                    if (ritual != null && ritual.isAnytime && !ritual.RepeatPenaltyActive
                        && ritual.def.ritualPatternBase.defName.Contains("Celebration"))
                    {
                        targetRituals.Add(ritual);
                    }
                }
            }
            lastTick = curTick;
        }

        public override AlertReport GetReport()
        {
            GetReadyAnytimeFestivals();
            return (targetRituals.Count > 0);
        }

        public override string GetLabel()
        {
            GetReadyAnytimeFestivals();
            return "" + targetRituals.Count() + " " + defaultLabel;
        }

        public override TaggedString GetExplanation()
        {
            GetReadyAnytimeFestivals();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.defaultExplanation);
            stringBuilder.AppendLine();
            foreach (Precept_Ritual ritual in this.targetRituals)
            {
                stringBuilder.AppendLine("    " + ritual.Label);
            }
            return stringBuilder.ToString().TrimEnd('\n'); ;
        }
    }
}
