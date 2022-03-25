using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreAlerts;

internal class Alert_AnimalHunting : Alert_Custom_Pawns
{
    public Alert_AnimalHunting() : base(Potentials())
    {
        defaultPriority = AlertPriority.Critical;
        defaultLabel = "animals hunting";
        defaultExplanation = "Some animals are hunting you!";
    }

    private static List<Func<List<Pawn>>> Potentials()
    {
        var pots = new List<Func<List<Pawn>>> { () => PawnsFinder.AllMaps_Spawned };
        return pots;
    }

    protected override bool isPawnAffected(Pawn p)
    {
        if (p.MentalStateDef != null && (p.MentalStateDef.Equals(MentalStateDefOf.Manhunter) ||
                                         p.MentalStateDef.Equals(MentalStateDefOf.ManhunterPermanent)))
        {
            return true;
        }

        if (
            p.jobs is { curJob: { def: { } } } && p.jobs.curJob.def.Equals(JobDefOf.PredatorHunt) &&
            p.jobs.curJob.targetA != null && p.jobs.curJob.targetA.Thing != null &&
            p.jobs.curJob.targetA.Thing.Faction == Faction.OfPlayer
        )
        {
            return true;
        }

        return false;
    }
}