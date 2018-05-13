using HomeAutobot.Automations.WebResponse.Nest;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;
using System.Net;

namespace HomeAutobot.Automations
{
    public class Nest
    {
        private static readonly string CLIENTID = ConfigurationManager.AppSettings["nest_client_id"];
        private static readonly string CLIENTSECRET = ConfigurationManager.AppSettings["nest_client_secret"];
        private static readonly string BEARER = ConfigurationManager.AppSettings["nest_bearer"];
        private static readonly string AUTHCODE = ConfigurationManager.AppSettings["nest_auth_code"];
        private static readonly string THERMOSTATID = ConfigurationManager.AppSettings["nest_thermostat_id"];
        public enum HVACModes
        {
            off=0,
            cool=1,
            heat=2
        }

        public static NestWebResponse GetNestWebResponse()
        {
            var client = new RestClient("https://developer-api.nest.com");
            var request = new RestRequest(Method.GET);
            client.FollowRedirects = false;
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + BEARER);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", "client_id=" + CLIENTID + "&client_secret=" + CLIENTSECRET +"&grant_type=authorization_code&code="+AUTHCODE, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.RedirectKeepVerb) // 307
            {
                client.BaseUrl = new Uri(response.Headers[7].Value.ToString());
                response = client.Execute(request);
            }
            return JsonConvert.DeserializeObject<NestWebResponse>(response.Content);
        }

        public static string GetThermostatId()
        {
            return GetNestWebResponse().Devices.Thermostats[THERMOSTATID].DeviceId;
        }

        public static long GetCurrentTemperature()
        {
            return GetNestWebResponse().Devices.Thermostats[THERMOSTATID].TargetTemperatureF;
        }

        // TODO: Refactor this to make a generic web request method that takes a payload, can be used for LifX as well
        public static NestTemperatureResponse SetTemperature(long temperature)
        {
            var client = new RestClient("https://developer-api.nest.com/devices/thermostats/" + THERMOSTATID);
            var request = new RestRequest(Method.PUT);
            client.FollowRedirects = false;
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + BEARER);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"target_temperature_f\":" + temperature + "}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.RedirectKeepVerb) // 307
            {
                client.BaseUrl = new Uri(response.Headers[7].Value.ToString());
                response = client.Execute(request);
            }
            return JsonConvert.DeserializeObject<NestTemperatureResponse>(response.Content);
        }

        public static string SetACState(HVACModes hVAC)
        {
            var client = new RestClient("https://developer-api.nest.com/devices/thermostats/" + THERMOSTATID);
            var request = new RestRequest(Method.PUT);
            client.FollowRedirects = false;
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + BEARER);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"hvac_mode\":\"" + hVAC + "\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.RedirectKeepVerb) // 307
            {
                client.BaseUrl = new Uri(response.Headers[7].Value.ToString());
                response = client.Execute(request);
            }
            return response.Content;
        }
    }
}
