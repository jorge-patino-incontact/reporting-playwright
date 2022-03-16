using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Clusters;
using Utilities.GBUs;
using Utilities.Objects.DTO.CXone;

namespace ApiLibrary.Authorization
{
    public class CXoneApiAuthorization : BaseAuthorization
    {
        #region Variables

        public string Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool GetUserDetails { get; set; }
        public string ResourceBaseUri { get; set; }
        public string TokenWebServiceUrl { get; set; }
        public string RefreshToken { get; set; }
        public User User { get; set; }
        public string TenantId { get; set; }
        public string SessionId { get; set; }
        public string AuthCode { get; set; }

        #endregion

        public CXoneApiAuthorization(Cluster cluster, string userName = null, string password = null, bool getUserDetails = true)
        {
            Username = userName ??= cluster.BusinessUnit.Agent[BaseBusinessUnit.Agents.Agent01].Username;
            Password = password ??= cluster.BusinessUnit.Agent[BaseBusinessUnit.Agents.Agent01].Password;
            TokenWebServiceUrl = cluster.CXoneTokenWebServiceUrl;
            ResourceBaseUri = cluster.CXoneDomain;
            GetUserDetails = getUserDetails;
        }

        public override IRestResponse GetToken()
        {
            IRestResponse<LoginResponse> restResponse = null;
            try
            {
                restResponse = Post<LoginResponse>(TokenWebServiceUrl,
                     parameters: new Dictionary<string, object>
                     {
                        { "email", Username },
                        { "password", Password },
                        { "getUserDetails", GetUserDetails.ToString().ToLower() }
                     });
                if (restResponse.IsSuccessful)
                {
                    User = restResponse.Data.user;
                    Token = restResponse.Data.token;
                    RefreshToken = restResponse.Data.refreshToken;
                    TenantId = restResponse.Data.tenantId;
                    SessionId = restResponse.Data.sessionId;
                    AuthCode = restResponse.Data.authCode;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error parsing json response from URI \"{TokenWebServiceUrl}\". \n {e.Message}. .  ");
            }
            return restResponse;
        }

        public override IRestResponse UpdateToken()
        {
            throw new NotImplementedException();
        }

        public override async Task<IRestResponse<T>> ExecuteAsync<T>(Method method, string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
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

        public override async Task<IRestResponse> ExecuteAsync(Method method, string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
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

        private IDictionary<string, string> Headers()
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
