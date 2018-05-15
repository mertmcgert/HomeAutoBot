using CommandLine;
using HomeAutobot.Automations;
using System;
using System.Configuration;
using static HomeAutobot.Automations.Nest;

namespace HomeAutomation
{
    class Program
    {
        // Should probably make these tryparse, but I'm only adding this for people who want to disable it
        private static readonly bool ENABLE_TEMP_DISPLAY = bool.Parse(ConfigurationManager.AppSettings["nest_display_temp"]);
        private static readonly int TEMP_DISPLAY_POSITION = Int32.Parse(ConfigurationManager.AppSettings["nest_temp_display_pos"]);
        private static readonly string LIFX_LIGHT_ID = ConfigurationManager.AppSettings["lifx_light_id"];
        private static readonly string HARMONY_SLUG = ConfigurationManager.AppSettings["harmony_slug"];

        static void Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<NestDeviceOptions, HarmonyDeviceOptions, LifxDeviceOptions>(args)
                .MapResult(
                    (NestDeviceOptions opts) => NestOptions(opts),
                    (HarmonyDeviceOptions opts) => HarmonyOptions(opts),
                    (LifxDeviceOptions opts) => LifXOptions(opts),
                    errs =>1
                    );
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Environment.Exit(0);
        }

        static object LifXOptions(LifxDeviceOptions o)
        {
            if (o.Brightness.HasValue)
            {
                var lifx = Lifx.GetCurrentLight(LIFX_LIGHT_ID).GetAwaiter().GetResult();
                var setBrightness = Lifx.SetBrightness(LIFX_LIGHT_ID, lifx.Brightness + o.Brightness.Value).GetAwaiter().GetResult();
            }
            if (o.Color != null)
            {
                Lifx.SetColor(LIFX_LIGHT_ID, o.Color);
            }
            return true;
        }

        static object NestOptions(NestDeviceOptions o)
        {
            if (o.AddToTemp.HasValue)
            {
                long currentTemp = Nest.GetCurrentTemperature();
                var setTemperature = Nest.SetTemperature(currentTemp + o.AddToTemp.Value);
                if (ENABLE_TEMP_DISPLAY) HomeAutobot.StreamDeckHelper.StreamDeckHelper.DrawText(setTemperature.TargetTemperatureF.ToString() + "\x00B0", TEMP_DISPLAY_POSITION);
            }
            if (o.GetTemp != null)
            {
                long currentTemp = Nest.GetCurrentTemperature();
                if (ENABLE_TEMP_DISPLAY) HomeAutobot.StreamDeckHelper.StreamDeckHelper.DrawText(currentTemp.ToString() + "\x00B0", TEMP_DISPLAY_POSITION);
            }
            if (o.HVAC != null)
            {
                var setHVACState = Nest.SetACState((HVACModes)Enum.Parse(typeof(HVACModes), o.HVAC));
            }
            return true;
        }

        static object HarmonyOptions(HarmonyDeviceOptions o)
        {
            if(o.Device != null && o.Command != null)
            {
                Harmony.HarmonyDeviceCommand(HARMONY_SLUG, o.Device, o.Command).GetAwaiter().GetResult();
            }
            if(o.Activity != null)
            {
                Harmony.HarmonyActivityCommand(HARMONY_SLUG, o.Activity).GetAwaiter().GetResult();
            }
            return true;
        }
    }
}
