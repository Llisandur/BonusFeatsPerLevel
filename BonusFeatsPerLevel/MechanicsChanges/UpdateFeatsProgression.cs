using System.Collections.Generic;
using HarmonyLib;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.JsonSystem;
using static BonusFeatsPerLevel.Main;
using BonusFeatsPerLevel.Utilities;

namespace BonusFeatsPerLevel.MechanicsChanges
{
	internal class UpdateFeatsProgression
	{
		private static readonly int numLevels = 40;

		[HarmonyPatch(typeof(BlueprintsCache), "Init")]
		static class BlueprintsCache_Init_Patch
		{
			static bool loaded;

			static void Postfix()
			{
				if (loaded) return;
				loaded = true;

				if (BFPLContext.Homebrew.MechanicsChanges.IsEnabled("BonusFeats") || 
					BFPLContext.Homebrew.MechanicsChanges.IsEnabled("OfflevelFeats"))
				{
					UpdateBasicFeatsProgression();
				}
				if (BFPLContext.Homebrew.MechanicsChanges.IsEnabled("BonusMythicFeats") || 
					BFPLContext.Homebrew.MechanicsChanges.IsEnabled("BonusMythicAbilities") ||
					BFPLContext.Homebrew.MechanicsChanges.IsEnabled("OfflevelMythicFeats") ||
					BFPLContext.Homebrew.MechanicsChanges.IsEnabled("OfflevelMythicAbilities"))
				{
					UpdateMythicProgression(Progressions.MythicCompanionProgression);
					UpdateMythicProgression(Progressions.MythicStartingProgression);
					UpdateMythicProgression(Progressions.AeonProgression);
					UpdateMythicProgression(Progressions.AngelProgression);
					UpdateMythicProgression(Progressions.AzataProgression);
					UpdateMythicProgression(Progressions.DemonProgression);
					UpdateMythicProgression(Progressions.DevilProgression);
					UpdateMythicProgression(Progressions.GoldenDragonProgression);
					UpdateMythicProgression(Progressions.LegendProgression);
					UpdateMythicProgression(Progressions.LichProgression);
					UpdateMythicProgression(Progressions.SwarmThatWalksProgression);
					UpdateMythicProgression(Progressions.TricksterProgression);
				}
			}

			static void UpdateBasicFeatsProgression()
			{
				int AddedFeats = 0;
				int AddedBackgrounds = 0;
				int BonusFeatMultiplier = 4;
				int BonusBackgroundsMultiplier = 2;

				BlueprintProgression BasicFeatsProgression = Progressions.BasicFeatsProgression;
				BlueprintFeatureSelection BasicFeatSelection = BlueprintFeatures.BasicFeatSelection;
				BlueprintFeatureSelection BackgroundsBaseSelection = BlueprintFeatures.BackgroundsBaseSelection;
				IEnumerable<BlueprintFeatureBase> ListBlueprintFeatureBase = new List<BlueprintFeatureBase>
				{
					BasicFeatSelection
				};

				if (BFPLContext.Homebrew.MechanicsChanges.IsEnabled("OfflevelFeats"))
                {
					LevelEntry[] NewEntries = new LevelEntry[numLevels];
					for (int i = 0; i < numLevels; i++)
					{
						if (i < BasicFeatsProgression.LevelEntries.Length && BasicFeatsProgression.LevelEntries[i].Level == i + 1)
						{
							NewEntries[i] = BasicFeatsProgression.LevelEntries[i];
						}
						else
						{
							LevelEntry Entry = new LevelEntry();
							Entry.SetFeatures(ListBlueprintFeatureBase);
							Entry.Level = i + 1;
							NewEntries[i] = Entry;
							AddedFeats++;
						}
					}
					BasicFeatsProgression.LevelEntries = NewEntries;
				}

				if (BFPLContext.Homebrew.MechanicsChanges.IsEnabled("BonusFeats"))
                {
					for (int i = 1; i < BonusFeatMultiplier; i++)
                    {
						LevelEntry[] LevelEntries = BasicFeatsProgression.LevelEntries;
						foreach (LevelEntry Entry in LevelEntries)
						{
							if (Entry.Features.Count > 0)
							{
								if (Entry.Features.Contains(BasicFeatSelection))
								{
									Entry.Features.Add(BasicFeatSelection);
									AddedFeats++;
								}
							}
						}
					}
				}
				if (BFPLContext.Homebrew.MechanicsChanges.IsEnabled("BonusBackgrounds"))
                {
					for (int i = 1; i < BonusBackgroundsMultiplier; i++)
                    {
						LevelEntry [] LevelEntries = BasicFeatsProgression.LevelEntries;
						foreach (LevelEntry Entry in LevelEntries)
                        {
							if (Entry.Features.Count > 0)
                            {
								if (Entry.Features.Contains(BackgroundsBaseSelection))
                                {
									Entry.Features.Add(BackgroundsBaseSelection);
									AddedBackgrounds++;
                                }
                            }
                        }
                    }
                }
				BFPLContext.Logger.Log($"Added {AddedFeats} feat selections to {BasicFeatsProgression.name}");
				BFPLContext.Logger.Log($"Added {AddedBackgrounds} background selections to {BasicFeatsProgression.name}");
			}

