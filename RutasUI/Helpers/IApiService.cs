using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestServices;

namespace RutasUI.Helpers
{
    public interface IApiService
    {
        Task<Response> GetList<T>(string controller, bool IsSecure, string Token, string Url, string TokenType, int UserId);
        Task<Response> Get<T>(string controller, bool IsSecure, string Token, string Url, string TokenType, int UserId, string param = "", string valorParam = "", int? ModelId = null);
        Task<Response> Post<T>(string controller, T model, bool IsSecure, string Token, string Url, string TokenType, int UserId, bool IsApi = true);
        Task<Response> PostRequest<TIn, TOut>(string controller, TIn model, bool IsSecure, string Token, string Url, string TokenType, int UserId, bool IsApi = true);
        Task<Response> Put<T>(string controller, T model, bool IsSecure, string Token, string Url, string TokenType, int UserId);
        Task<Response> Delete<T>(string controller, bool IsSecure, T model, string Token, string Url, string TokenType, int UserId);
    }
}
