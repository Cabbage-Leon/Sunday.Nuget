using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sunday.Nuget.Utility.Helpers
{
    public class GeneralHttpClient : IGeneralHttpClient
    {
        private readonly HttpClient _client;

        public GeneralHttpClient(HttpClient client)
        {
            _client = client;
        }

        public IGeneralHttpClient AddHeaders(string name, string value)
        {
            _client.DefaultRequestHeaders.Add(name, value);
            return this;
        }

        public IGeneralHttpClient RemoveHeader(string name)
        {
            _client.DefaultRequestHeaders.Remove(name);
            return this;
        }

        public IGeneralHttpClient ClearHeader()
        {
            _client.DefaultRequestHeaders.Clear();
            return this;
        }

        public string Get(string uri)
        {
            var response = _client.GetAsync(uri).GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public Tout Get<Tout>(string uri) where Tout : class, new()
        {
            var response = _client.GetAsync(uri).GetAwaiter().GetResult();

#if NET45
            return response.FromJson<Tout>();
#else
            return response.FromJsonAsync<Tout>().GetAwaiter().GetResult();
#endif
        }

        public string Get<Tin>(string uri, Tin tin)
        {
            var response = _client.GetAsync<Tin>(uri, tin).GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public string Get<Tin>(Uri uri, Tin tin)
        {
            var response = _client.GetAsync<Tin>(uri, tin).GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public Tout Get<Tin, Tout>(string uri, Tin tin) where Tout : class, new()
        {
            var response = _client.GetAsync<Tin>(uri, tin).GetAwaiter().GetResult();

#if NET45
            return response.FromJson<Tout>();
#else
            return response.FromJsonAsync<Tout>().GetAwaiter().GetResult();
#endif
        }

        public async Task<string> GetAsync(string uri)
        {
            var response = await _client.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<Tout> GetAsync<Tout>(string uri) where Tout : class, new()
        {
            var response = await _client.GetAsync(uri);
#if NET45
            return response.FromJson<Tout>();
#else
            return await response.FromJsonAsync<Tout>();
#endif
        }

        public async Task<string> GetAsync<Tin>(string uri, Tin tin)
        {
            var response = await _client.GetAsync<Tin>(uri, tin);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAsync<Tin>(Uri uri, Tin tin)
        {
            var response = await _client.GetAsync<Tin>(uri, tin);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<Tout> GetAsync<Tin, Tout>(string uri, Tin tin) where Tout : class, new()
        {
            var response = await _client.GetAsync<Tin>(uri, tin);

#if NET45
            return response.FromJson<Tout>();
#else
            return await response.FromJsonAsync<Tout>();
#endif
        }

        public string Post(string uri)
        {
            var response = _client.PostAsync(uri, new StringContent("")).GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public Tout Post<Tout>(string uri) where Tout : class, new()
        {
            var response = _client.PostAsync(uri, new StringContent("")).GetAwaiter().GetResult();

#if NET45
            return response.FromJson<Tout>();
#else
            return response.FromJsonAsync<Tout>().GetAwaiter().GetResult();
#endif
        }

        public string Post<Tin>(string uri, Tin tin)
        {
            var response = _client.PostJsonAsync<Tin>(uri, tin).GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public string Post<Tin>(Uri uri, Tin tin)
        {
            var response = _client.PostJsonAsync<Tin>(uri, tin).GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public Tout Post<Tin, Tout>(string uri, Tin tin) where Tout : class, new()
        {
            var response = _client.PostJsonAsync<Tin>(uri, tin).GetAwaiter().GetResult();

#if NET45
            return response.FromJson<Tout>();
#else
            return response.FromJsonAsync<Tout>().GetAwaiter().GetResult();
#endif
        }

        public async Task<string> PostAsync(string uri)
        {
            var response = await _client.PostAsync(uri, new StringContent(""));

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<Tout> PostAsync<Tout>(string uri) where Tout : class, new()
        {
            var response = await _client.PostAsync(uri, new StringContent(""));

#if NET45
            return response.FromJson<Tout>();
#else
            return await response.FromJsonAsync<Tout>();
#endif
        }

        public async Task<string> PostAsync<Tin>(string uri, Tin tin)
        {
            var response = await _client.PostJsonAsync<Tin>(uri, tin);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync<Tin>(Uri uri, Tin tin)
        {
            var response = await _client.PostJsonAsync<Tin>(uri, tin);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<Tout> PostAsync<Tin, Tout>(string uri, Tin tin) where Tout : class, new()
        {
            var response = await _client.PostJsonAsync<Tin>(uri, tin);

#if NET45
            return response.FromJson<Tout>();
#else
            return await response.FromJsonAsync<Tout>();
#endif
        }

        public string PostForm<Tin>(string uri, Tin tin)
        {
            var response = _client.PostFormAsync<Tin>(uri, tin).GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public async Task<string> PostFormAsync<Tin>(string uri, Tin tin)
        {
            var response = await _client.PostFormAsync<Tin>(uri, tin);

            return await response.Content.ReadAsStringAsync();
        }

        public Tout PostForm<Tin, Tout>(string uri, Tin tin)
        {
            var response = _client.PostFormAsync<Tin>(uri, tin).GetAwaiter().GetResult();

#if NET45
            return response.FromJson<Tout>();
#else
            return response.FromJsonAsync<Tout>().GetAwaiter().GetResult();
#endif
        }

        public async Task<Tout> PostFormAsync<Tin, Tout>(string uri, Tin tin)
        {
            var response = await _client.PostFormAsync<Tin>(uri, tin);

#if NET45
            return response.FromJson<Tout>();
#else
            return await response.FromJsonAsync<Tout>();
#endif
        }

        #region Send 方法

        private HttpRequestMessage GetHttpRequestMessage<T>(T entity, string uri, HttpMethod method, Dictionary<string, string> headers = null, string contentType = "application/json")
        {
            var request = new HttpRequestMessage(method, uri);
            if (contentType.Contains("x-www-form-urlencoded"))
            {
                var dic = GetContentDic(entity);
                request.Content = new FormUrlEncodedContent(dic);
            }
            else
            {
                request.Content = GetContent(entity, contentType);
            }
            if (headers != null && headers.Keys.Count > 0)
            {
                foreach (var kvp in headers)
                {
                    if (!request.Headers.Contains(kvp.Key))
                    {
                        request.Headers.Add(kvp.Key, kvp.Value);
                    }
                }
            }
            return request;
        }

        private StringContent GetContent<T>(T entity, string contentType = "application/json")
        {
            return new StringContent(entity.ToJson(), Encoding.UTF8, contentType);
        }

        private Dictionary<string, string> GetContentDic<T>(T entity)
        {
            var dic = new Dictionary<string, string>();

            if (entity is string)
            {
                return dic;
            }
            Type t = entity.GetType();
            var properties = t.GetProperties();
            if (properties.Count() > 0)
            {
                foreach (var item in t.GetProperties())
                {
                    var jProperties = item.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                    var name = item.Name;
                    if (jProperties != null && jProperties.Length > 0)
                    {
                        var jProperty = jProperties[0] as JsonPropertyAttribute;
                        if (!jProperty.PropertyName.IsNullOrWhiteSpace())
                        {
                            name = jProperty.PropertyName;
                        }
                    }
                    object propertyValue = item.GetValue(entity, null);
                    if (propertyValue != null)
                    {
                        dic.Add(name, propertyValue.ToString());
                    }
                }
            }
            return dic;
        }

        public string Send(string uri, HttpMethod method, string contentType = "application/json", Dictionary<string, string> headers = null)
        {
            var request = GetHttpRequestMessage<string>(null, uri, method, headers, contentType);
            var response = _client.SendAsync(request).GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public async Task<string> SendAsync(string uri, HttpMethod method, string contentType = "application/json", Dictionary<string, string> headers = null)
        {
            var request = GetHttpRequestMessage<string>(null, uri, method, headers, contentType);
            var response = await _client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public string Send<Tin>(string uri, HttpMethod method, Tin tin, Dictionary<string, string> headers = null)
        {
            var request = GetHttpRequestMessage(tin, uri, method, headers);
            var response = _client.SendAsync(request).GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public async Task<string> SendAsync<Tin>(string uri, HttpMethod method, Tin tin, Dictionary<string, string> headers = null)
        {
            var request = GetHttpRequestMessage(tin, uri, method, headers);
            var response = await _client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public Tout Send<Tout>(string uri, HttpMethod method, string contentType = "application/json", Dictionary<string, string> headers = null) where Tout : class, new()
        {
            var request = GetHttpRequestMessage<string>(null, uri, method, headers, contentType);
            var response = _client.SendAsync(request).GetAwaiter().GetResult();

#if NET45
            return response.FromJson<Tout>();
#else
            return response.FromJsonAsync<Tout>().GetAwaiter().GetResult();
#endif
        }

        public async Task<Tout> SendAsync<Tout>(string uri, HttpMethod method, string contentType = "application/json", Dictionary<string, string> headers = null) where Tout : class, new()
        {
            var request = GetHttpRequestMessage<string>(null, uri, method, headers, contentType);
            var response = await _client.SendAsync(request);

#if NET45
            return response.FromJson<Tout>();
#else
            return await response.FromJsonAsync<Tout>();
#endif
        }

        public Tout Send<Tin, Tout>(string uri, HttpMethod method, Tin tin, Dictionary<string, string> headers = null) where Tout : class, new()
        {
            var request = GetHttpRequestMessage(tin, uri, method, headers);
            var response = _client.SendAsync(request).GetAwaiter().GetResult();

#if NET45
            return response.FromJson<Tout>();
#else
            return response.FromJsonAsync<Tout>().GetAwaiter().GetResult();
#endif
        }

        public async Task<Tout> SendAsync<Tin, Tout>(string uri, HttpMethod method, Tin tin, Dictionary<string, string> headers = null) where Tout : class, new()
        {
            var request = GetHttpRequestMessage(tin, uri, method, headers);
            var response = await _client.SendAsync(request);

#if NET45
            return response.FromJson<Tout>();
#else
            return await response.FromJsonAsync<Tout>();
#endif
        }

        public async Task<Tout> SendAsync<Tin, Tout>(string uri, HttpMethod method, Tin tin, string contentType = "application/json", Dictionary<string, string> headers = null) where Tout : class, new()
        {
            var request = GetHttpRequestMessage(tin, uri, method, headers, contentType);
            var response = await _client.SendAsync(request);

#if NET45
            return response.FromJson<Tout>();
#else
            return await response.FromJsonAsync<Tout>();
#endif
        }

        public Tout Send<Tin, Tout>(string uri, HttpMethod method, Tin tin, string contentType = "application/json", Dictionary<string, string> headers = null) where Tout : class, new()
        {
            var request = GetHttpRequestMessage(tin, uri, method, headers, contentType);
            var response = _client.SendAsync(request).GetAwaiter().GetResult();

#if NET45
            return response.FromJson<Tout>();
#else
            return response.FromJsonAsync<Tout>().GetAwaiter().GetResult();
#endif
        }

        #endregion Send 方法
    }

    public interface IGeneralHttpClient
    {
        string Get(string uri);

        Task<string> GetAsync(string uri);

        Tout Get<Tout>(string uri) where Tout : class, new();

        Task<Tout> GetAsync<Tout>(string uri) where Tout : class, new();

        string Get<Tin>(string uri, Tin tin);

        Task<string> GetAsync<Tin>(string uri, Tin tin);

        string Get<Tin>(Uri uri, Tin tin);

        Task<string> GetAsync<Tin>(Uri uri, Tin tin);

        Tout Get<Tin, Tout>(string uri, Tin tin) where Tout : class, new();

        Task<Tout> GetAsync<Tin, Tout>(string uri, Tin tin) where Tout : class, new();

        string Post(string uri);

        Task<string> PostAsync(string uri);

        Tout Post<Tout>(string uri) where Tout : class, new();

        Task<Tout> PostAsync<Tout>(string uri) where Tout : class, new();

        string Post<Tin>(string uri, Tin tin);

        Task<string> PostAsync<Tin>(string uri, Tin tin);

        string Post<Tin>(Uri uri, Tin tin);

        Task<string> PostAsync<Tin>(Uri uri, Tin tin);

        Tout Post<Tin, Tout>(string uri, Tin tin) where Tout : class, new();

        Task<Tout> PostAsync<Tin, Tout>(string uri, Tin tin) where Tout : class, new();

        string PostForm<Tin>(string uri, Tin tin);

        Task<string> PostFormAsync<Tin>(string uri, Tin tin);

        Tout PostForm<Tin, Tout>(string uri, Tin tin);

        Task<Tout> PostFormAsync<Tin, Tout>(string uri, Tin tin);

        IGeneralHttpClient AddHeaders(string name, string value);

        IGeneralHttpClient RemoveHeader(string name);

        IGeneralHttpClient ClearHeader();

        string Send(string uri, HttpMethod method, string contentType = "application/json", Dictionary<string, string> headers = null);

        Task<string> SendAsync(string uri, HttpMethod method, string contentType = "application/json", Dictionary<string, string> headers = null);

        string Send<Tin>(string uri, HttpMethod method, Tin tin, Dictionary<string, string> headers = null);

        Task<string> SendAsync<Tin>(string uri, HttpMethod method, Tin tin, Dictionary<string, string> headers = null);

        Tout Send<Tout>(string uri, HttpMethod method, string contentType = "application/json", Dictionary<string, string> headers = null) where Tout : class, new();

        Task<Tout> SendAsync<Tout>(string uri, HttpMethod method, string contentType = "application/json", Dictionary<string, string> headers = null) where Tout : class, new();

        Tout Send<Tin, Tout>(string uri, HttpMethod method, Tin tin, Dictionary<string, string> headers = null) where Tout : class, new();

        Task<Tout> SendAsync<Tin, Tout>(string uri, HttpMethod method, Tin tin, Dictionary<string, string> headers = null) where Tout : class, new();

        Tout Send<Tin, Tout>(string uri, HttpMethod method, Tin tin, string contentType = "application/json", Dictionary<string, string> headers = null) where Tout : class, new();

        Task<Tout> SendAsync<Tin, Tout>(string uri, HttpMethod method, Tin tin, string contentType = "application/json", Dictionary<string, string> headers = null) where Tout : class, new();
    }
}