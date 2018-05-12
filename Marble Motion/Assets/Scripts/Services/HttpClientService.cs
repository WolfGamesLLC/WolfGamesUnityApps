using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MarbleMotionBackEnd.Services;
using MarbleMotionBackEnd.Http;
using MarbleMotionBackEnd.Models;

/// <summary>
/// Class that leverages Unity's <see cref="WWW"/> class to make http requests
/// </summary>
public class HttpClientService : IHttpClientService
{
    private IHttpClientImp httpClientImp;
    private IJsonImp jsonImp;

    public HttpClientService(IHttpClientImp httpClientImp, IJsonImp jsonImp)
    {
        if (httpClientImp == null)
        {
            throw new ArgumentNullException(nameof(httpClientImp));
        }

        if (jsonImp == null)
        {
            throw new ArgumentNullException(nameof(jsonImp));
        }

        this.httpClientImp = httpClientImp;
        this.jsonImp = jsonImp;
    }

    /// <summary>
    /// Make a request using the supplied HttpClient
    /// </summary>
    /// <param name="request">The Uri to request</param>
    /// <returns>The player data</returns>
    public IPlayerModel RequestPlayerData(Uri request)
    {
        WGHttpResponseMessage responseMessage = httpClientImp.Request(request);
        return jsonImp.FromJson<IPlayerModel>(responseMessage.Content.Body);
    }
}
