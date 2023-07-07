using System;
using System.Threading.Tasks;
using RestServices;

namespace RutasUI.Helpers
{
    public class ApiService : IApiService
    {
        public async Task<Response> GetList<T>(string controller, bool IsSecure, string Token, string Url, string TokenType, int UserId)
        {
            try
            {
                var restClient = new ServiceClient
                {
                    AccessToken = Token,
                    BaseURL = Url,
                    TokenType = TokenType
                };

                restClient.Headers.Add("X_UID", UserId.ToString());

                var response = await restClient.GetList<T>(controller, IsSecure);

                return new Response
                {
                    IsError = false,
                    Result = response
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsError = true,
                    Message = "Error: " + ex.Message.Replace("\"", "")
                };
            }
        }

        public async Task<Response> Get<T>(string controller, bool IsSecure, string Token, string Url, string TokenType, int UserId, string param = "", string valorParam = "", int? ModelId = null)
        {

            try
            {
                var restClient = new ServiceClient
                {
                    AccessToken = Token,
                    BaseURL = Url,
                    TokenType = TokenType
                };

                restClient.Headers.Add("X_UID", UserId.ToString());

                var paramList = string.Empty;
                if (!string.IsNullOrEmpty(param))
                {
                    string sTemp = string.Empty;
                    string[] sParam = param.Split('^');
                    string[] sVal = valorParam.Split('^');
                    for (int i = 0; i < sParam.Length; i++)
                        restClient.Parameters.Add(sParam[i], sVal[i]);
                }
                restClient.ModelId = ModelId;

                var response = await restClient.Get<T>(controller, IsSecure);

                return new Response
                {
                    IsError = false,
                    Result = response
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsError = true,
                    Message = "Error: " + ex.Message.Replace("\"", "")
                };
            }
        }

        public async Task<Response> Post<T>(string controller, T model, bool IsSecure, string Token, string Url, string TokenType, int UserId, bool IsApi = true)
        {
            try
            {

                var restClient = new ServiceClient
                {
                    AccessToken = Token,
                    BaseURL = Url,
                    TokenType = TokenType
                };

                restClient.Headers.Add("X_UID", UserId.ToString());

                var response = await restClient.Post<T>(controller, model, true);

                return new Response
                {
                    IsError = false,
                    Result = response
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsError = true,
                    Message = ex.Message.Replace("\"",""),
                };
            }
        }

        public async Task<Response> PostRequest<TIn, TOut>(string controller, TIn model, bool IsSecure, string Token, string Url, string TokenType, int UserId, bool IsApi = true)
        {
            try
            {

                var restClient = new ServiceClient
                {
                    AccessToken = Token,
                    BaseURL = Url,
                    TokenType = TokenType
                };

                restClient.Headers.Add("X_UID", UserId.ToString());

                var response = await restClient.PostRequest<TIn, TOut>(controller, model, true);

                return new Response
                {
                    IsError = false,
                    Result = response
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsError = true,
                    Message = ex.Message.Replace("\"", ""),
                };
            }
        }

        public async Task<Response> Put<T>(string controller, T model, bool IsSecure, string Token, string Url, string TokenType, int UserId)
        {
            try
            {

                var restClient = new ServiceClient
                {
                    AccessToken = Token,
                    BaseURL = Url,
                    TokenType = TokenType
                };

                restClient.Headers.Add("X_UID", UserId.ToString());

                var response = await restClient.Put<T>(controller, model.GetHashCode().ToString(), model, true);
                return new Response
                {
                    IsError = false,
                    Result = response
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsError = true,
                    Message = ex.Message.Replace("\"", ""),
                };
            }
        }

        public async Task<Response> Delete<T>(string controller, bool IsSecure, T model, string Token, string Url, string TokenType, int UserId)
        {
            try
            {
                var restClient = new ServiceClient
                {
                    AccessToken = Token,
                    BaseURL = Url,
                    TokenType = TokenType
                };

                restClient.Headers.Add("X_UID", UserId.ToString());
                var response = await restClient.Delete<T>(controller, model.GetHashCode().ToString(), true);

                return new Response
                {
                    IsError = false,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsError = true,
                    Message = ex.Message.Replace("\"", ""),
                };
            }
        }
    }
}
