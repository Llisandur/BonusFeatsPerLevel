using TabletopTweaks.Core.UMMTools;
using UnityModManagerNet;

namespace BonusFeatsPerLevel
{
    internal static class UMMSettingsUI
    {
        private static int selectedTab;
        public static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            UI.AutoWidth();
            UI.TabBar(ref selectedTab,
                    () => UI.Label("SETTINGS WILL NOT BE UPDATED UNTIL YOU RESTART YOUR GAME.".yellow().bold()),
                    new NamedAction("Homebrew", () => SettingsTabs.Homebrew())
            );
        }
    }

    static class SettingsTabs
    {
        public static void Homebrew()
        {
            var TabLevel = SetttingUI.TabLevel.Zero;
            var Homebrew = Main.ThisModContext.Homebrew;
            UI.Div(0, 15);
            using (UI.VerticalScope())
            {
                UI.Toggle("New Settings Off By Default".bold(), ref Homebrew.NewSettingsOffByDefault);
                UI.Space(25);

                SetttingUI.SettingGroup("MechanicsChanges", TabLevel, Homebrew.MechanicsChanges);
                SetttingUI.SettingGroup("Classes", TabLevel, Homebrew.Classes);
                //SetttingUI.SettingGroup("Archetypes", TabLevel, Homebrew.Archetypes);
                SetttingUI.SettingGroup("Feats", TabLevel, Homebrew.Feats);
                //SetttingUI.SettingGroup("Mythic Abilties", TabLevel, Homebrew.MythicAbilities);
                //SetttingUI.SettingGroup("Mythic Feats", TabLevel, Homebrew.MythicFeats);

                //UI.ValueAdjuster("Feats Multiplier", ref BonusFeatsPerLevel.MechanicsChanges.UpdateFeatsProgression.,, 1, 10);
            }
        }
    }
}
