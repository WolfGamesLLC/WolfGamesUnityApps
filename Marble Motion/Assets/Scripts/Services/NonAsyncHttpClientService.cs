using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MarbleMotionBackEnd.Services;

/// <summary>
/// Class that leverages Unity's <see cref="WWW"/> class to make http requests
/// </summary>
public class NonAsyncHttpClientService : INonAsyncHttpClientService
{
    /// <summary>
    /// Make a request using the supplied HttpClient
    /// </summary>
    /// <param name="request">The Uri to request</param>
    /// <returns>The player data</returns>
    public IPlayerModel RequestPlayerData(Uri request)
    {
        throw new NotImplementedException();
    }
}
