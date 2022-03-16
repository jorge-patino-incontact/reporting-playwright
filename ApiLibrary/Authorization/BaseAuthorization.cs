using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiLibrary.Authorization
{
    public abstract class BaseAuthorization : IAutorization
    {

        public abstract IRestResponse GetToken();
        
        public abstract IRestResponse UpdateToken();
        
        public abstract Task<IRestResponse<T>> ExecuteAsync<T>(Method method, string url, string jsonPayload = null, IDictionary<string, object> parameters = null);

        public abstract Task<IRestResponse> ExecuteAsync(Method method, string url, string jsonPayload = null, IDictionary<string, object> parameters = null);

        public IRestResponse<T> Get<T>(string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            return ExecuteAsync<T>(Method.GET, url, jsonPayload, parameters).Result;
        }

        public IRestResponse Get(string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            return ExecuteAsync(Method.GET, url, jsonPayload, parameters).Result;
        }

        public IRestResponse<T> Post<T>(string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            return ExecuteAsync<T>(Method.POST, url, jsonPayload, parameters).Result;
        }

        public IRestResponse Post(string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            return ExecuteAsync(Method.POST, url, jsonPayload, parameters).Result;
        }
        public IRestResponse<T> Put<T>(string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            return ExecuteAsync<T>(Method.PUT, url, jsonPayload, parameters).Result;
        }

        public IRestResponse Put(string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            return ExecuteAsync(Method.PUT, url, jsonPayload, parameters).Result;
        }

        public IRestResponse<T> Delete<T>(string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            return ExecuteAsync<T>(Method.DELETE, url, jsonPayload, parameters).Result;
        }

        public IRestResponse Delete(string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            return ExecuteAsync(Method.DELETE, url, jsonPayload, parameters).Result;
        }

        public IRestResponse<T> Patch<T>(string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            return ExecuteAsync<T>(Method.PATCH, url, jsonPayload, parameters).Result;
        }

        public IRestResponse Patch(string url, string jsonPayload = null, IDictionary<string, object> parameters = null)
        {
            return ExecuteAsync(Method.PATCH, url, jsonPayload, parameters).Result;
        }
    }
}
