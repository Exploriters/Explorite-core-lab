using System.Collections.Generic;
using Verse;
using RimWorld;
using System.Collections;

namespace Explorite
{
    /*
    public class QuestPart_HyperLinks : QuestPart, IEnumerable<Dialog_InfoCard.Hyperlink>
    {
        private List<Dialog_InfoCard.Hyperlink> hyperlinks = new List<Dialog_InfoCard.Hyperlink>();
        public override IEnumerable<Dialog_InfoCard.Hyperlink> Hyperlinks => hyperlinks;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref hyperlinks, "hyperlinks", LookMode.Deep);
        }

        public IEnumerator<Dialog_InfoCard.Hyperlink> GetEnumerator() => hyperlinks.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => hyperlinks.GetEnumerator();
        public void Add(Dialog_InfoCard.Hyperlink hyperlink)
        {
            hyperlinks.Add(hyperlink);
        }
        public void Add(Dialog_InfoCard infoCard, int statIndex = -1)
        {
            hyperlinks.Add(new Dialog_InfoCard.Hyperlink(infoCard, statIndex));
        }
        public void Add(Def def, int statIndex = -1)
        {
            hyperlinks.Add(new Dialog_InfoCard.Hyperlink(def, statIndex));
        }
        public void Add(Thing thing, int statIndex = -1)
        {
            hyperlinks.Add(new Dialog_InfoCard.Hyperlink(thing, statIndex));
        }
        public void Add(RoyalTitleDef titleDef, Faction faction, int statIndex = -1)
        {
            hyperlinks.Add(new Dialog_InfoCard.Hyperlink(titleDef, faction, statIndex));
        }
    }
    */
    public class QuestPart_HyperLinks : QuestPart, IEnumerable<Dialog_InfoCard.Hyperlink>
    {
        public List<Def> defs = new List<Def>();

        public List<Thing> things = new List<Thing>();

        private IEnumerable<Dialog_InfoCard.Hyperlink> cachedHyperlinks;

        public override IEnumerable<Dialog_InfoCard.Hyperlink> Hyperlinks => cachedHyperlinks ??= GetHyperlinks();

        public IEnumerator<Dialog_InfoCard.Hyperlink> GetEnumerator() => Hyperlinks.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Hyperlinks.GetEnumerator();
        public void Add(Def def)
        {
            defs.Add(def);
        }
        public void Add(Thing thing)
        {
            things.Add(thing);
        }

        private IEnumerable<Dialog_InfoCard.Hyperlink> GetHyperlinks()
        {
            if (defs != null)
            {
                for (int j = 0; j < defs.Count; j++)
                {
                    yield return new Dialog_InfoCard.Hyperlink(defs[j]);
                }
            }
            if (things == null)
            {
                yield break;
            }
            for (int j = 0; j < things.Count; j++)
            {
                if (things[j] is Pawn pawn && pawn.royalty != null && pawn.royalty.AllTitlesForReading.Any())
                {
                    RoyalTitle mostSeniorTitle = pawn.royalty.MostSeniorTitle;
                    if (mostSeniorTitle != null)
                    {
                        yield return new Dialog_InfoCard.Hyperlink(mostSeniorTitle.def, mostSeniorTitle.faction);
                    }
                }
            }
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref defs, "defs", LookMode.Undefined);
            Scribe_Collections.Look(ref things, "things", LookMode.Reference);
            if (Scribe.mode == LoadSaveMode.PostLoadInit)
            {
                if (defs == null)
                {
                    defs = new List<Def>();
                }
                defs.RemoveAll((Def x) => x == null);
                if (things == null)
                {
                    things = new List<Thing>();
                }
                things.RemoveAll((Thing x) => x == null);
            }
        }

        public override void ReplacePawnReferences(Pawn replace, Pawn with)
        {
            things.Replace(replace, with);
        }
    }
}