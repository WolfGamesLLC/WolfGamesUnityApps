using System.Collections.Generic;

namespace MarbleMotionBackEnd.Http
{
    /// <summary>
    /// Represent an http file's content
    /// </summary>
    public class WGHttpContent
    {
        /// <summary>
        /// The body of the http file's content
        /// </summary>
        public IEnumerable<char> Body { get; set; }

        /// <summary>
        /// The headers of the http file's content
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> expectedHeaders { get; set; }
    }
}