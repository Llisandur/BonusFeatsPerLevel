using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Utility;
using TabletopTweaks.Core.Utilities;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;
using static BonusFeatsPerLevel.Main;

namespace BonusFeatsPerLevel.NewContent.Feats
{
    static class ExtraBackground
    {
        public static void AddExtraBackground()
        {
            var BackgroundBaseSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("f926dabeee7f8a54db8f2010b323383c");

            var ExtraBackground = FeatTools.CreateExtraSelectionFeat(BFPLContext, "ExtraBackground", BackgroundBaseSelection, bp => {
                bp.SetName(BFPLContext, "Extra Background");
                bp.SetDescription(BFPLContext, "You gain one additional background." +
                    "\nYou can take this feat multiple times. Each time you do, you gain another background.");
                bp.AddPrerequisiteFeature(BackgroundBaseSelection, GroupType.Any);
                bp.GetComponents<PrerequisiteFeature>().ForEach(p => p.Group = GroupType.Any);
            });
            if (BFPLContext.Homebrew.Feats.IsDisabled("ExtraMythicAbility")) { return; }
            FeatTools.AddAsFeat(ExtraBackground);
        }
    }
}
