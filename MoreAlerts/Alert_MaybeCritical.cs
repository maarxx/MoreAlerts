using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace MoreAlerts
{
    abstract class Alert_MaybeCritical : Alert_Critical
    {

        private int lastActiveFrame = -1;

        public Alert_MaybeCritical()
        {
            this.defaultPriority = AlertPriority.Medium;
        }

        public override void AlertActiveUpdate()
        {

            if (this.defaultPriority == AlertPriority.Critical)
            {
                if (lastActiveFrame < Time.frameCount - 1)
                {
                    string text = "MessageCriticalAlert".Translate(GetLabel().CapitalizeFirst());
                    AlertReport report = GetReport();
                    Messages.Message(text, new LookTargets(report.culprits), MessageTypeDefOf.ThreatBig);
                }
                lastActiveFrame = Time.frameCount;
            }
            else
            {
                // Nothing.
            }

        }

        protected override Color BGColor
        {

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
