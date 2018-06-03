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
        /// Make a request for player data
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> of the API</param>
        /// <param name="model">The <see cref="IPlayerModel"/> to populate with the result</param>
        void RequestPlayerData(Uri uri, IPlayerModel model);
    }
}