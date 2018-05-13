using CommandLine;

namespace HomeAutomation
{

    public class Options
    {
        #region LifX Options
        [Option("brightness", Required = false, HelpText = "lifx set brightness")]
        public double? Brightness { get; set; }

        [Option("color", Required = false, HelpText = "lifx set color (hex or color name)")]
        public string Color { get; set; }

        [Option("duration", Required = false, HelpText = "lifx set fade duration")]
        public int? Duration { get; set; }
        #endregion

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
}
