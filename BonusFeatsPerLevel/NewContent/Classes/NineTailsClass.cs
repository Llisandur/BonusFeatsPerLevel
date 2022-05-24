using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Root;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.Enums;
using TabletopTweaks.Core.Utilities;
using static BonusFeatsPerLevel.Main;
using BonusFeatsPerLevel.Utilities;

namespace BonusFeatsPerLevel.NewContent.Classes
{
    static class NineTailsClass
    {
        public static void CreateNineTailsClass()
        {
            var BlueprintRoot = BlueprintTools.GetBlueprint<BlueprintRoot>("2d77316c72b9ed44f888ceefc2a131f6");
            #region Feature Reference
            var BasicFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");
            BlueprintFeatureSelection BackgroundBaseSelection = BlueprintFeatures.BackgroundsBaseSelection;
            var ScribingScrolls = BlueprintTools.GetBlueprint<BlueprintFeature>("a8a385bf53ee3454593ce9054375a2ec");
            var BrewPotions = BlueprintTools.GetBlueprint<BlueprintFeature>("c0f8c4e513eb493408b8070a1de93fc0");
            var SkillFocusSelection = BlueprintTools.GetBlueprint<BlueprintFeature>("c9629ef9eebb88b479b2fbc5e836656a");
            var Trapfinding = BlueprintTools.GetBlueprint<BlueprintFeature>("dbb6b3bffe6db3547b31c3711653838e");
            var DangerSenseRogue = BlueprintTools.GetBlueprint<BlueprintFeature>("0bcbe9e450b0e7b428f08f66c53c5136");
            var Evasion = BlueprintTools.GetBlueprint<BlueprintFeature>("576933720c440aa4d8d42b0c54b77e80");
            var ImprovedEvasion = BlueprintTools.GetBlueprint<BlueprintFeature>("ce96af454a6137d47b9c6a1e02e66803");

            #endregion
            #region Create Tails
            var TailArchetypeFeature1 = BlueprintTools.GetBlueprint<BlueprintFeature>("c78a6efed8b2a8e4aacc0f3fb6908d93"); //MagicalTailArchetypeFeature1
            var TailArchetypeFeature2 = BlueprintTools.GetBlueprint<BlueprintFeature>("7e5d817088ee7044190b53d0b78252a0"); //MagicalTailArchetypeFeature2
            var TailArchetypeFeature3 = BlueprintTools.GetBlueprint<BlueprintFeature>("3b80f30290bb4a64ba0d0b16230a4591"); //MagicalTailArchetypeFeature3
            var TailArchetypeFeature4 = BlueprintTools.GetBlueprint<BlueprintFeature>("f082aa7549b5779468be328230aba755"); //MagicalTailArchetypeFeature4
            var TailArchetypeFeature5 = BlueprintTools.GetBlueprint<BlueprintFeature>("51bee12541f1145449eb019948d0ba14"); //MagicalTailArchetypeFeature5
            var TailArchetypeFeature6 = BlueprintTools.GetBlueprint<BlueprintFeature>("9e5a0a071a547bc49afb6340dce50d22"); //MagicalTailArchetypeFeature6
            var TailArchetypeFeature7 = BlueprintTools.GetBlueprint<BlueprintFeature>("a797d7587a4d87149bc71b9b720976d0"); //MagicalTailArchetypeFeature7
            var TailArchetypeFeature8 = BlueprintTools.GetBlueprint<BlueprintFeature>("a47528ef92050b54693b303fc1fbddbe"); //MagicalTailArchetypeFeature8
            var TailArchetypeFeature9 = BlueprintTools.GetBlueprint<BlueprintFeature>("bc5aad8f46c6fdf4ea52b8d4f3d1cd6b"); //MagicalTailArchetypeFeature9

            string TailDesc = "At 3rd level and every 2 levels thereafter, a nine tails gains Magical Tail as a bonus {g|Encyclopedia:Feat}feat{/g}. If the nine tails " +
                "already has nine tails, each additional time the feat is taken, the nine tails gains one additional daily use of the lowest level Magical Tail ability " +
                "not already affected by this effect.";
            var MagicalTailArchetypeFeatureAP1 = TailArchetypeFeature1.CreateCopy(ThisModContext, "MagicalTailArchetypeFeatureAP1", bp => { bp.SetDescription(ThisModContext, TailDesc); });
            var MagicalTailArchetypeFeatureAP2 = TailArchetypeFeature2.CreateCopy(ThisModContext, "MagicalTailArchetypeFeatureAP2", bp => { bp.SetDescription(ThisModContext, TailDesc); });
            var MagicalTailArchetypeFeatureAP3 = TailArchetypeFeature3.CreateCopy(ThisModContext, "MagicalTailArchetypeFeatureAP3", bp => { bp.SetDescription(ThisModContext, TailDesc); });
            var MagicalTailArchetypeFeatureAP4 = TailArchetypeFeature4.CreateCopy(ThisModContext, "MagicalTailArchetypeFeatureAP4", bp => { bp.SetDescription(ThisModContext, TailDesc); });
            var MagicalTailArchetypeFeatureAP5 = TailArchetypeFeature5.CreateCopy(ThisModContext, "MagicalTailArchetypeFeatureAP5", bp => { bp.SetDescription(ThisModContext, TailDesc); });
            var MagicalTailArchetypeFeatureAP6 = TailArchetypeFeature6.CreateCopy(ThisModContext, "MagicalTailArchetypeFeatureAP6", bp => { bp.SetDescription(ThisModContext, TailDesc); });
            var MagicalTailArchetypeFeatureAP7 = TailArchetypeFeature7.CreateCopy(ThisModContext, "MagicalTailArchetypeFeatureAP7", bp => { bp.SetDescription(ThisModContext, TailDesc); });
            var MagicalTailArchetypeFeatureAP8 = TailArchetypeFeature8.CreateCopy(ThisModContext, "MagicalTailArchetypeFeatureAP8", bp => { bp.SetDescription(ThisModContext, TailDesc); });
            var MagicalTailArchetypeFeatureAP9 = TailArchetypeFeature9.CreateCopy(ThisModContext, "MagicalTailArchetypeFeatureAP9", bp => { bp.SetDescription(ThisModContext, TailDesc); });
            #endregion
            #region Create Kitsune Trapfinding
            //string TrapfindingDesc = "A nine tails adds 1/2 their level on {g|Encyclopedia:Perception}Perception checks{/g}.";
            var NineTailsKitsuneTrapfinding = Helpers.CreateBlueprint<BlueprintFeature>(ThisModContext, "NineTailsKitsuneTrapfinding", bp => 
            {
                bp.SetName(ThisModContext, "Kitsune Trapfinding");
                bp.SetDescription(ThisModContext, "Kitsune are always watching for tricks from others, and nine tails are especially vigilant. A nine tails adds " +
                    "1/2 their level on {g|Encyclopedia:Perception}Perception{/g} checks and {g|Encyclopedia:Trickery}Trickery{/g} checks.");
                bp.m_DescriptionShort = Helpers.CreateString(ThisModContext, $"{bp.name}.DescriptionShort","");
                bp.m_Icon = Trapfinding.Icon;
                bp.AddComponent(Helpers.CreateContextRankConfig(c =>
                {
                    c.m_Type = AbilityRankType.Default;
                    c.m_BaseValueType = ContextRankBaseValueType.ClassLevel;
                    c.m_Stat = StatType.Unknown;
                    c.m_SpecificModifier = ModifierDescriptor.None;
                    c.m_Progression = ContextRankProgression.Div2;
                    c.m_StartLevel = 0;
                    c.m_StepLevel = 0;
                    c.m_UseMin = true;
                    c.m_Min = 1;
                    c.m_UseMax = false;
                    c.m_Max = 20;
                    c.m_ExceptClasses = false;
                    c.m_Class = new BlueprintCharacterClassReference[]
                    {
                        BlueprintTools.GetModBlueprintReference<BlueprintCharacterClassReference>(ThisModContext, "NineTailsClass")
                    };
                }));
                bp.AddComponent<AddContextStatBonus>(c =>
                {
                    c.Descriptor = ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.SkillThievery;
                    c.Value = new ContextValue
                    {
                        ValueType = ContextValueType.Rank,
                        Value = 0,
                        ValueRank = AbilityRankType.Default,
                        ValueShared = AbilitySharedValue.Damage,
                        Property = UnitProperty.None
                    };
                });
                bp.AddComponent<AddContextStatBonus>(c =>
                {
                    c.Descriptor |= ModifierDescriptor.UntypedStackable;
                    c.Stat = StatType.SkillPerception;
                    c.Value = new ContextValue
                    {
                        ValueType = ContextValueType.Rank,
                        Value = 0,
                        ValueRank = AbilityRankType.Default,
                        ValueShared = AbilitySharedValue.Damage,
                        Property = UnitProperty.None
                    };
                });
                bp.ReapplyOnLevelUp = true;
                bp.IsClassFeature = true;
            });
            #endregion
            #region Create Kitsune Danger Sense
            var NineTailsKitsuneDangerSense = DangerSenseRogue.CreateCopy(ThisModContext, "NineTailsKitsuneDangerSense", bp =>
            {
                bp.SetName(ThisModContext, "Kitsune Danger Sense");
                bp.SetDescription(ThisModContext, "At 3rd level, a nine tails gains a +1 {g|Encyclopedia:Bonus}bonus{/g} on Reflex {g|Encyclopedia:Saving_Throw}saves{/g} to " +
                    "traps and a +1 dodge bonus to {g|Encyclopedia:Armor_Class}AC{/g} against {g|Encyclopedia:Attack}attacks{/g} made by traps. These bonuses increase by 1 " +
                    "every 3 nine tails levels thereafter (to a maximum of +6 at 18th level).");
            });
            #endregion
            #region Metamagic Knowledge
            var NineTailsMetamagicKnowledge = Helpers.CreateBlueprint<BlueprintFeatureSelection>(ThisModContext, "NineTailsMetamagicKnowledge", bp => {
                bp.SetName(ThisModContext, "Metamagic Knowledge");
                bp.SetDescription(ThisModContext, "At 4th level and every even level thereafter, the nine tails gains a bonus {g|Encyclopedia:Feat}feat{/g} in addition " +
                    "to those gained from normal advancement. These bonus feats must be selected from those listed as metamagic feats. The nine tails must meet the " +
                    "prerequisites of this feat.");
                bp.AddFeatures(FeatTools.GetMetamagicFeats());
                bp.Mode = SelectionMode.OnlyNew;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat };
                bp.IsClassFeature = true;
            });
            #endregion
            #region Focused
            var NineTailsFocused = Helpers.CreateBlueprint<BlueprintFeatureSelection>(ThisModContext, "NineTailsFocused", bp => {
                bp.SetName(ThisModContext, "Focus");
                bp.SetDescription(ThisModContext, "At every level, the nine tails gains a bonus {g|Encyclopedia:Feat}feat{/g} in addition " +
                    "to those gained from normal advancement. These bonus feats must be selected from a selection of magic-related feats. The nine tails must meet the " +
                    "prerequisites of this feat.");
                bp.m_Features = new BlueprintFeatureReference[0];
                bp.Mode = SelectionMode.Default;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat };
                bp.IsClassFeature = true;
            });
            //NineTailsFocused.AddFeatures(BasicFeatSelection.m_AllFeatures
            //    .Select(reference => reference.Get())
            //    .Where(feature => feature.GetComponent<FeatureTagsComponent>().FeatureTags == FeatureTag.Magic)
            //    .ToArray());
            NineTailsFocused.AddFeatures(
                BlueprintTools.GetBlueprintReference<BlueprintFeatureSelectionReference>("8ecee479c6d04c73926c4d95345b9314"), //TTT.Base:ExtraArcanistExploit
                BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("635cb4aa1d924fe0b580449e6cb0396c"), //TTT.Base:ExtraReservoir
                BlueprintTools.GetBlueprintReference<BlueprintParametrizedFeatureReference>("16fa59cc9a72a6043b566b49184f53fe"), //SpellFocus
                BlueprintTools.GetBlueprintReference<BlueprintParametrizedFeatureReference>("5b04b45b228461c43bad768eb0f7c7bf"), //SpellFocusGreater
                BlueprintTools.GetBlueprintReference<BlueprintParametrizedFeatureReference>("03031defb7164fcea949dcc05da1761d") //TTT.Base:VarisianTattooFeature

            );

