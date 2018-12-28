using MarbleMotionBackEnd.Interfaces;
using System;
using MarbleMotionBackEnd.Http;
using MarbleMotionBackEnd.Models;
using System.Runtime.InteropServices;

namespace MarbleMotionBackEnd.Services
{
    /// <summary>
    /// Class that leverages Unity's <see cref="WWW"/> class to make http requests
    /// </summary>
    public class HttpClientService : IHttpClientService
    {
        private IHttpClientImp httpClientImp;
        private IJsonImp jsonImp;

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="httpClientImp">The <see cref="IHttpClientImp"/> to use when making requests</param>
        /// <param name="jsonImp">The <see cref="IJsonImp"/> to use when converting JSON responses to objects</param>
        public HttpClientService(IHttpClientImp httpClientImp, IJsonImp jsonImp)
        {
            this.httpClientImp = httpClientImp ?? throw new ArgumentNullException(nameof(httpClientImp));
            this.jsonImp = jsonImp ?? throw new ArgumentNullException(nameof(jsonImp));
        }

        /// <summary>
        /// Make a request for player data
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> of the API</param>
        /// <param name="model">The <see cref="IPlayerModel"/> to populate with the result</param>
        public void RequestPlayerData(Uri uri, IPlayerModel model)
        {
            WGHttpResponseMessage responseMessage = httpClientImp.Request(uri);
            jsonImp.PlayerFromJson(responseMessage.Content.Body, model);
        }

        [DllImport("__Internal")]
        private static extern string GetCookies();

        public string HandleGetCookieClicked()
        {
            return GetCookies();
        }
    }
}