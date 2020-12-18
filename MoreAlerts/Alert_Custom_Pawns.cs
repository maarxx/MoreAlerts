using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MoreAlerts
{
    abstract class Alert_Custom_Pawns : Alert_Custom
    {
        protected List<Func<List<Pawn>>> potentialTargets;

        public Alert_Custom_Pawns(List<Func<List<Pawn>>> potentialTargets) : base()
        {
            this.potentialTargets = potentialTargets;
        }

        protected override void GetAffectedThings()
        {
            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            this.affectedThings.Clear();
            foreach (Func<List<Pawn>> flp in potentialTargets)
            {
                List<Pawn> lp = flp.Invoke();
                foreach (Pawn p in lp)
                {
                    if (isPawnAffected(p))
                    {
                        affectedThings.Add(p);
                    }
                }
            }
        }

        protected abstract bool isPawnAffected(Pawn p);
    }
}
