using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiLibrary.Authorization
{
    public interface IAutorization
    {
        IRestResponse GetToken();
        IRestResponse UpdateToken();
        Task<IRestResponse<T>> ExecuteAsync<T>(Method method, string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
        IRestResponse<T> Get<T>(string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
        IRestResponse<T> Post<T>(string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
        IRestResponse<T> Put<T>(string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
        IRestResponse<T> Delete<T>(string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
        IRestResponse<T> Patch<T>(string url, string jsonPayload = null, IDictionary<string, object> parameters = null);

        Task<IRestResponse> ExecuteAsync(Method method, string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
        IRestResponse Get(string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
        IRestResponse Post(string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
        IRestResponse Put(string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
        IRestResponse Delete(string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
        IRestResponse Patch(string url, string jsonPayload = null, IDictionary<string, object> parameters = null);
    }
}
