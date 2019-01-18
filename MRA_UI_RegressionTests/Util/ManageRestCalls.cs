using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MRA_UI_RegressionTests.Util
{
    public class ManageRestCalls
    {

        public static string replayUrl = ConfigurationManager.AppSettings["replayUrl"];
        public static string subscription = ConfigurationManager.AppSettings["Ocp-Apim-Subscription-Key"];


        public static string oAuthToken
        {
            get { return GetOAuthToken(); }
        }
        
        //<summary>
        //This method will be used to replay an incident
        //</summary>        
        //<returns>
        //This method returns a string
        //</returns> 
        public static string ReplayAnIncident(int rowNum)
        {
            string cadNumber = null;
            try
            {
                DataPool.PopulateInCollection("Appliances.csv");
                string appliances = DataPool.ReadData(rowNum, "Appliances").Replace(":", ",");
                string replayCadNumber = DataPool.ReadData(rowNum, "CadNumber");
                RestClient client = new RestClient(replayUrl + "{cadNumberToBeReplayed}");
                RestRequest request = new RestRequest(Method.POST);
                request.AddUrlSegment("cadNumberToBeReplayed", replayCadNumber);
                request.AddHeader("Authorization", "Bearer " + oAuthToken);
                request.AddHeader("Ocp-Apim-Subscription-Key", subscription);
                request.AddHeader("Content-Type", "application/json");
               /* request.AddJsonBody(new
                {  appliances = new List<string>() {appliances}
                });*/

                request.AddParameter("undefined", "{\r\n  \"appliances\": [\r\n    "+appliances+"\r\n  ]\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string responseContent = response.Content;
                var data = (JObject)JsonConvert.DeserializeObject(responseContent);
                cadNumber = data["CadNumber"].Value<string>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
            return cadNumber;
        }
        
        //<summary>
        //This method will be used to delete replayed an incident
        //</summary>        
        //<returns>
        //This method returns a string
        //</returns> 
        public static string CancelReplayedJob(string cadNumber)
        {
            string statusCode = null;
            try
            {
                RestClient client = new RestClient(replayUrl + "{cadNumberToBeReplayed}");
                RestRequest request = new RestRequest(Method.DELETE);
                request.AddUrlSegment("replayedCadnumber", cadNumber);
                request.AddHeader("Authorization", "Bearer " + oAuthToken);
                request.AddHeader("Ocp-Apim-Subscription-Key", subscription);
              //  request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                IRestResponse response = client.Execute(request);
                statusCode = response.StatusCode.ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
            return statusCode;
        }

        //<summary>
        //This method is used to get the oAuthToken which will be used in the API call
        //</summary>
        public static string GetOAuthToken()
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