			static void UpdateMythicProgression(BlueprintProgression Progression)
			{
				int AddedMythicFeats = 0;
				int AddedMythicAbilities = 0;
				int BonusMythicFeatMultiplier = 2;
				int BonusMythicAbilityMultiplier = 2;

				LevelEntry[] LevelEntries = Progression.LevelEntries;
				BlueprintFeatureSelection MythicAbilitySelection = BlueprintFeatures.MythicAbilitySelection;
				BlueprintFeatureSelection MythicFeatSelection = BlueprintFeatures.MythicFeatSelection;
				foreach (LevelEntry Entry in LevelEntries)
				{
					if (Entry.Features.Count > 0)
					{
						if (BFPLContext.Homebrew.MechanicsChanges.IsEnabled("OfflevelMythicFeats") && !Entry.Features.Contains(MythicFeatSelection))
						{
							Entry.Features.Add(MythicFeatSelection);
							AddedMythicFeats++;
						}
						if (BFPLContext.Homebrew.MechanicsChanges.IsEnabled("OfflevelMythicAbilities") && !Entry.Features.Contains(MythicAbilitySelection))
						{
							Entry.Features.Add(MythicAbilitySelection);
							AddedMythicAbilities++;
						}
					}
				}
				for (int i = 1; i < BonusMythicFeatMultiplier; i++)
                {
					foreach (LevelEntry Entry in LevelEntries)
					{
						if (Entry.Features.Count > 0)
						{
							if (BFPLContext.Homebrew.MechanicsChanges.IsEnabled("BonusMythicFeats") && Entry.Features.Contains(MythicFeatSelection))
							{
								Entry.Features.Add(MythicFeatSelection);
								AddedMythicFeats++;
							}
						}
					}
				}
				for (int i = 1; i < BonusMythicAbilityMultiplier; i++)
                {
					foreach (LevelEntry Entry in LevelEntries)
					{
						if (Entry.Features.Count > 0)
						{
							if (BFPLContext.Homebrew.MechanicsChanges.IsEnabled("BonusMythicAbilities") && Entry.Features.Contains(MythicAbilitySelection))
							{
								Entry.Features.Add(MythicAbilitySelection);
								AddedMythicAbilities++;
							}
						}
					}
				}
				
				BFPLContext.Logger.Log($"Added {AddedMythicFeats} mythic feats to {Progression}");
				BFPLContext.Logger.Log($"Added {AddedMythicAbilities} mythic abilities to {Progression}");
			}
		}
	}
}
