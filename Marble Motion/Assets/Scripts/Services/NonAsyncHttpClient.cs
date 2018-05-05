using MarbleMotionBackEnd.Http;
using System;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Text;
using UnityEngine;

/// <summary>
/// Implement a non asyncronous http client
/// </summary>
public class NonAsyncHttpClient : MonoBehaviour
{
    private Uri uri;
    private WGHttpResponseMessage response;
    private WWW client;

    /// <summary>
    /// Request a URI
    /// </summary>
    /// <param name="uri">The URI to request</param>
    /// <returns>The resultant <see cref="HttpResponseMessage"/></returns>
    public WGHttpResponseMessage Request(Uri uri)
    {
        this.uri = uri;

        StartCoroutine(MakeRequest());

        return response;
    }

    private IEnumerator MakeRequest()
    {
        client = new WWW(uri.ToString());
        yield return client;

        response = new WGHttpResponseMessage();
        if (! string.IsNullOrEmpty(client.error))
        {
//            response.StatusCode = HttpStatusCode.NotFound;
//            response.ReasonPhrase = client.error;
            Debug.Log("There was an error making the request: " + client.error);
        }
        else
        {
            Debug.Log(client.text);
        }
    }
}
