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
        /// <param name="request">The Uri used to request the player data</param>
        /// <returns>The IPlayerModel data</returns>
        IPlayerModel RequestPlayerData(Uri request);
    }
}