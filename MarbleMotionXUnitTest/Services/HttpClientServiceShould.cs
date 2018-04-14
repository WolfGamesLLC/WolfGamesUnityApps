using MarbleMotionBackEnd.Services;
using MarbleMotionXUnitTest.TestingUtilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Services
{
    /// <summary>
    /// Verify the behavior of an Http client service 
    /// </summary>
    public class HttpClientServiceShould
    {
        /// <summary>
        /// Verify that an HttpClientService object can't be instatiated without a
        /// concrete implementation of an HttpClient
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullHttpClient()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new HttpClientService(null));
            Assert.Equal("Value cannot be null.\r\nParameter name: client", ex.Message);
        }

        /// <summary>
        /// Verify a get request can be made
        /// </summary>
        [Fact]
        public async void MakeGetRequest()
        {
            var _mockResponses = new Dictionary<Uri, HttpResponseMessage>();
            var _mockHandler = new MockResponseHandler(_mockResponses);
            var _mockClient = new HttpClient(_mockHandler);
            var _dut = new HttpClientService(_mockClient);

            _mockResponses.Add(new Uri("http://www.uri.com"), new HttpResponseMessage(HttpStatusCode.OK));

            var response = await _dut.RequestAsync(new Uri("http://www.uri.com"));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
