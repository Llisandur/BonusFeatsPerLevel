using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using TabletopTweaks.Core.Utilities;
using static BonusFeatsPerLevel.Main;
using BonusFeatsPerLevel.Utilities;

namespace BonusFeatsPerLevel.NewContent.Classes
{
    static class AdvancedProgressionClass
    {
        public static void CreateAdvancedProgressionClass()
        {
            var BlueprintRoot = BlueprintTools.GetBlueprint<BlueprintRoot>("2d77316c72b9ed44f888ceefc2a131f6");
            BlueprintFeatureSelection BasicFeatSelection = BlueprintFeatures.BasicFeatSelection;
            BlueprintFeatureSelection BackgroundBaseSelection = BlueprintFeatures.BackgroundsBaseSelection;
            

            var Class = Helpers.CreateBlueprint<BlueprintCharacterClass>(ThisModContext, "AdvancedProgressionClass", bp =>
            {
                bp.m_Overrides = new List<string>();
                bp.AddComponent<PrerequisiteNoClassLevel>(c =>
                {
                    c.Group = GroupType.All;
                    c.CheckInProgression = false;
                    c.HideInUI = false;
                    c.m_CharacterClass = BlueprintTools.GetBlueprintReference<BlueprintCharacterClassReference>("4cd1757a0eea7694ba5c933729a53920"); //AnimalClass
                });
                bp.AddComponent<PrerequisiteIsPet>(c =>
                {
                    c.Group = GroupType.All;
                    c.CheckInProgression = false;
                    c.HideInUI = true;
                    c.Not = true;
                });
                bp.LocalizedName = Helpers.CreateString(ThisModContext, $"{bp.name}.Name", "Advanced Progression");
                bp.LocalizedDescription = Helpers.CreateString(ThisModContext, $"{bp.name}.Description", "A class to use with gestalt multiple classes to add extra base feats. DO NOT TAKE AS BASE CLASS.");
                bp.LocalizedDescriptionShort = bp.LocalizedDescription;
                bp.m_Icon = null;
                bp.SkillPoints = 0;
                bp.HitDie = DiceType.Zero;
                bp.HideIfRestricted = false;
                bp.PrestigeClass = true;
                bp.IsMythic = false;
                bp.m_BaseAttackBonus = BlueprintTools.GetBlueprintReference<BlueprintStatProgressionReference>("0538081888b2d8c41893d25d098dee99"); //BABLow
                bp.m_FortitudeSave = BlueprintTools.GetBlueprintReference<BlueprintStatProgressionReference>("dc0c7c1aba755c54f96c089cdf7d14a3"); //SavesLow
                bp.m_ReflexSave = BlueprintTools.GetBlueprintReference<BlueprintStatProgressionReference>("dc0c7c1aba755c54f96c089cdf7d14a3"); //SavesLow
                bp.m_WillSave = BlueprintTools.GetBlueprintReference<BlueprintStatProgressionReference>("dc0c7c1aba755c54f96c089cdf7d14a3"); //SavesLow
                bp.m_Progression = BlueprintTools.GetModBlueprintReference<BlueprintProgressionReference>(ThisModContext, "AdvancedProgressionProgression");
                bp.m_Spellbook = null;
                bp.ClassSkills = new StatType[0];
                bp.IsDivineCaster = false;
                bp.IsArcaneCaster = false;
                bp.m_Archetypes = new BlueprintArchetypeReference[0];
                bp.StartingGold = 0;
                bp.m_StartingItems = new BlueprintItemReference[0];
                bp.PrimaryColor = 0;
                bp.SecondaryColor = 0;
                bp.m_EquipmentEntities = new KingmakerEquipmentEntityReference[0];
                bp.MaleEquipmentEntities = new EquipmentEntityLink[0];
                bp.FemaleEquipmentEntities = new EquipmentEntityLink[0];
                bp.m_Difficulty = 1;
                bp.RecommendedAttributes = new StatType[0];
                bp.NotRecommendedAttributes = new StatType[0];
                bp.m_SignatureAbilities = new BlueprintFeatureReference[] {BlueprintFeatures.BasicFeatSelection.ToReference<BlueprintFeatureReference>()};
                bp.m_DefaultBuild = null;
                bp.m_AdditionalVisualSettings = null;
            });
            var Progression = Helpers.CreateBlueprint<BlueprintProgression>(ThisModContext, "AdvancedProgressionProgression", bp =>
            {
                bp.m_Overrides = new List<string>();
                bp.Components = new BlueprintComponent[0];
                bp.m_AllowNonContextActions = false;
                bp.m_DisplayName = Helpers.CreateString(ThisModContext, $"{bp.name}.Name", "");
                bp.m_Description = Helpers.CreateString(ThisModContext, $"{bp.name}.Description", ""); ;
                bp.m_DescriptionShort = bp.m_Description;
                bp.m_Icon = null;
                bp.HideInUI = false;
                bp.HideInCharacterSheetAndLevelUp = false;
                bp.HideNotAvailibleInUI = false;
                bp.Groups = new FeatureGroup[0];
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = false;
                bp.IsClassFeature = true;
                bp.IsPrerequisiteFor = new List<BlueprintFeatureReference>();
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[]
                {
                    new BlueprintProgression.ClassWithLevel
                    {
                        m_Class = BlueprintTools.GetModBlueprintReference<BlueprintCharacterClassReference>(ThisModContext, "AdvancedProgressionClass")
                    }
                };
                bp.m_Archetypes = new BlueprintProgression.ArchetypeWithLevel[0];
                bp.ForAllOtherClasses = false;
                bp.m_AlternateProgressionClasses = new BlueprintProgression.ClassWithLevel[0];
                bp.AlternateProgressionType = AlternateProgressionType.Div2;
                LevelEntry[] LevelEntries = new LevelEntry[40];
                for (int i = 0; i < 40; i++)
                {
                    LevelEntry Entry = new LevelEntry();
                    Entry.SetFeatures(new List<BlueprintFeatureBase> { BasicFeatSelection });
                    Entry.Level = i + 1;
                    LevelEntries[i] = Entry;
                }
                foreach (LevelEntry Entry in LevelEntries)
                {
                    if (Entry.Level%2 == 0)
                    {
                        Entry.Features.Add(BasicFeatSelection);
                    }
                }
                LevelEntries[0].Features.Add(BackgroundBaseSelection);
                bp.LevelEntries = LevelEntries;
                //bp.LevelEntries = Enumerable.Range(1, 20)
                //    .Select(i => new LevelEntry
                //    {
                //        Level = i,
                //        m_Features = new List<BlueprintFeatureBaseReference>
                //        {
                //            BlueprintFeatures.BasicFeatSelection.ToReference<BlueprintFeatureBaseReference>()
                //        },
                //    })
                //    .ToArray();
                //bp.LevelEntries.Where(entry => entry.Level == 1).First().Features.Add(BackgroundBaseSelection);
                bp.UIGroups = new UIGroup[0];
                bp.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[0];
                bp.m_ExclusiveProgression = null;
                bp.GiveFeaturesForPreviousLevels = false;
                bp.m_FeaturesRankIncrease = null;
            });
 
            if (ThisModContext.Homebrew.Classes.IsDisabled("AdvancedProgressionClass")) { return; }
            BlueprintRoot.Progression.m_CharacterClasses = BlueprintRoot.Progression.m_CharacterClasses.AppendToArray(Class.ToReference<BlueprintCharacterClassReference>());
        }
    }
}
