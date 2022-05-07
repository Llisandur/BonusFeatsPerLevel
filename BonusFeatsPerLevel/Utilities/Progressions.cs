using Kingmaker.Blueprints.Classes;
using TabletopTweaks.Core.Utilities;

namespace BonusFeatsPerLevel.Utilities
{
	/// <summary>
	/// Data class of all relevant progressions.
	/// </summary>
	public static class Progressions
	{
		public static BlueprintProgression BasicFeatsProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("5b72dd2ca2cb73b49903806ee8986325");
		public static BlueprintProgression MythicCompanionProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("21e74c19da02acb478e32da25abd9d28");
		public static BlueprintProgression MythicStartingProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("af4ee0acb9114e544bf02f39027966b0");
		public static BlueprintProgression AeonProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("34b9484b0d5ce9340ae51d2bf9518bbe");
		public static BlueprintProgression AngelProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("2f6fe889e91b6a645b055696c01e2f74");
		public static BlueprintProgression AzataProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("9db53de4bf21b564ca1a90ff5bd16586");
		public static BlueprintProgression DemonProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("285fe49f7df8587468f676aa49362213");
		public static BlueprintProgression DevilProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("87bc9abf00b240a44bb344fea50ec9bc");
		public static BlueprintProgression GoldenDragonProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("a6fbca43902c6194c947546e89af64bd");
		public static BlueprintProgression LegendProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("905383229aaf79e4b8d7e2d316b68715");
		public static BlueprintProgression LichProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("ccec4e01b85bf5d46a3c3717471ba639");
		public static BlueprintProgression SwarmThatWalksProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("bf5f103ccdf69254abbad84fd371d5c9");
		public static BlueprintProgression TricksterProgression => BlueprintTools.GetBlueprint<BlueprintProgression>("cc64789b0cc5df14b90da1ffee7bbeea");
	}
}
