/********************
 * 以程序手段处理Defs。
 * --siiftun1857
 */
using Verse;
using RimWorld;
using static Explorite.ExploriteCore;
using System.Diagnostics;
using System.Collections.Generic;

namespace Explorite
{
    [StaticConstructorOnStartup]
    internal static class ExploriteDefsCracker
    {
        static ExploriteDefsCracker()
        {
            //CrackOrangice();
            PostprocessCentaurRecipe();
        }

        static void PostprocessCentaurRecipe()
        {
            if (AlienCentaurDef == null)
                return;
            List<RecipeDef> recipesToRemove = new List<RecipeDef>();

            foreach (RecipeDef recipe in AlienCentaurDef?.recipes)
            {
                if (recipe?.addsHediff == HediffDefOf.LoveEnhancer)
                {
                    recipesToRemove.Add(recipe);
                }
            }

            if (recipesToRemove.Any())
            {
                AlienCentaurDef.recipes.RemoveAll(r => recipesToRemove.Contains(r));
            }
        }

        /*static void CrackOrangice()
        {
            if (OrangiceStuffDef == null)
                return;

            uint solvedCount = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Log.Message("[Explorite]Orangice flooder triggered.");

            foreach (ThingDef thingDef in DefDatabase<ThingDef>.AllDefs)
            {
                if (thingDef?.MadeFromStuff == true &&
                    DefDatabase<ThingDef>.GetNamed($"Blueprint_{thingDef.defName}", false) == null
                    )
                {
                    thingDef.stuffCategories.Add(OrangiceStuffDef);
                }
                solvedCount++;
            }
            foreach (RecipeDef recipe in DefDatabase<RecipeDef>.AllDefs)
            {
                if
                solvedCount++;
            }
            stopwatch.Stop();
            Log.Message($"[Explorite]Orangice flood complete, solved total {solvedCount} ThingDefs, in {stopwatch.ElapsedMilliseconds}ms.");
        }*/

    }


}
