using MarbleMotionBackEnd.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

/// <summary>
/// Implement a non asyncronous http client
/// </summary>
public class NonAsyncHttpClient : MonoBehaviour
{
    private Uri uri;
    private WWW client;

    /// <summary>
    /// Allow access to the response for testing purposes
    /// until I can implement a work around that will let me 
    /// unit test a MonoBehaviour effectively
    /// </summary>
    public WGHttpResponseMessage Response { get; set; }
    
    /// <summary>
    /// Initilaize a syncronous http client
    /// </summary>
    public NonAsyncHttpClient()
    {
        Response = new WGHttpResponseMessage();
    }

    /// <summary>
    /// Request a URI
    /// </summary>
    /// <param name="uri">The URI to request</param>
    /// <returns>The resultant <see cref="HttpResponseMessage"/></returns>
    public WGHttpResponseMessage Request(Uri uri)
    {
        this.uri = uri;

        StartCoroutine(MakeRequest());

        return Response;
    }

    /// <summary>
    /// Convert a <see cref="WWW"/> error text to a <see cref="HttpStatusCode"/>
    /// </summary>
    /// <param name="errorText"></param>
    public void SetStatusCode(string errorText)
    {
        Response.StatusCode = string.IsNullOrEmpty(errorText) ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
    }

    private IEnumerator MakeRequest()
    {
        client = new WWW(uri.ToString());
        yield return client;

        Response = new WGHttpResponseMessage();
        if (! string.IsNullOrEmpty(client.error))
        {
            Response.StatusCode = HttpStatusCode.NotFound;
            Response.ReasonPhrase = client.error;
            Debug.Log("There was an error making the request: " + client.error);
        }
        else
        {
            Debug.Log(client.text);
        }
    }
}
