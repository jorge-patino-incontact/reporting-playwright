
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Utilities.Clusters;
using Utilities.GBUs;
using Utilities.Objects;

namespace ApiLibrary.Authorization
{
    public class InContactApiAuthorization : BaseAuthorization
    {
        #region Variables

        public string Token { get; set; }
        public string BasicAuthorization { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ResourceBaseUri { get; set; }
        public string TokenWebServiceUrl { get; set; }
        public string ApiScope { get; set; }
        public int AgentId { get; set; }
        public int TeamId { get; set; }
        public int BusNo { get; set; }
        public string RefreshToken { get; set; }

        #endregion

        public InContactApiAuthorization(Cluster cluster, ApiApplication apiApplication = null, string userName = null, string password = null)
        {
            Username = userName ??= cluster.BusinessUnit.Agent[BaseBusinessUnit.Agents.Agent01].Username;
            Password = password ??= cluster.BusinessUnit.Agent[BaseBusinessUnit.Agents.Agent01].Password;
            apiApplication ??= new ApiApplication();
            ApiScope = apiApplication.ApiScope;
            BasicAuthorization = apiApplication.BasicAuthorization;
            ResourceBaseUri = cluster.ResourceBaseUrl;
            TokenWebServiceUrl = cluster.TokenWebServiceUrl;
        }

        public InContactApiAuthorization(string userName, string password, string scope, string accessToken, string resourceBaseUri, string tokenWebServiceUrl, string basicAuthorization)
        {
            Username = userName;
            Password = password;
            ApiScope = scope;
            ResourceBaseUri = resourceBaseUri;
            TokenWebServiceUrl = tokenWebServiceUrl;
            BasicAuthorization = basicAuthorization;
            Token = accessToken;
        }

        private IRestResponse LoginAndRefreshApiToken(string jsonPayload)
        {
            IRestResponse restResponse = null;
            try
            {
                var encodedAuthorization = Convert.ToBase64String(Encoding.UTF8.GetBytes(BasicAuthorization));
                var client = new RestClient(ResourceBaseUri);
                var request = new RestRequest(TokenWebServiceUrl, Method.POST)
                    .AddParameter("Authorization", $"basic {encodedAuthorization}", ParameterType.HttpHeader)
                    .AddJsonBody(jsonPayload);

                restResponse = client.Execute(request);
                if (restResponse.IsSuccessful)
                {
                    dynamic jsonReponse = JObject.Parse(restResponse.Content);
                    Token = jsonReponse.access_token;
                    AgentId = jsonReponse.agent_id;
                    TeamId = jsonReponse.team_id;
                    BusNo = jsonReponse.bus_no;
                    RefreshToken = jsonReponse.refresh_token;
                    TokenWebServiceUrl = jsonReponse.refresh_token_server_uri;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Occured - {0}.  Error parsing json response from URI \"{1}\" ", ex.Message, TokenWebServiceUrl);
            }
            return restResponse;
        }

        public override IRestResponse GetToken()
        {
            var jsonPayload = JsonConvert.SerializeObject(new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", Username },
                { "password", Password },
                { "scope", ApiScope }
            });
            return LoginAndRefreshApiToken(jsonPayload);
        }

        public override IRestResponse UpdateToken()
        {
            var jsonPayload = JsonConvert.SerializeObject(new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "refresh_token", RefreshToken }
            });
            return LoginAndRefreshApiToken(jsonPayload);
        }

        public async override Task<IRestResponse<T>> ExecuteAsync<T>(Method method, string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            IRestResponse<T> restResponse = null;
            try
            {
                restResponse = await new RestClient()
                    .ExecuteAsync<T>(new RestRequest(url, method)
                        .AddHeaders(Headers())
                        .AddJsonBody(jsonPayload ??= JsonConvert.SerializeObject(parameters)));
            }
            catch (Exception e)
            {
                throw new Exception($"Exception Occured - {e.Message}. {method.ToString().ToUpper()}: {url} {3} " +
                    $"returned status code: {(restResponse == null ? "NONE" : restResponse.StatusCode.ToString())}");
            }
            return restResponse;
        }

        public async override Task<IRestResponse> ExecuteAsync(Method method, string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            IRestResponse restResponse = null;
            try
            {
                restResponse = await new RestClient()
                    .ExecuteAsync(new RestRequest(url, method)
                        .AddHeaders(Headers())
                        .AddJsonBody(jsonPayload ??= JsonConvert.SerializeObject(parameters)));
            }
            catch (Exception e)
            {
                throw new Exception($"Exception Occured - {e.Message}. {method.ToString().ToUpper()}: {url} {3} " +
                    $"returned status code: {(restResponse == null ? "NONE" : restResponse.StatusCode.ToString())}");
            }
            return restResponse;
        }

        protected IDictionary<string, string> Headers()
        {
            return new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Authorization", $"Bearer {Token}" },
                { "Accept", "application/json" },
            };
        }
    }

}
