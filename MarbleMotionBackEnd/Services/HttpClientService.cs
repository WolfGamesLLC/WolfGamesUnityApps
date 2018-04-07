using System;
using System.Net.Http;

namespace MarbleMotionBackEnd.Services
{
    /// <summary>
    /// Service that allows HttpClient requests
    /// </summary>
    public class HttpClientService
    {
        private HttpClient _client;

        /// <summary>
        /// Provide Http request support to in game objects
        /// </summary>
        /// <param name="client">The HttpClient that will be used to make the requests</param>
        public HttpClientService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Make a request using the supplied HttpClient
        /// </summary>
        /// <param name="request">The Uri to request</param>
        /// <returns></returns>
        public HttpResponseMessage Request(Uri request)
        {
            throw new NotImplementedException();
        }
    }
}