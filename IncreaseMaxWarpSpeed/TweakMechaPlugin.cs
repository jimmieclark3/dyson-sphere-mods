using System;
using System.Security;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

[module: UnverifiableCode]

namespace Etherios.DSP.TweakMecha
{

    [BepInPlugin("JClark.DSP.TweakMecha", "TweakMecha", "1.0.0")]
    [BepInProcess("DSPGAME.exe")]
    public class TweakMechaPlugin : BaseUnityPlugin
    {

        // ReSharper disable once MemberCanBePrivate.Global
        public new static ManualLogSource Logger;
        public static bool First = true;

        void Start()
        {
            Logger = base.Logger;
            PluginConfig.Init(Config);

            var harmony = new Harmony("JClark.DSP.TweakMecha");
            harmony.PatchAll(typeof(WarpSpeedPatch));

            Logger.LogInfo($"TweakMecha - loaded with warp speed updated to {PluginConfig.WarpSpeed.Value} {PluginConfig.WarpSpeedType.Value}");
            Logger.LogInfo($"TweakMecha - loaded with cruise speed updated to {PluginConfig.CruiseSpeed.Value} {PluginConfig.CruiseSpeedType.Value}");
        }

        [HarmonyPatch(typeof(PlayerMove_Sail))]
        public class WarpSpeedPatch
        {
            /*
             * Method to dyanmically calculate the new warp speed based on config options.
             **/
            internal static float? convertSpeed(ConfigEntry<double> setting, ConfigEntry<PluginConfig.ESpeed> speedType)
            {
                switch (speedType.Value)
                {
                    case PluginConfig.ESpeed.AU:
                        return (float)Utils.AU(setting.Value);

                    case PluginConfig.ESpeed.LY:
                        return (float)Utils.LY(setting.Value);

                    default:
                        return null;
                }

            }

            //[HarmonyPrefix]
            //[HarmonyPatch(typeof(Player),"GameTick")]
            //public static bool Player_GameTick(Player __instance, long time)
            //{
            //    if (First)
            //    {
            //        TweakMechaOnce(__instance);
            //        First = false;
            //    }

            //    return true;
            //}

            [HarmonyPrefix]
            [HarmonyPatch(typeof(PlayerMove_Sail), "GameTick")]
            public static bool PlayerMove_Sail_GameTick(PlayerMove_Sail __instance, long timei)
            {

                var wspeed = convertSpeed(PluginConfig.WarpSpeed, PluginConfig.WarpSpeedType);

                if (wspeed != null && __instance.player.mecha.maxWarpSpeed != wspeed.Value)
                {
                    Logger.LogInfo($"Warp speed is: {__instance.player.mecha.maxWarpSpeed}");
                    __instance.player.mecha.maxWarpSpeed = wspeed.Value;
                    Logger.LogInfo($"New warp speed is: {__instance.player.mecha.maxWarpSpeed}");
                }

                var cspeed = convertSpeed(PluginConfig.CruiseSpeed, PluginConfig.CruiseSpeedType);
                if (cspeed != null && __instance.player.mecha.maxSailSpeed != cspeed.Value)
                {
                    Logger.LogInfo($"Cruise speed is: {__instance.player.mecha.maxSailSpeed}");
                    __instance.player.mecha.maxSailSpeed = cspeed.Value;
                    Logger.LogInfo($"New Cruise speed is: {__instance.player.mecha.maxSailSpeed}");
                }


                return true;
            }

            public static void TweakMechaOnce(Player __instance)
            {

                //var cspeed = convertSpeed(PluginConfig.CruiseSpeed, PluginConfig.CruiseSpeedType);
                //if (cspeed != null && __instance.player.mecha.maxSailSpeed != cspeed.Value)
                {
                    Logger.LogInfo($"Replenish speed is: {__instance.mecha.reactorPowerGen}");
                    __instance.mecha.reactorPowerGen = __instance.mecha.reactorPowerGen * 1000.0;
                    Logger.LogInfo($"New Replenish speed is: {__instance.mecha.reactorPowerGen}");
                }
            }
        }
    }
}
