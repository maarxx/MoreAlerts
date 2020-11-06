﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    abstract class Alert_Custom_AllPawnsOfPlayerFaction : Alert_Custom
    {
        protected override void GetAffectedThings()
        {

            int curTick = Find.TickManager.TicksGame;
            if (lastTick + 10 > curTick)
            {
                return;
            }
            else
            {
                this.affectedThings = new List<Thing>();
                foreach (Pawn p in PawnsFinder.AllMaps_SpawnedPawnsInFaction(Faction.OfPlayer))
                {
                    if (isPawnAffected(p))
                    {
                        this.affectedThings.Add(p);
                    }
                }
                foreach (Pawn p in PawnsFinder.AllMaps_PrisonersOfColonySpawned)
                {
                    if (isPawnAffected(p))
                    {
                        this.affectedThings.Add(p);
                    }
                }
                sortAffectedThings();
                lastTick = curTick;
            }
        }

        protected abstract bool isPawnAffected(Pawn p);
    }
}
