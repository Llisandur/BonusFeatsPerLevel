using TabletopTweaks.Core.ModLogic;
using BonusFeatsPerLevel.Config;
using static UnityModManagerNet.UnityModManager;

namespace BonusFeatsPerLevel.ModLogic
{
    internal class ModContextBFPL : ModContextBase
    {
        public Homebrew Homebrew;

        public ModContextBFPL(ModEntry ModEntry) : base(ModEntry)
        {
#if DEBUG
            Debug = true;
#endif
            LoadAllSettings();
        }
        public override void LoadAllSettings()
        {
            LoadSettings("Homebrew.json", "BonusFeatsPerLevel.Config", ref Homebrew);
            LoadBlueprints("BonusFeatsPerLevel.Config", this);
            LoadLocalization("BonusFeatsPerLevel.Localization");
        }
        public override void AfterBlueprintCachePatches()
        {
            base.AfterBlueprintCachePatches();
            if (Debug)
            {
                //Blueprints.RemoveUnused();
                //SaveSettings(BlueprintsFile, Blueprints);
                //ModLocalizationPack.RemoveUnused();
                //SaveLocalization(ModLocalizationPack);
            }
        }
        public override void SaveAllSettings()
        {
            base.SaveAllSettings();
            SaveSettings("Homebrew.json", Homebrew);
        }
    }
}
