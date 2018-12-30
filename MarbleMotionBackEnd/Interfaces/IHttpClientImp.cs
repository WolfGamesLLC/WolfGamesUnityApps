using MarbleMotionBackEnd.Http;
using System;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interfaces defining an <see cref="IHttpClientService"/> implementation
    /// </summary>
    public interface IHttpClientImp
    {
        /// <summary>
        /// Process the request for a <see cref="Uri"/>
        /// </summary>
        /// <param name="request">the <see cref="Uri"/> requested</param>
        /// <returns>the <see cref="WGHttpResponseMessage"/> received</returns>
        WGHttpResponseMessage Request(Uri request);
    }
}