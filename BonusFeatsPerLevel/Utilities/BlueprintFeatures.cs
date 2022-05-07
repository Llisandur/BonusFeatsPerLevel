using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;

namespace BonusFeatsPerLevel.Utilities
{
	/// <summary>
	/// Data class of all relevant selections.
	/// </summary>
	public static class BlueprintFeatures
	{
		public static BlueprintFeatureSelection BasicFeatSelection => BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");
		public static BlueprintFeatureSelection MythicAbilitySelection => BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("ba0e5a900b775be4a99702f1ed08914d");
		public static BlueprintFeatureSelection MythicFeatSelection => BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("9ee0f6745f555484299b0a1563b99d81");
		public static BlueprintFeatureSelection BackgroundsBaseSelection => BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("f926dabeee7f8a54db8f2010b323383c");
		public static BlueprintFeatureSelection FirstAscensionSelection => BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("1421e0034a3afac458de08648d06faf0");
	}
}
