using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarbleMotionXUnitTest.TestingUtilities
{
    /// <summary>
    /// Mock response handler for unit testing of objects that
    /// require response handlers
    /// </summary>
    public class MockResponseHandler : DelegatingHandler
    {
        private readonly IDictionary<Uri, HttpResponseMessage> _mockResponses;

        /// <summary>
        /// Constructor to allow custom responses
        /// </summary>
        public MockResponseHandler(IDictionary<Uri, HttpResponseMessage> responses)
        {
            _mockResponses = responses;
        }

        /// <summary>
        /// Override the SendAsync method so not actual message is sent
        /// </summary>
        /// <param name="request">The request that would be sent</param>
        /// <param name="ct">The cancelation token if provided</param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            if (_mockResponses.ContainsKey(request.RequestUri))
            {
                return Task.FromResult(_mockResponses[request.RequestUri]);
            }
            else
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request });
            }
        }
    }
}