            #endregion
            #region Greater Focused
            var NineTailsFocusedGreater = Helpers.CreateBlueprint<BlueprintFeatureSelection>(ThisModContext, "NineTailsFocusedGreater", bp => {
                bp.SetName(ThisModContext, "Greater Focus");
                bp.SetDescription(ThisModContext, "At 6th level and every level after, the nine tails gains another bonus {g|Encyclopedia:Feat}feat{/g} in addition " +
                    "to those gained from normal advancement. These bonus feats must be selected from a selection of magic-related feats or from mythic abilities or feats. The nine tails must meet the " +
                    "prerequisites of this feat.");
                bp.m_Features = new BlueprintFeatureReference[0];
                bp.Mode = SelectionMode.Default;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat };
                bp.IsClassFeature = true;
            });
            //NineTailsFocused.AddFeatures(BasicFeatSelection.m_AllFeatures
            //    .Select(reference => reference.Get())
            //    .Where(feature => feature.GetComponent<FeatureTagsComponent>().FeatureTags == FeatureTag.Magic)
            //    .ToArray());
            NineTailsFocusedGreater.AddFeatures(
                BlueprintTools.GetBlueprintReference<BlueprintFeatureSelectionReference>("8ecee479c6d04c73926c4d95345b9314"), //TTT.Base:ExtraArcanistExploit
                BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("635cb4aa1d924fe0b580449e6cb0396c"), //TTT.Base:ExtraReservoir
                BlueprintTools.GetBlueprintReference<BlueprintParametrizedFeatureReference>("16fa59cc9a72a6043b566b49184f53fe"), //SpellFocus
                BlueprintTools.GetBlueprintReference<BlueprintParametrizedFeatureReference>("5b04b45b228461c43bad768eb0f7c7bf"), //SpellFocusGreater
                BlueprintTools.GetBlueprintReference<BlueprintParametrizedFeatureReference>("03031defb7164fcea949dcc05da1761d"), //TTT.Base:VarisianTattooFeature
                BlueprintTools.GetBlueprintReference<BlueprintFeatureSelectionReference>("ba0e5a900b775be4a99702f1ed08914d"), //MythicAbilitySelection
                BlueprintTools.GetBlueprintReference<BlueprintFeatureSelectionReference>("9ee0f6745f555484299b0a1563b99d81") //MythicFeatSelection
                ,BlueprintTools.GetModBlueprintReference<BlueprintFeatureSelectionReference>(ThisModContext, "ExtraMythicAbility"), // ExtraMythicAbility
                BlueprintTools.GetModBlueprintReference<BlueprintFeatureSelectionReference>(ThisModContext, "ExtraMythicFeat") //ExtraMythicFeat


            );

            #endregion

            var Class = Helpers.CreateBlueprint<BlueprintCharacterClass>(ThisModContext, "NineTailsClass", bp =>
            {
                bp.m_Overrides = new List<string>();
                bp.AddComponent<PrerequisiteFeature>(c =>
                {
                    c.Group = GroupType.All;
                    c.CheckInProgression = true;
                    c.HideInUI = false;
                    c.m_Feature = BlueprintTools.GetBlueprint<BlueprintRace>("fd188bb7bb0002e49863aec93bfb9d99").ToReference<BlueprintFeatureReference>(); //KitsuneRace
                });
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
                bp.LocalizedName = Helpers.CreateString(ThisModContext, $"{bp.name}.Name", "Nine Tails");
                bp.LocalizedDescription = Helpers.CreateString(ThisModContext, $"{bp.name}.Description", "Stories often tell of kitsune with multiple tails, " +
                    "but not many realize that fewer than one kitsune in every thousand has this potential, and those that do usually have a magical quirk in " +
                    "their blood or have been blessed by their {g|Encyclopedia:Race}race{/g}'s deific matron.");
                bp.LocalizedDescriptionShort = bp.LocalizedDescription;
                bp.m_Icon = null;
                bp.SkillPoints = 0;
                bp.HitDie = DiceType.D6;
                bp.HideIfRestricted = false;
                bp.PrestigeClass = true;
                bp.IsMythic = false;
                bp.m_BaseAttackBonus = BlueprintTools.GetBlueprintReference<BlueprintStatProgressionReference>("0538081888b2d8c41893d25d098dee99"); //BABLow
                bp.m_FortitudeSave = BlueprintTools.GetBlueprintReference<BlueprintStatProgressionReference>("dc0c7c1aba755c54f96c089cdf7d14a3"); //SavesLow
                bp.m_ReflexSave = BlueprintTools.GetBlueprintReference<BlueprintStatProgressionReference>("dc0c7c1aba755c54f96c089cdf7d14a3"); //SavesLow
                bp.m_WillSave = BlueprintTools.GetBlueprintReference<BlueprintStatProgressionReference>("dc0c7c1aba755c54f96c089cdf7d14a3"); //SavesLow
                bp.m_Progression = BlueprintTools.GetModBlueprintReference<BlueprintProgressionReference>(ThisModContext, "NineTailsProgression");
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
                bp.m_SignatureAbilities = new BlueprintFeatureReference[]
                {
                    NineTailsFocused.ToReference<BlueprintFeatureReference>(),
                    NineTailsMetamagicKnowledge.ToReference<BlueprintFeatureReference>()
                };
                bp.m_DefaultBuild = null;
                bp.m_AdditionalVisualSettings = null;
            });
            var Progression = Helpers.CreateBlueprint<BlueprintProgression>(ThisModContext, "NineTailsProgression", bp =>
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
                        m_Class = BlueprintTools.GetModBlueprintReference<BlueprintCharacterClassReference>(ThisModContext, "NineTailsClass")
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
                    Entry.SetFeatures(new List<BlueprintFeatureBase> { });
                    Entry.Level = i + 1;
                    LevelEntries[i] = Entry;
                }
                foreach (LevelEntry Entry in LevelEntries)
                {
                    Entry.Features.Add(NineTailsFocused);
                    if (Entry.Level == 1)
                    {
                        Entry.Features.Add(ScribingScrolls);
                        Entry.Features.Add(BrewPotions);
                        Entry.Features.Add(BackgroundBaseSelection);
                        Entry.Features.Add(NineTailsKitsuneTrapfinding);
                    }
                    if (Entry.Level <= 2) { Entry.Features.Add(SkillFocusSelection); }
                    if (Entry.Level % 2 == 0) { Entry.Features.Add(BasicFeatSelection); }
                    if (Entry.Level % 3 == 0 && Entry.Level >= 3) { Entry.Features.Add(NineTailsKitsuneDangerSense); }
                    if (Entry.Level % 2 == 0 && Entry.Level >= 4) { Entry.Features.Add(NineTailsMetamagicKnowledge); }
                    if (Entry.Level == 3) { Entry.Features.Add(MagicalTailArchetypeFeatureAP1); }
                    if (Entry.Level == 5) { Entry.Features.Add(MagicalTailArchetypeFeatureAP2); }
                    if (Entry.Level >= 6) { Entry.Features.Add(NineTailsFocusedGreater); }
                    if (Entry.Level == 6) { Entry.Features.Add(Evasion); }
                    if (Entry.Level == 7) { Entry.Features.Add(MagicalTailArchetypeFeatureAP3); }
                    if (Entry.Level == 9) { Entry.Features.Add(MagicalTailArchetypeFeatureAP4); }
                    if (Entry.Level == 11) { Entry.Features.Add(MagicalTailArchetypeFeatureAP5); }
                    if (Entry.Level == 13) { Entry.Features.Add(MagicalTailArchetypeFeatureAP6); }
                    if (Entry.Level == 13) { Entry.Features.Add(ImprovedEvasion); }
                    if (Entry.Level == 15) { Entry.Features.Add(MagicalTailArchetypeFeatureAP7); }
                    if (Entry.Level == 17) { Entry.Features.Add(MagicalTailArchetypeFeatureAP8); }
                    if (Entry.Level == 19) { Entry.Features.Add(MagicalTailArchetypeFeatureAP9); }
                }
                bp.LevelEntries = LevelEntries;
                /* bp.LevelEntries = new LevelEntry[]
                {
                    Helpers.CreateLevelEntry(1, NineTailsFocused, SkillFocusSelection, ScribingScrolls, BrewPotions, BackgroundBaseSelection),
                    Helpers.CreateLevelEntry(2, NineTailsFocused, BasicFeatSelection, SkillFocusSelection),
                    Helpers.CreateLevelEntry(3, NineTailsFocused, MagicalTailArchetypeFeatureAP1),
                    Helpers.CreateLevelEntry(4, NineTailsFocused, BasicFeatSelection, NineTailsMetamagicKnowledge),
                    Helpers.CreateLevelEntry(5, NineTailsFocused, MagicalTailArchetypeFeatureAP2),
                    Helpers.CreateLevelEntry(6, NineTailsFocused, BasicFeatSelection, NineTailsMetamagicKnowledge),
                    Helpers.CreateLevelEntry(7, NineTailsFocused, MagicalTailArchetypeFeatureAP3),
                    Helpers.CreateLevelEntry(8, NineTailsFocused, BasicFeatSelection, NineTailsMetamagicKnowledge),
                    Helpers.CreateLevelEntry(9, NineTailsFocused, MagicalTailArchetypeFeatureAP4),
                    Helpers.CreateLevelEntry(10, NineTailsFocused, BasicFeatSelection, NineTailsMetamagicKnowledge),
                    Helpers.CreateLevelEntry(11, NineTailsFocused, MagicalTailArchetypeFeatureAP5),
                    Helpers.CreateLevelEntry(12, NineTailsFocused, BasicFeatSelection, NineTailsMetamagicKnowledge),
                    Helpers.CreateLevelEntry(13, NineTailsFocused, MagicalTailArchetypeFeatureAP6),
                    Helpers.CreateLevelEntry(14, NineTailsFocused, BasicFeatSelection, NineTailsMetamagicKnowledge),
                    Helpers.CreateLevelEntry(15, NineTailsFocused, MagicalTailArchetypeFeatureAP7),
                    Helpers.CreateLevelEntry(16, NineTailsFocused, BasicFeatSelection, NineTailsMetamagicKnowledge),
                    Helpers.CreateLevelEntry(17, NineTailsFocused, MagicalTailArchetypeFeatureAP8),
                    Helpers.CreateLevelEntry(18, NineTailsFocused, BasicFeatSelection, NineTailsMetamagicKnowledge),
                    Helpers.CreateLevelEntry(19, NineTailsFocused, MagicalTailArchetypeFeatureAP9),
                    Helpers.CreateLevelEntry(20, NineTailsFocused, BasicFeatSelection, NineTailsMetamagicKnowledge)
                }; */
                bp.UIGroups = new UIGroup[]
                {
                    Helpers.CreateUIGroup(Evasion, ImprovedEvasion)
                };
                bp.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[0];
                bp.m_ExclusiveProgression = null;
                bp.GiveFeaturesForPreviousLevels = false;
                bp.m_FeaturesRankIncrease = null;
            });
            

            if (ThisModContext.Homebrew.Classes.IsDisabled("NineTailsClass")) { return; }
            BlueprintRoot.Progression.m_CharacterClasses = BlueprintRoot.Progression.m_CharacterClasses.AppendToArray(Class.ToReference<BlueprintCharacterClassReference>());
        }
    }
}
