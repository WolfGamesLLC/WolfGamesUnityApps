using MarbleMotionBackEnd.Http;
using MarbleMotionBackEnd.Interfaces;
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
public class NonAsyncHttpClient : MonoBehaviour, IHttpClientImp
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
        Response.Content = new WGHttpContent();
        if (Response.IsSuccessStatusCode)
        {
            Debug.Log(client.text);
        }
        else
        {
            Debug.Log("There was an error making the request: " + client.error);
        }

        SetWGHttpResponseMessage(client.error, client.text, client.responseHeaders);
    }

    /// <summary>
    /// All the contents of the <see cref="WWW"/> request to be cpied to the
    /// <see cref="WGHttpResponseMessage"/>
    /// </summary>
    /// <param name="error">The error string from the WWW object</param>
    /// <param name="body">The content text of the WWW object</param>
    /// <param name="headers">The response headers dictionary</param>
    public void SetWGHttpResponseMessage(string error, string body, Dictionary<string, string> headers)
    {
        SetStatusCode(error);
        Response.Content.Body = body;
        Response.ReasonPhrase = error;

        var expectedHeaders = new List<KeyValuePair<string, IEnumerable<string>>>();

        if (headers != null)
        {
            foreach (KeyValuePair<string, string> kvp in headers)
            {
                var expectedValues = new Dictionary<string, IEnumerable<string>>();

                expectedValues.Add(kvp.Key, kvp.Value.Split(' '));
                foreach (KeyValuePair<string, IEnumerable<string>> kvp2 in expectedValues)
                {
                    expectedHeaders.Add(kvp2);
                }
            }
        }
        else
        {
            var expectedValues = new Dictionary<string, IEnumerable<string>>();

            expectedValues.Add("", new List<string>());
            foreach (KeyValuePair<string, IEnumerable<string>> kvp in expectedValues)
            {
                expectedHeaders.Add(kvp);
            }
        }

        Response.Headers = expectedHeaders;
    }
}
