using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;
using static BonusFeatsPerLevel.Main;

namespace BonusFeatsPerLevel.NewContent.Feats
{
    static class ExtraMythicFeat
    {
        public static void AddExtraMythicFeat()
        {
            var MythicFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("9ee0f6745f555484299b0a1563b99d81");

            var ExtraMythicFeat = FeatTools.CreateExtraSelectionFeat(ThisModContext, "ExtraMythicFeat", MythicFeatSelection, bp => {
                bp.SetName(ThisModContext, "Extra Mythic Feat");
                bp.SetDescription(ThisModContext, "You gain one additional mythic feat. You must meet the prerequisites for this mythic feat." +
                    "\nYou can take this feat multiple times. Each time you do, you gain another mythic feat.");
                bp.AddPrerequisiteFeature(MythicFeatSelection, GroupType.Any);
                bp.GetComponents<PrerequisiteFeature>().ForEach(p => p.Group = GroupType.Any);
            });
            if (ThisModContext.Homebrew.Feats.IsDisabled("ExtraMythicFeat")) { return; }
            FeatTools.AddAsFeat(ExtraMythicFeat);
        }
    }
}
