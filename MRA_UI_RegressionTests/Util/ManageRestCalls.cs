using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRA_UI_RegressionTests.Util
{
    class ManageRestCalls
    {
        public string ReplayAnIncident()
        {
            string CadNumber = null;
            try
            {
                RestClient client = new RestClient("https://mobilityapims01.azure-api.net/management/v1/replay/{cadNumberToBeReplayed}");
                RestRequest request = new RestRequest(Method.POST);
                request.AddUrlSegment("cadNumberToBeReplayed", "F2520161");
                request.AddHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Im5iQ3dXMTF3M1hrQi14VWFYd0tSU0xqTUhHUSIsImtpZCI6Im5iQ3dXMTF3M1hrQi14VWFYd0tSU0xqTUhHUSJ9.eyJhdWQiOiJodHRwczovL21vYmlsaXR5YXBpbXMwMS5henVyZS1hcGkubmV0IiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvNWZmNGNkYjktMWE5Ny00YzFjLTkxMTUtMGZiNWVlNzE1YTY2LyIsImlhdCI6MTU0NjgxOTM5OCwibmJmIjoxNTQ2ODE5Mzk4LCJleHAiOjE1NDY4MjMyOTgsImFjciI6IjEiLCJhaW8iOiJBVVFBdS84SkFBQUFKUFg1cmYzZXV4cktWSmp0QUNqRjJvOGMxdFVEckxVOFhIL09VVUdRa1E4M0hTS0RUaGNwTXRuTWxtTFgzYzdESTNoV1lyKy9BcWxOZ2t2a0NBT1I0UT09IiwiYW1yIjpbInB3ZCJdLCJhcHBpZCI6ImNkZjE0MGYwLTRmZGEtNDBiOS05NDA2LTgwZTc5ZGZlYzZiYiIsImFwcGlkYWNyIjoiMSIsImVtYWlsIjoic21pdGEubmlraGFkZUBpbnRlZ3JhdGlvbnFhLmNvbSIsImlkcCI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0L2E4YTU2ZGIxLTg4NDAtNDc5ZC05M2FjLTJkZmMxNzljNjQ5OS8iLCJpcGFkZHIiOiIyMDIuMTI2Ljg3LjEwMCIsIm5hbWUiOiJzbWl0YS5uaWtoYWRlIiwib2lkIjoiMDQ0ZDJlZWEtZjA5My00NTdkLWE5MDYtMmFmYjUxZjZlZGYzIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiVWk3TERFX3pzSlp2RkpJMnVxdS1BRTgzakV6SGVwMFV5Uzd5ekNLRExYMCIsInRpZCI6IjVmZjRjZGI5LTFhOTctNGMxYy05MTE1LTBmYjVlZTcxNWE2NiIsInVuaXF1ZV9uYW1lIjoic21pdGEubmlraGFkZUBpbnRlZ3JhdGlvbnFhLmNvbSIsInV0aSI6IkZjeTBNVzVjMDAtbDlHTFJ3LUZaQUEiLCJ2ZXIiOiIxLjAifQ.Ovei0ExeP1IpZsNNe20KJk_2RPuKh0PHEl-cgDY6Am23891bgleyZqdY-uE9d5iq-sfMJQ9xzC3B3_MZXjyLNTC5ABnHEmchZV4_4twZg0bolo3u1dAiMbnCUphuesU3xj8IRB4IPnZ3eHxr0eZInlAVsc4u9IHMFhkNxBBSeGOnD4Gc34r7j3tVFBOMhIzhnZyfFjny204gPUoraYrdJn6PLY1HFuYJdgTeiySgPmnd-15Cq_V7MjkyJ6f3epgRdUuXPX4ipoLKCXPPQquxAIxKpIVzbks6MI5YMyiNIl-ySwZGlC27pRkhtm3acSd-8RzZeojoKVI83bHMWu024Q");
                request.AddHeader("Ocp-Apim-Subscription-Key", "917c1438265b41af8a307110b7332c8a");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\r\n  \"appliances\": [\r\n    \"MRA001\",\"MRA002\"\r\n  ]\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string json = response.Content;
                var data = (JObject)JsonConvert.DeserializeObject(json);
                CadNumber = data["CadNumber"].Value<string>();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception occured " + e);
            }
            return CadNumber;
        }

    }
}

