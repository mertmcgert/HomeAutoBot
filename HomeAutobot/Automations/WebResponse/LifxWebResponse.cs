using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutobot.Automations.WebResponse
{
    public partial class LifxWebResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("connected")]
        public bool Connected { get; set; }

        [JsonProperty("power")]
        public string Power { get; set; }

        [JsonProperty("color")]
        public Color Color { get; set; }

        [JsonProperty("brightness")]
        public double Brightness { get; set; }

        [JsonProperty("group")]
        public Group Group { get; set; }

        [JsonProperty("location")]
        public Group Location { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("last_seen")]
        public DateTimeOffset LastSeen { get; set; }

        [JsonProperty("seconds_since_seen")]
        public long SecondsSinceSeen { get; set; }
    }

    public partial class Color
    {
        [JsonProperty("hue")]
        public long Hue { get; set; }

        [JsonProperty("saturation")]
        public long Saturation { get; set; }

        [JsonProperty("kelvin")]
        public long Kelvin { get; set; }
    }

    public partial class Group
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Product
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("capabilities")]
        public Capabilities Capabilities { get; set; }
    }

    public partial class Capabilities
    {
        [JsonProperty("has_color")]
        public bool HasColor { get; set; }

        [JsonProperty("has_variable_color_temp")]
        public bool HasVariableColorTemp { get; set; }

        [JsonProperty("has_ir")]
        public bool HasIr { get; set; }

        [JsonProperty("has_chain")]
        public bool HasChain { get; set; }

        [JsonProperty("has_multizone")]
        public bool HasMultizone { get; set; }

        [JsonProperty("min_kelvin")]
        public long MinKelvin { get; set; }

        [JsonProperty("max_kelvin")]
        public long MaxKelvin { get; set; }
    }

    public partial class LifxWebResponse
    {
        public static List<LifxWebResponse> FromJson(string json) => JsonConvert.DeserializeObject<List<LifxWebResponse>>(json, HomeAutobot.Automations.WebResponse.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<LifxWebResponse> self) => JsonConvert.SerializeObject(self, HomeAutobot.Automations.WebResponse.Converter.Settings);
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
