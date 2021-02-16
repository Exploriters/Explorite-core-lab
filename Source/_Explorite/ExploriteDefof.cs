/********************
 * 常量文件。
 * --siiftun1857
 */
using HarmonyLib;
using RimWorld;
using Verse;

namespace Explorite
{
    public static partial class ExploriteCore
    {
        public static readonly Harmony harmonyInstance = new Harmony(id: "Explorite.rimworld.mod.HarmonyPatches");

        public static readonly StatDef PawnShieldEnergyMaxDef = DefDatabase<StatDef>.GetNamed("PawnShieldEnergyMax");
        public static readonly StatDef PawnShieldRechargeRateDef = DefDatabase<StatDef>.GetNamed("PawnShieldRechargeRate");


        public static readonly ThingDef AlienCentaurDef = !InstelledMods.RimCentaurs ? null : DefDatabase<ThingDef>.GetNamed("Alien_Centaur");
        public static readonly ThingDef CentaurHeaddressDef = !InstelledMods.RimCentaurs ? null : DefDatabase<ThingDef>.GetNamed("Apparel_CentaurHeaddress");
        public static readonly HediffDef HyperManipulatorHediffDef = !InstelledMods.RimCentaurs ? null : DefDatabase<HediffDef>.GetNamed("HyperManipulator");
        public static readonly HediffDef PsychicDeafHediffDef = !InstelledMods.RimCentaurs ? null : DefDatabase<HediffDef>.GetNamed("PsychicDeafCentaur");
        public static readonly BodyPartDef CentaurScapularDef = !InstelledMods.RimCentaurs ? null : DefDatabase<BodyPartDef>.GetNamed("CentaurScapular");
        public static readonly PawnKindDef CentaurColonistDef = !InstelledMods.RimCentaurs ? null : DefDatabase<PawnKindDef>.GetNamed("CentaurColonist");
        public static readonly FactionDef CentaurPlayerColonyDef = !InstelledMods.RimCentaurs ? null : DefDatabase<FactionDef>.GetNamed("CentaurPlayerColony");
        public static readonly StuffCategoryDef OrangiceStuffDef = !InstelledMods.RimCentaurs ? null : DefDatabase<StuffCategoryDef>.GetNamed("Orangice");

        public static readonly ThingDef AlienSayersDef = !InstelledMods.Sayers ? null : DefDatabase<ThingDef>.GetNamed("Alien_Sayers");
        public static readonly ThingDef AlienFlowerBorhAnimalDef = !InstelledMods.Sayers ? null : DefDatabase<ThingDef>.GetNamed("Alien_FlowerBorhAnimal");
        public static readonly ThingDef FleshTreeDef = !InstelledMods.Sayers ? null : DefDatabase<ThingDef>.GetNamed("Plant_BloodyTree");
        public static readonly ThingDef BloodyTreeMeatDef = !InstelledMods.Sayers ? null : DefDatabase<ThingDef>.GetNamed("BloodyTree_Meat");
        public static readonly ThingDef PlantReactionComputerDef = !InstelledMods.Sayers ? null : DefDatabase<ThingDef>.GetNamed("PlantReactionComputer");
        public static readonly DamageDef InjectionDamageDef = !InstelledMods.Sayers ? null : DefDatabase<DamageDef>.GetNamed("Injection");
        public static readonly HediffDef InjectionHediffDef = !InstelledMods.Sayers ? null : DefDatabase<HediffDef>.GetNamed("Injection");

        //public static readonly Def CentaursScenarioRetroCruiseDef = !(InstelledMods.SoS2 && InstelledMods.RimCentaurs) ? null : DefDatabase<EnemyShipDef>.GetNamed("CentaursScenarioRetroCruise");

        //public static readonly AbilityDef AbilityTrishot_TrishotDef = DefDatabase<AbilityDef>.GetNamed("AbilityTrishot_Trishot");
        //public static readonly AbilityDef AbilityTrishot_IcoshotDef = DefDatabase<AbilityDef>.GetNamed("AbilityTrishot_Icoshot");
        //public static readonly AbilityDef AbilityTrishot_OneshotDef = DefDatabase<AbilityDef>.GetNamed("AbilityTrishot_Oneshot");

        public static readonly Backstory CentaurCivilRetro = BackstoryDatabase.allBackstories.TryGetValue("CentaurCivil_Retro");
        public static readonly Backstory CentaurCivilMayinas = BackstoryDatabase.allBackstories.TryGetValue("Backstory_Mayinas_Exploriter");

    }

}
