using CommandLine;

namespace HomeAutomation
{

    [Verb("harmony", HelpText = "harmony issue device command (also used for activity specific commands)")]
    public class HarmonyDeviceOptions
    {
        [Option("device", Required = false, HelpText = "harmony issue device command")]
        public string Device { get; set; }

        [Option("command", Required = false, HelpText = "harmony issue device command")]
        public string Command { get; set; }

        [Option("activity", Required = false, HelpText = "harmony start activity")]
        public string Activity { get; set; }
    }

    [Verb("nest", HelpText = "Nest commands")]
    public class NestDeviceOptions
    {
        #region Nest Options
        [Option("temperature", Required = false, HelpText = "nest set temperature")]
        public long? Temperature { get; set; }

        [Option("gettemp", Required = false, HelpText = "nest get temperature")]
        public long? GetTemp { get; set; }

        [Option("addtotemp", Required = false, HelpText = "nest add or subtract from temperature")]
        public long? AddToTemp { get; set; }

        [Option("hvacmode", Required = false, HelpText = "nest set hvac mode")]
        public string HVAC { get; set; }

        [Option("fan", Required = false, HelpText = "nest set fan duration")]
        public int? Minutes { get; set; }
        #endregion
    }

    [Verb("lifx", HelpText = "Lifx commands")]
    public class LifxDeviceOptions
    {
        [Option("brightness", Required = false, HelpText = "lifx set brightness")]
        public double? Brightness { get; set; }

        [Option("color", Required = false, HelpText = "lifx set color (hex or color name)")]
        public string Color { get; set; }

        [Option("duration", Required = false, HelpText = "lifx set fade duration")]
        public int? Duration { get; set; }
    }
}
