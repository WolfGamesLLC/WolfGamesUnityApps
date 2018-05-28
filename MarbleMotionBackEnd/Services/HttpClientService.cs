using MarbleMotionBackEnd.Interfaces;
using System;
using MarbleMotionBackEnd.Http;
using MarbleMotionBackEnd.Models;

namespace MarbleMotionBackEnd.Services
{
    /// <summary>
    /// Class that leverages Unity's <see cref="WWW"/> class to make http requests
    /// </summary>
    public class HttpClientService : IHttpClientService
    {
        private IHttpClientImp httpClientImp;
        private IJsonImp jsonImp;

        public HttpClientService(IHttpClientImp httpClientImp, IJsonImp jsonImp)
        {
            this.httpClientImp = httpClientImp ?? throw new ArgumentNullException(nameof(httpClientImp));
            this.jsonImp = jsonImp ?? throw new ArgumentNullException(nameof(jsonImp));
        }

        /// <summary>
        /// Make a request using the supplied HttpClient
        /// </summary>
        /// <param name="request">The Uri to request</param>
        /// <returns>The player data</returns>
        public IPlayerModel RequestPlayerData(Uri request)
        {
            WGHttpResponseMessage responseMessage = httpClientImp.Request(request);
            return jsonImp.PlayerFromJson(responseMessage.Content.Body);
        }
    }
}