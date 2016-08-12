using Verse;

namespace BetterVents
{

    public class PlaceWorker_OnWall : PlaceWorker
    {

        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot)
        {
            IntVec3 c = loc;

            Building support = c.GetEdifice();
            if (support == null)
            {
                return (AcceptanceReport)("MessagePlacementOnSupport".Translate());
            }

            if (
                (support.def == null) ||
                (support.def.graphicData == null)
            )
            {
                return (AcceptanceReport)("MessagePlacementOnSupport".Translate());
            }

            return (support.def.graphicData.linkFlags & (LinkFlags.Wall)) != 0
                ? AcceptanceReport.WasAccepted
                    : (AcceptanceReport)("MessagePlacementOnSupport".Translate());
        }

    }

}