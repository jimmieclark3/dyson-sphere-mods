using BepInEx.Configuration;

namespace Etherios.DSP.TweakMecha
{
    public static class PluginConfig
    {
        // Config sections
        private static readonly string GENERAL_SECTION = "General";

        // Config types
        public enum ESpeed
        {
            LY,
            AU
        }

        // Config values
        public static ConfigEntry<double> WarpSpeed;
        public static ConfigEntry<double> CruiseSpeed;
        public static ConfigEntry<ESpeed> WarpSpeedType;
        public static ConfigEntry<ESpeed> CruiseSpeedType;

        // Method to initialise config with defaults or read from file.
        internal static void Init(ConfigFile config)
        {
            WarpSpeed = config.Bind(GENERAL_SECTION, "WarpSpeed", 1.0, "Maximum warp speed for the mecha in AUs or LYs based on config. Default is 1 LY");
            WarpSpeedType = config.Bind(GENERAL_SECTION, "WarpSpeedType", ESpeed.LY, "Speed measurement to use for max warp speed. Default is LY.");

            CruiseSpeed = config.Bind(GENERAL_SECTION, "CruiseSpeed", 2000.0, "Maximum cruise speed for the mecha in AUs or LYs based on config. Default is 2000 AU");
            CruiseSpeedType = config.Bind(GENERAL_SECTION, "CruiseSpeedType", ESpeed.AU, "Speed measurement to use for max warp speed. Default is AU.");
        }
    }
}