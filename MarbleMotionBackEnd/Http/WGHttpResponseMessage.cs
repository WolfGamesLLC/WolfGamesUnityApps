using System.Collections.Generic;
using System.Net;

namespace MarbleMotionBackEnd.Http
{
    /// <summary>
    /// Represent an http request's response
    /// </summary>
    public class WGHttpResponseMessage
    {
        /// <summary>
        /// The response's content
        /// </summary>
        public WGHttpContent Content { get; set; }

        /// <summary>
        /// The response's header list
        /// </summary>
        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; set; }

        /// <summary>
        /// The response's status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// The response's reason text
        /// </summary>
        public IEnumerable<char> ReasonPhrase { get; set; }
    }
}