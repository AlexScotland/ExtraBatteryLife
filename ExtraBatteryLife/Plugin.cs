using BepInEx;
using BepInEx.Logging;
using ExtraBatteryLife.Patches;
using HarmonyLib;

namespace ExtraBatteryLife
{
    [BepInPlugin(
        modGUID,
        modName,
        modVersion
        )]
    public class ExtraBatteryLifeBase : BaseUnityPlugin
    {
        private const string modGUID = "Dug.ExtraBatteryLife";
        private const string modName = "Extra Battery Life";
        private const string modVersion = "1.0.0";

        internal ManualLogSource mls;

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ExtraBatteryLifeBase Instance;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            // Loading Mod message...
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo($"Loading {modName} - {modVersion}");

            harmony.PatchAll(typeof(ExtraBatteryLifeBase));
            harmony.PatchAll(typeof(VideoCameraTimeLeftPatch));
            mls.LogInfo($"{modName} - {modVersion} is loaded!");
        }
    }
}
