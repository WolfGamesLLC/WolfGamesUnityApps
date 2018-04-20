using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface to an http client service
    /// </summary>
    public interface IHttpClientService
    {
        /// <summary>
        /// Make a request
        /// </summary>
        /// <param name="request">The Uri to be requested</param>
        /// <returns>The HttpResponseMessage</returns>
        Task<HttpResponseMessage> RequestAsync(Uri request);
    }
}