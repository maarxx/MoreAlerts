using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MoreAlerts
{
    struct Thing_withMeta
    {
        public Thing thing;
        public object[] meta;
    }
    abstract class Alert_Custom_Pawns_withMeta : Alert_Custom_Pawns
    {
        protected List<Thing_withMeta> affectedThingsWithMeta = new List<Thing_withMeta>();

        public Alert_Custom_Pawns_withMeta(List<Func<List<Pawn>>> potentialTargets) : base(potentialTargets)
        {
            //
        }

        protected override void GetAffectedThings()
        {
            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            affectedThingsWithMeta.Clear();
            foreach (Func<List<Pawn>> flp in potentialTargets)
            {
                List<Pawn> lp = flp.Invoke();
                foreach (Pawn p in lp)
                {
                    //if (isPawnAffected(p))
                    //{
                    //    affectedThings.Add(p);
                    //}
                    considerToAddPawnWithMeta(p);
                }
            }
            SortAffectedThings();
        }

        protected abstract void considerToAddPawnWithMeta(Pawn p);

        protected override bool isPawnAffected(Pawn p)
        {
            //space blank, not using anymore, see above
            throw new NotImplementedException();
        }

        public override AlertReport GetReport()
        {
            GetAffectedThings();
            List<Thing> actualThings = new List<Thing>();
            foreach (Thing_withMeta twm in affectedThingsWithMeta)
            {
                actualThings.Add(twm.thing);
            }
            return AlertReport.CulpritsAre(actualThings);
        }

        public override abstract string GetLabel();

        public override abstract TaggedString GetExplanation();
    }
}
