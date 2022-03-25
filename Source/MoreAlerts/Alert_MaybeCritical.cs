using RimWorld;
using UnityEngine;
using Verse;

namespace MoreAlerts;

internal abstract class Alert_MaybeCritical : Alert_Critical
{
    private int lastActiveFrame = -1;

    public Alert_MaybeCritical()
    {
        defaultPriority = AlertPriority.Medium;
    }

    protected override Color BGColor
    {
        get
        {
            if (defaultPriority != AlertPriority.Critical)
            {
                return Color.clear;
            }

            var num = Pulser.PulseBrightness(0.5f, Pulser.PulseBrightness(0.5f, 0.6f));
            return new Color(num, num, num) * Color.red;
        }
    }

    public override void AlertActiveUpdate()
    {
        if (defaultPriority != AlertPriority.Critical)
        {
            return;
        }

        if (lastActiveFrame < Time.frameCount - 1)
        {
            string text = "MessageCriticalAlert".Translate(GetLabel().CapitalizeFirst());
            var report = GetReport();
            Messages.Message(text, new LookTargets(report.AllCulprits), MessageTypeDefOf.ThreatBig);
        }

        lastActiveFrame = Time.frameCount;
    }
}