using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MarbleMotionBackEnd.Services
{
    /// <summary>
    /// Service that allows HttpClient requests
    /// </summary>
    public class HttpClientService : IHttpClientService
    {
        private HttpClient _client;

        /// <summary>
        /// Provide Http request support to in game objects
        /// </summary>
        /// <param name="client">The HttpClient that will be used to make the requests</param>
        public HttpClientService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/ion+json"));
        }

        /// <summary>
        /// Make a request using the supplied HttpClient
        /// </summary>
        /// <param name="request">The Uri to request</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> RequestAsync(Uri request)
        {
            return await _client.GetAsync(request);
        }
    }
}