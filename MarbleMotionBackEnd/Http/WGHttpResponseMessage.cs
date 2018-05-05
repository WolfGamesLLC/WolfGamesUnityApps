using System.Collections.Generic;

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
    }
}