using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductHuntAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductHuntAPI
{
    internal class AsyncHttpClient : IAsyncHttpClient
    {

        private readonly HttpClient vHttpClient;
        public Uri BaseEndpoint { get; private set; }
        public int RequestLimit { get; private set; }
        public bool IsAuthorized { get; private set; }
        public int ResultsPerPage { get; private set; }
        private readonly JsonSerializerSettings vJsonSettings;

        internal AsyncHttpClient(Uri baseEndpoint,int resultsPerPage,JsonSerializerSettings jsonSerializerSettings)
        {
            BaseEndpoint = baseEndpoint ?? throw new ArgumentNullException(nameof(baseEndpoint));
            vJsonSettings = jsonSerializerSettings ?? throw new ArgumentNullException(nameof(jsonSerializerSettings));
            ResultsPerPage = resultsPerPage;
            IsAuthorized = false;
            vHttpClient = new HttpClient();
        }

        /// <summary>  
        /// Common method for making GET calls  
        /// </summary>  
        public async Task<T> GetAsync<T>(Uri requestUrl)
        {
            var response = await vHttpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            IEnumerable<string> values;
            if (response.Headers.TryGetValues("X-Rate-Limit-Remaining", out values))
            {
                
                var value = values.ToList().FirstOrDefault();
                if (!string.IsNullOrEmpty(value))
                {
                    int limit;
                    if (Int32.TryParse(value, out limit))
                    {
                        RequestLimit = limit;
                    }
                }
            }
            return JsonConvert.DeserializeObject<T>(data, vJsonSettings);
        }

        /// <summary>  
        /// Common method for making POST calls  
        /// </summary>  
        public async Task<TR> PostAsync<T,TR>(Uri requestUrl, T content)
        {
            var response = await vHttpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TR>(data,vJsonSettings);
        }

        public Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        public void AddBearerAuthorization(string token)
        {
            AddHeaders("Authorization", "Bearer " + token);
            IsAuthorized = true;
        }

        private void AddHeaders(string header, string value)
        {
            vHttpClient.DefaultRequestHeaders.Remove(header);
            vHttpClient.DefaultRequestHeaders.Add(header, value);
        }
    }
}
