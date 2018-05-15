using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutobot.Automations
{
    public class Harmony
    {
        static string HarmonyUrl = ConfigurationManager.AppSettings["harmony_url"];

        public static async Task<int> HarmonyDeviceCommand(string harmonySlug, string deviceSlug, string commandSlug)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var url = String.Format("{0}/hubs/{1}/devices/{2}/commands/{3}", HarmonyUrl, harmonySlug, deviceSlug, commandSlug);
                    var response = await client.PostAsync(url, new StringContent(""));
                    response.EnsureSuccessStatusCode();

                    return (int) HttpStatusCode.OK;
                }
                catch (HttpRequestException httpRequestException)
                {
                    throw new Exception(httpRequestException.Message);
                }
            }
        }

        public static async Task<int> HarmonyActivityCommand(string harmonySlug, string activitySlug)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var url = String.Format("/hubs/{0}/activities/{1}", harmonySlug, activitySlug);
                    var response = await client.PostAsync(url, new StringContent(null));
                    response.EnsureSuccessStatusCode();

                    return (int)HttpStatusCode.OK;
                }
                catch (HttpRequestException httpRequestException)
                {
                    throw new Exception(httpRequestException.Message);
                }
            }
        }
    }
}
