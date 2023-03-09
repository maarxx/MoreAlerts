using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace MoreAlerts
{
    public class DoorAlertInverterComp : ThingComp
    {
        private Building_Door Door => (Building_Door)this.parent;
        public bool shouldInvertAlert;

        public override void PostExposeData()
        {
            Scribe_Values.Look(ref shouldInvertAlert, "shouldInvertAlert", false);
        }

        public virtual void ExposeData()
        {
            Scribe_Values.Look(ref shouldInvertAlert, "shouldInvertAlert");

        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            foreach (Gizmo item in base.CompGetGizmosExtra())
            {
                yield return item;
            }
            Building_Door door = Door;
            if (true)
            {
                Command_Toggle command_Toggle2 = new Command_Toggle();
                command_Toggle2.defaultLabel = "Invert Door Alerts";
                command_Toggle2.defaultDesc = "Invert the alerts on this door regarding held/blocked open. Use this on doors which should always be held/blocked open, and they will instead alert if they are shut.";
                command_Toggle2.hotKey = null;
                command_Toggle2.icon = TexCommand.HoldOpen;
                command_Toggle2.isActive = (() => shouldInvertAlert);
                command_Toggle2.toggleAction = delegate
                {
                    shouldInvertAlert = !shouldInvertAlert;
                };
                yield return command_Toggle2;
            }
        }
    }
}
