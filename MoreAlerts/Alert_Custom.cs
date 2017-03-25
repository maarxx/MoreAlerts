using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace MoreAlerts
{
    abstract class Alert_Custom : Alert_Critical
    {

        protected List<Thing> affectedThings = new List<Thing>();
        protected int lastTick = 0;

        private int lastActiveFrame = -1;

        public override AlertReport GetReport()
        {
            GetAffectedThings();
            return this.affectedThings.FirstOrDefault();
        }

        public override string GetLabel()
        {
            GetAffectedThings();
            return "" + affectedThings.Count() + " " + defaultLabel;
        }

        public override string GetExplanation()
        {
            GetAffectedThings();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.defaultExplanation);
            stringBuilder.AppendLine();
            foreach (Thing current in this.affectedThings)
            {
                stringBuilder.AppendLine("    " + current.Label);
            }
            return stringBuilder.ToString();
        }

        protected abstract void GetAffectedThings();

        public override void AlertActiveUpdate()
        {
            /*
            if (this.defaultPriority == AlertPriority.Critical)
            {
                (this as Alert_Critical).AlertActiveUpdate();
            }
            else
            {
                (this as Alert).AlertActiveUpdate();
            }
            */

            if (this.defaultPriority == AlertPriority.Critical)
            {
                if (this.lastActiveFrame < Time.frameCount - 1)
                {
                    Messages.Message("MessageCriticalAlert".Translate(new object[]
                    {
                    this.GetLabel()
                    }), this.GetReport().culprit, MessageSound.SeriousAlert);
                }
                this.lastActiveFrame = Time.frameCount;
            }
            else
            {
                // Nothing.
            }

        }

        protected override Color BGColor
        {
            /*
            get
            {
                if (this.defaultPriority == AlertPriority.Critical)
                {
                    return (this as Alert_Critical).BGColor;
                }
                else
                {
                    return (this as Alert).BGColor;
                }
            }
            */

            get
            {
                if (this.defaultPriority == AlertPriority.Critical)
                {
                    float num = Pulser.PulseBrightness(0.5f, Pulser.PulseBrightness(0.5f, 0.6f));
                    return new Color(num, num, num) * Color.red;
                }
                else
                {
                    return Color.clear;
                }
            }

        }

    }
}
