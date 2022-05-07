using HarmonyLib;
using TabletopTweaks.Core.Utilities;
using BonusFeatsPerLevel.ModLogic;
using UnityModManagerNet;

namespace BonusFeatsPerLevel
{
    static class Main
    {
        public static bool Enabled;
        public static ModContextBFPL BFPLContext;
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = new Harmony(modEntry.Info.Id);
            BFPLContext = new ModContextBFPL(modEntry);
            //MAContext.LoadAllSettings();
            BFPLContext.ModEntry.OnSaveGUI = OnSaveGUI;
            BFPLContext.ModEntry.OnGUI = UMMSettingsUI.OnGUI;
            harmony.PatchAll();
            PostPatchInitializer.Initialize(BFPLContext);
            return true;
        }

        static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            BFPLContext.SaveAllSettings();
        }
    }
}
