using HomeAutobot.Automations.WebResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;

namespace HomeAutobot.Automations
{
    public class Lifx
    {
        static string AuthToken = ConfigurationManager.AppSettings["lifx_bearer"];

        // TODO: Just use RestClient instead of HttpClient
        // TODO: Support more than one light
        public static async Task<LifxWebResponse> GetCurrentLight(string lightId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

                    var response = await client.GetAsync("https://api.lifx.com/v1/lights/" + lightId);
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();

                    var rawResult = JsonConvert.DeserializeObject<List<LifxWebResponse>>(stringResult);

                    return rawResult[0];
                }
                catch (HttpRequestException httpRequestException)
                {
                    throw new Exception(httpRequestException.Message);
                }
            }
        }

        public static async Task<string> SetBrightness(string lightId, double brightness)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);
                    string payload = "{\"power\" : \"on\", \"brightness\" : " + brightness + "}";
                    var response = await client.PutAsync("https://api.lifx.com/v1/lights/"+ lightId + "/state", new StringContent(payload, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();

                    var rawResult = JsonConvert.DeserializeObject(stringResult);
                    return stringResult;
                }
                catch (HttpRequestException httpRequestException)
                {
                    Console.WriteLine(httpRequestException.ToString());
                    throw new Exception(httpRequestException.Message);
                }
            }
        }

        public static void SetColor(string lightId, string color)
        {
            var client = new RestClient("https://api.lifx.com/v1/lights/" + lightId + "/state");
            var request = new RestRequest(Method.PUT);
            client.FollowRedirects = false;
            request.AddHeader("Authorization", "Bearer " + AuthToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"color\" : \"" + color + "\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.RedirectKeepVerb) // 307
            {
                client.BaseUrl = new Uri(response.Headers[7].Value.ToString());
                response = client.Execute(request);
            }
        }
    }
}
