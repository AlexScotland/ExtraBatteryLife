using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraBatteryLife.Patches
{
    [HarmonyPatch(typeof(VideoCamera))]
    internal class VideoCameraTimeLeftPatch
    {
        // Patching Method
        [HarmonyPatch(typeof(VideoCamera), "ConfigItem")]
        [HarmonyPostfix]
        static void BatteryLevelPatch(ref VideoInfoEntry ___m_recorderInfoEntry)
        {
            float originalMaxTime = 90f; // This is the original value the game has - 90 seconds
            float newMaxTime = 120f; // Let's make it 2 minutes
            if (___m_recorderInfoEntry.maxTime == originalMaxTime && ___m_recorderInfoEntry.timeLeft == originalMaxTime)
            {
                // This is true when we make a new Camera Object
                ___m_recorderInfoEntry.maxTime = newMaxTime;
                ___m_recorderInfoEntry.timeLeft = newMaxTime;
            }
        }
    }
}
