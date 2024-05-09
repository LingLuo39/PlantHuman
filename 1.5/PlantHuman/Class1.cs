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
				PawnGenerationRequest pawnGenerationRequest = new PawnGenerationRequest(wildMan, Faction.OfPlayer, PawnGenerationContext.NonPlayer, -1, true, false, false, false, true,0, false,true,false,true, false,false, false, false,false,0,0,null,0, null, null, null, null, null, null, null, null, null, null, null, null, false, false, false, false, null, null, null, null, null,0f, DevelopmentalStage.Adult, null, null, null,false);
				Pawn pawn = PawnGenerator.GeneratePawn(pawnGenerationRequest);
				pawn.ageTracker.AgeBiologicalTicks = 70000000L;
				pawn.relations.ClearAllRelations();
				pawn.health.hediffSet.hediffs.Clear();
				GenSpawn.Spawn(pawn, base.Position, base.Map, 0);

			}
			else
			{
				string defName = this.def.defName.Substring(15);
                PawnKindDef wildMan = DefDatabase<PawnKindDef>.GetNamed(defName);
                PawnGenerationRequest pawnGenerationRequest = new PawnGenerationRequest(wildMan, null, PawnGenerationContext.NonPlayer, -1, true, false, false, false, true, 0, false, true, false, true, false, false, false, false, false, 0, 0, null, 0, null, null, null, null, null, null, null, null, null, null, null, null, false, false, false, false, null, null, null, null, null, 0f, DevelopmentalStage.Adult, null, null, null, false);
                Pawn pawn = PawnGenerator.GeneratePawn(pawnGenerationRequest);
                pawn.ageTracker.AgeBiologicalTicks = 70000000L;
				pawn.apparel.DestroyAll();
                pawn.relations.ClearAllRelations();
                pawn.health.hediffSet.hediffs.Clear();
                GenSpawn.Spawn(pawn, base.Position, base.Map, 0);

			}
			this.Destroy(0);
		}
	}

	public class GetRandomMeat : MoteThrown
	{
		public override void Tick()
		{

			if (base.Map == null)
			{
				this.Destroy(0);
			}

			for (int i = 0; i < 10; i++)
            {
				FilthMaker.TryMakeFilth(this.Position.RandomAdjacentCell8Way(), this.Map, ThingDefOf.Filth_Blood);
			}
			for (float a = 0; a <0.5f;)
            {
                ThingDef lis = ThingCategoryDefOf.MeatRaw.childThingDefs.RandomElement();
                a += lis.GetStatValueAbstract(StatDefOf.Nutrition);
				GenSpawn.Spawn(lis, base.Position, base.Map);
			}
			this.Destroy(0);
		}
	}

	public class GetRandomVeag : MoteThrown
	{
		public override void Tick()
		{

			if (base.Map == null)
			{
				this.Destroy(0);
			}

			for (int i = 0; i < 10; i++)
			{
				FilthMaker.TryMakeFilth(this.Position.RandomAdjacentCell8Way(), this.Map, ThingDefOf.Filth_Vomit);
			}
			for (float a = 0; a < 0.5f;)
			{
				ThingDef lis = ThingCategoryDefOf.PlantFoodRaw.childThingDefs.RandomElement();
				a += lis.GetStatValueAbstract(StatDefOf.Nutrition);
				GenSpawn.Spawn(lis, base.Position, base.Map);
			}
			this.Destroy(0);
		}
	}

	public class GetRandomEgg : MoteThrown
	{
		public override void Tick()
		{

			if (base.Map == null)
			{
				this.Destroy(0);
			}

			for (int i = 0; i < 10; i++)
			{
				FilthMaker.TryMakeFilth(this.Position.RandomAdjacentCell8Way(), this.Map, ThingDefOf.Filth_Slime);
			}
			for (float a = 0; a < 0.5f;)
			{
				ThingDef lis = ThingCategoryDef.Named("EggsUnfertilized").childThingDefs.RandomElement();
				a += lis.GetStatValueAbstract(StatDefOf.Nutrition);
				GenSpawn.Spawn(lis, base.Position, base.Map);
			}
			this.Destroy(0);
		}
	}

	public class GetRandom10Ca : MoteThrown
	{
		public override void Tick()
		{

			if (base.Map == null)
			{
				this.Destroy(0);
			}
			/*for (int i = 0; i < 10; i++)
			{
				FilthMaker.TryMakeFilth(this.Position.RandomAdjacentCell8Way(), this.Map, ThingDefOf.Filth_Slime);
			}*/
			string aa = this.def.defName.Substring(9);
			for (float a = 0; a < 10;a++)
			{

                ThingDef lis = ThingCategoryDef.Named(aa).childThingDefs.RandomElement();
				//a += lis.GetStatValueAbstract(StatDefOf.Nutrition);
				GenSpawn.Spawn(lis, base.Position, base.Map);
			}
			this.Destroy(0);
		}
	}

}
