using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace PlantHuman
{
	public class GetPawnThing : MoteThrown
	{
		public override void Tick()
		{
			if (base.Map == null)
			{
				this.Destroy(0);
			}

			if (DebugSettings.godMode)
            {
				PawnKindDef wildMan = PawnKindDefOf.AncientSoldier;
				PawnGenerationRequest pawnGenerationRequest = new PawnGenerationRequest(wildMan, Faction.OfPlayer, PawnGenerationContext.NonPlayer, -1, true, false, false, false, true, false, 20f, false, true, true, false, false, false, false, false, 0, null, 0, null, null, null, null);
				Pawn pawn = PawnGenerator.GeneratePawn(pawnGenerationRequest);
				pawn.ageTracker.AgeBiologicalTicks = 70000000L;
				pawn.relations.ClearAllRelations();
				pawn.health.hediffSet.hediffs.Clear();
				GenSpawn.Spawn(pawn, base.Position, base.Map, 0);

            }
            else
			{
				string defName = this.def.defName.Substring(16);
				PawnKindDef wildMan = DefDatabase<PawnKindDef>.GetNamed(defName);
				PawnGenerationRequest pawnGenerationRequest = new PawnGenerationRequest(wildMan, null, PawnGenerationContext.NonPlayer, -1, true, false, false, false, true, false, 20f, false, true, true, false, false, false, false, false, 0, null, 0, null, null, null, null);
				Pawn pawn = PawnGenerator.GeneratePawn(pawnGenerationRequest);
				pawn.ageTracker.AgeBiologicalTicks = 70000000L;
				pawn.relations.ClearAllRelations();
				pawn.health.hediffSet.hediffs.Clear();
				GenSpawn.Spawn(pawn, base.Position, base.Map, 0);

			}
			this.Destroy(0);
		}
	}
}
