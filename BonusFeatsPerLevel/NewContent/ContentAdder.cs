using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using static BonusFeatsPerLevel.Main;

namespace BonusFeatsPerLevel.NewContent
{
    class ContentAdder
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyPriority(799)]
            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;
                ThisModContext.Logger.LogHeader("Loading New Content");

                Classes.AdvancedProgressionClass.CreateAdvancedProgressionClass();
                Feats.ExtraBackground.AddExtraBackground();
                Feats.ExtraMythicAbility.AddExtraMythicAbility();
                Feats.ExtraMythicFeat.AddExtraMythicFeat();
                Classes.NineTailsClass.CreateNineTailsClass();
            }
        }
    }
}
