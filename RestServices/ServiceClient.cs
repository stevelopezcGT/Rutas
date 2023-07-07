using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace RestServices
{
    public class ServiceClient
    {
        public string BaseURL { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string PrefixURL { get; set; }
        public int? ModelId { get; set; }

        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        HttpClient Client;

        public int TimeOut { get; set; }

        public ServiceClient()
        {
            Client = new HttpClient();
            Headers = new Dictionary<string, string>();
            Parameters = new Dictionary<string, string>();
            TimeOut = 40;
        }

        public async Task<List<T>> GetList<T>(string controller, bool IsSecure)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
            if (IsSecure && !string.IsNullOrEmpty(AccessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType,
                                                                        AccessToken);
            }

            foreach (var item in Headers)
                client.DefaultRequestHeaders.Add(item.Key, item.Value);

            client.Timeout = TimeSpan.FromSeconds(TimeOut);

            var url = (!string.IsNullOrEmpty(PrefixURL) ? $"{PrefixURL}/" : "") + $"api/{controller}";
            var response = await client.GetAsync(url);
            var answer = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<T>>(answer);
            }

            var resultError = await response.Content.ReadAsStringAsync();

            throw new Exception(string.IsNullOrEmpty(resultError) ? response.ReasonPhrase : resultError);
        }

        public async Task<T> Get<T>(string controller, bool IsSecure, bool IsApi = true)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
            if (IsSecure && !string.IsNullOrEmpty(AccessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType,
                                                                        AccessToken);
            }
            foreach (var item in Headers)
                client.DefaultRequestHeaders.Add(item.Key, item.Value);

            var paramList = string.Empty;
            foreach (var item in Parameters)
                paramList += $"&{item.Key}={item.Value}";

            if (!string.IsNullOrEmpty(paramList))
                paramList = $"?{paramList.Substring(1)}";

            if (ModelId != null)
                paramList = $"/{ModelId}";

            client.Timeout = TimeSpan.FromSeconds(TimeOut);

            var url = (!string.IsNullOrEmpty(PrefixURL) ? $"{PrefixURL}/" : "") + $"api/{controller}{paramList}";
            if (!IsApi) url = url.Replace("api/", "");
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }

            var resultError = await response.Content.ReadAsStringAsync();

            throw new Exception(string.IsNullOrEmpty(resultError) ? response.ReasonPhrase : resultError);
        }

        public async Task<T> Post<T>(string controller, T model, bool IsSecure, bool IsApi = true)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(
                request,
                Encoding.UTF8,
                "application/json");
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
            if (IsSecure && !string.IsNullOrEmpty(AccessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType,
                                                                        AccessToken);
            }

            foreach (var item in Headers)
                client.DefaultRequestHeaders.Add(item.Key, item.Value);

            client.Timeout = TimeSpan.FromSeconds(TimeOut);

            var url = (!string.IsNullOrEmpty(PrefixURL) ? $"{PrefixURL}/" : "") + $"api/{controller}";
            if (!IsApi) url = url.Replace("api/", "");
            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }

            var resultError = await response.Content.ReadAsStringAsync();

            throw new Exception(string.IsNullOrEmpty(resultError) ? response.ReasonPhrase : resultError);
        }

        public async Task<TOut> PostRequest<TIn, TOut>(string controller, TIn model, bool IsSecure, bool IsApi = true)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(
                    request,
                    Encoding.UTF8,
                    "application/json");
                
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(BaseURL);

                if (IsSecure && !string.IsNullOrEmpty(AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType,
                                                                            AccessToken);
                }

                foreach (var item in Headers)
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);

                client.Timeout = TimeSpan.FromSeconds(TimeOut);

                var url = (!string.IsNullOrEmpty(PrefixURL) ? $"{PrefixURL}/" : "") + $"api/{controller}";
                if (!IsApi) url = url.Replace("api/", "");
                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TOut>(result);
                }
                var resultError = await response.Content.ReadAsStringAsync();

                throw new Exception(string.IsNullOrEmpty(resultError) ? response.ReasonPhrase : resultError);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<T> Put<T>(string controller, string modelId, T model, bool IsSecure, bool IsApi = true)
        {
            var request = JsonConvert.SerializeObject(model);
            //System.Diagnostics.Debug.WriteLine(request);
            var content = new StringContent(
                request,
                Encoding.UTF8, "application/json");
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
            if (IsSecure && !string.IsNullOrEmpty(AccessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType,
                                                                        AccessToken);
            }
            foreach (var item in Headers)
                client.DefaultRequestHeaders.Add(item.Key, item.Value);

            client.Timeout = TimeSpan.FromSeconds(TimeOut);

            var url = (!string.IsNullOrEmpty(PrefixURL) ? $"{PrefixURL}/" : "") + $"api/{controller}/{modelId}";
            if (!IsApi) url = url.Replace("api/", "");
            var response = await client.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }

            var resultError = await response.Content.ReadAsStringAsync();

            throw new Exception(string.IsNullOrEmpty(resultError) ? response.ReasonPhrase : resultError);
        }

        public async Task<T> Patch<T>(string controller, string modelId, T model, bool IsSecure, bool IsApi = true)
        {
            var request = JsonConvert.SerializeObject(model);
            //System.Diagnostics.Debug.WriteLine(request);
            var content = new StringContent(
                request,
                Encoding.UTF8, "application/json");
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
            if (IsSecure && !string.IsNullOrEmpty(AccessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType,
                                                                        AccessToken);
            }
            foreach (var item in Headers)
                client.DefaultRequestHeaders.Add(item.Key, item.Value);

            client.Timeout = TimeSpan.FromSeconds(TimeOut);

            var url = (!string.IsNullOrEmpty(PrefixURL) ? $"{PrefixURL}/" : "") + $"api/{controller}/{modelId}";
            if (!IsApi) url = url.Replace("api/", "");
            var response = await client.PatchAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }

            var resultError = await response.Content.ReadAsStringAsync();

            throw new Exception(string.IsNullOrEmpty(resultError) ? response.ReasonPhrase : resultError);
        }

        public async Task<T> Delete<T>(string controller, string modelId, bool IsSecure, bool IsApi = true)
        {

            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
            if (IsSecure && !string.IsNullOrEmpty(AccessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType,
                                                                        AccessToken);
            }
            foreach (var item in Headers)
                client.DefaultRequestHeaders.Add(item.Key, item.Value);

            client.Timeout = TimeSpan.FromSeconds(TimeOut);

            var url = (!string.IsNullOrEmpty(PrefixURL) ? $"{PrefixURL}/" : "") + $"api/{controller}/{modelId}";
            if (!IsApi) url = url.Replace("api/", "");
            var response = await client.DeleteAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(result);
            }

            var resultError = await response.Content.ReadAsStringAsync();

            throw new Exception(string.IsNullOrEmpty(resultError) ? response.ReasonPhrase : resultError);
        }

        public async Task<T> GetIP<T>()
        {

            var client = new HttpClient
            {
                BaseAddress = new Uri("https://api.ipify.org/")
            };

            var url = $"?format=json";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }

            var resultError = await response.Content.ReadAsStringAsync();

            throw new Exception(string.IsNullOrEmpty(resultError) ? response.ReasonPhrase : resultError);
        }
    }
}