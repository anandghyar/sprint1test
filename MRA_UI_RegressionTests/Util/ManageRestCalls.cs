using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Configuration;

namespace MRA_UI_RegressionTests.Util
{
    public class ManageRestCalls
    {
        public string ReplayAnIncident()
        {
            string CadNumber = null;
            string accessToken = GetOAuthToken();

            try
            {
                RestClient client = new RestClient("https://mobilityapims01.azure-api.net/management/v1/replay/{cadNumberToBeReplayed}");
                RestRequest request = new RestRequest(Method.POST);
                request.AddUrlSegment("cadNumberToBeReplayed", "F2520161");
                request.AddHeader("Authorization", "Bearer " + accessToken);
                request.AddHeader("Ocp-Apim-Subscription-Key", "917c1438265b41af8a307110b7332c8a");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n  \"appliances\": [\r\n    \"MRA001\",\"MRA002\"\r\n  ]\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string responseContent = response.Content;
                var data = (JObject)JsonConvert.DeserializeObject(responseContent);
                CadNumber = data["CadNumber"].Value<string>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
            return CadNumber;
        }

        public string GetOAuthToken()
        {
            string oAuthToken = null;
            var authUrl = ConfigurationManager.AppSettings["authUrl"];
            var refreshToken = ConfigurationManager.AppSettings["refreshToken"];
            var clientId = ConfigurationManager.AppSettings["clientId"];
            var clientSecret = ConfigurationManager.AppSettings["clientSecret"];
            var grantType = ConfigurationManager.AppSettings["grantType"];


            try
            {
                var client = new RestClient(authUrl);
                var request = new RestRequest(Method.POST);

                request.AddParameter("refresh_token", refreshToken);
                request.AddParameter("client_id", clientId);
                request.AddParameter("client_secret", clientSecret);
                request.AddParameter("grant_type", grantType);
               
                IRestResponse response = client.Execute(request);
                string responseContent = response.Content;
                var data = (JObject)JsonConvert.DeserializeObject(responseContent);
                oAuthToken = data["access_token"].Value<string>();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
            return oAuthToken;
        }
    }
}



