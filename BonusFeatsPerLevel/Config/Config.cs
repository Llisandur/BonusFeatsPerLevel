using TabletopTweaks.Core.Config;

namespace BonusFeatsPerLevel.Config
{
    public class Homebrew : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup MechanicsChanges = new SettingGroup();
        public SettingGroup Classes = new SettingGroup();
        //public SettingGroup Archetypes = new SettingGroup();
        public SettingGroup Feats = new SettingGroup();
        //public SettingGroup MythicAbilities = new SettingGroup();
        //public SettingGroup MythicFeats = new SettingGroup();

        public void Init()
        {
            //MythicReworks.Init();
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as Homebrew;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            MechanicsChanges.LoadSettingGroup(loadedSettings.MechanicsChanges, NewSettingsOffByDefault);
            //Archetypes.LoadSettingGroup(loadedSettings.Archetypes, NewSettingsOffByDefault);
            Classes.LoadSettingGroup(loadedSettings.Classes, NewSettingsOffByDefault);
            Feats.LoadSettingGroup(loadedSettings.Feats, NewSettingsOffByDefault);
            //MythicAbilities.LoadSettingGroup(loadedSettings.MythicAbilities, NewSettingsOffByDefault);
            //MythicFeats.LoadSettingGroup(loadedSettings.MythicFeats, NewSettingsOffByDefault);
        }
    }
}
