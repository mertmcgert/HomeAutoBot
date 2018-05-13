using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HomeAutobot.Automations.WebResponse.Nest
{
    public class NestTemperatureResponse
    {
        //{"target_temperature_f": 72}
        [JsonProperty("target_temperature_f")]
        public long TargetTemperatureF { get; set; }
    }
    public partial class NestWebResponse
    {
        [JsonProperty("devices")]
        public Devices Devices { get; set; }

        [JsonProperty("structures")]
        public Dictionary<string,Structure> Structures { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }

    public partial class Devices
    {
        [JsonProperty("thermostats")]
        public Dictionary<string, Thermostat> Thermostats { get; set; }
    }

    public partial class Thermostat
    {
        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("temperature_scale")]
        public string TemperatureScale { get; set; }

        [JsonProperty("is_using_emergency_heat")]
        public bool IsUsingEmergencyHeat { get; set; }

        [JsonProperty("has_fan")]
        public bool HasFan { get; set; }

        [JsonProperty("software_version")]
        public string SoftwareVersion { get; set; }

        [JsonProperty("has_leaf")]
        public bool HasLeaf { get; set; }

        [JsonProperty("where_id")]
        public string WhereId { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("can_heat")]
        public bool CanHeat { get; set; }

        [JsonProperty("can_cool")]
        public bool CanCool { get; set; }

        [JsonProperty("target_temperature_c")]
        public long TargetTemperatureC { get; set; }

        [JsonProperty("target_temperature_f")]
        public long TargetTemperatureF { get; set; }

        [JsonProperty("target_temperature_high_c")]
        public long TargetTemperatureHighC { get; set; }

        [JsonProperty("target_temperature_high_f")]
        public long TargetTemperatureHighF { get; set; }

        [JsonProperty("target_temperature_low_c")]
        public long TargetTemperatureLowC { get; set; }

        [JsonProperty("target_temperature_low_f")]
        public long TargetTemperatureLowF { get; set; }

        [JsonProperty("ambient_temperature_c")]
        public long AmbientTemperatureC { get; set; }

        [JsonProperty("ambient_temperature_f")]
        public long AmbientTemperatureF { get; set; }

        [JsonProperty("away_temperature_high_c")]
        public long AwayTemperatureHighC { get; set; }

        [JsonProperty("away_temperature_high_f")]
        public long AwayTemperatureHighF { get; set; }

        [JsonProperty("away_temperature_low_c")]
        public long AwayTemperatureLowC { get; set; }

        [JsonProperty("away_temperature_low_f")]
        public long AwayTemperatureLowF { get; set; }

        [JsonProperty("eco_temperature_high_c")]
        public long EcoTemperatureHighC { get; set; }

        [JsonProperty("eco_temperature_high_f")]
        public long EcoTemperatureHighF { get; set; }

        [JsonProperty("eco_temperature_low_c")]
        public long EcoTemperatureLowC { get; set; }

        [JsonProperty("eco_temperature_low_f")]
        public long EcoTemperatureLowF { get; set; }

        [JsonProperty("is_locked")]
        public bool IsLocked { get; set; }

        [JsonProperty("locked_temp_min_c")]
        public long LockedTempMinC { get; set; }

        [JsonProperty("locked_temp_min_f")]
        public long LockedTempMinF { get; set; }

        [JsonProperty("locked_temp_max_c")]
        public long LockedTempMaxC { get; set; }

        [JsonProperty("locked_temp_max_f")]
        public long LockedTempMaxF { get; set; }

        [JsonProperty("sunlight_correction_active")]
        public bool SunlightCorrectionActive { get; set; }

        [JsonProperty("sunlight_correction_enabled")]
        public bool SunlightCorrectionEnabled { get; set; }

        [JsonProperty("structure_id")]
        public string StructureId { get; set; }

        [JsonProperty("fan_timer_active")]
        public bool FanTimerActive { get; set; }

        [JsonProperty("fan_timer_timeout")]
        public DateTimeOffset FanTimerTimeout { get; set; }

        [JsonProperty("fan_timer_duration")]
        public long FanTimerDuration { get; set; }

        [JsonProperty("previous_hvac_mode")]
        public string PreviousHvacMode { get; set; }

        [JsonProperty("hvac_mode")]
        public string HvacMode { get; set; }

        [JsonProperty("time_to_target")]
        public string TimeToTarget { get; set; }

        [JsonProperty("time_to_target_training")]
        public string TimeToTargetTraining { get; set; }

        [JsonProperty("where_name")]
        public string WhereName { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("name_long")]
        public string NameLong { get; set; }

        [JsonProperty("is_online")]
        public bool IsOnline { get; set; }

        [JsonProperty("last_connection")]
        public DateTimeOffset LastConnection { get; set; }

        [JsonProperty("hvac_state")]
        public string HvacState { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("client_version")]
        public long ClientVersion { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }

    public partial class Structure
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }

        [JsonProperty("thermostats")]
        public List<string> Thermostats { get; set; }

        [JsonProperty("structure_id")]
        public string StructureId { get; set; }

        [JsonProperty("wheres")]
        public Dictionary<string, Where> Wheres { get; set; }
    }

    public partial class Where
    {
        [JsonProperty("where_id")]
        public string WhereId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class NestWebResponse
    {
        public static NestWebResponse FromJson(string json) => JsonConvert.DeserializeObject<NestWebResponse>(json, HomeAutobot.Automations.WebResponse.Nest.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this NestWebResponse self) => JsonConvert.SerializeObject(self, HomeAutobot.Automations.WebResponse.Nest.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
