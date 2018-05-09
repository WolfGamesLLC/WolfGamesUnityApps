using MarbleMotionBackEnd.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using UnityEngine;

namespace MarbleMotionXUnitTest.Http
{
    /// <summary>
    /// Verify behavior of a <see cref="NonAsyncHttpClient"/> object
    /// </summary>
    public class NonAsyncHttpClientShould
    {
        private NonAsyncHttpClient dut;

        public NonAsyncHttpClientShould()
        {
            dut = new NonAsyncHttpClient();
        }

        /// <summary>
        /// Verify a request will be made of a remote system
        /// </summary>
        [Fact(Skip = "Until I can figure out how to properly unit test Unity internal methods")]
        public void ReturnHttpResponseMessageFromRequest()
        {
            Assert.IsType<WGHttpResponseMessage>(dut.Request(new Uri("http://some.web.uri")));
        }

        /// <summary>
        /// Verify the <see cref="WGHttpResponseMessage.StatusCode"/> is set to <see cref="HttpStatusCode.OK"/>
        /// if null is passed to <see cref="NonAsyncHttpClient.SetStatusCode(string)"/> 
        /// </summary>
        [Fact]
        public void SetHttpStatusCodeOkWhenNull()
        {
            dut.SetStatusCode(null);
            Assert.Equal(HttpStatusCode.OK, dut.Response.StatusCode);
        }

        /// <summary>
        /// Verify the <see cref="WGHttpResponseMessage.StatusCode"/> is set to <see cref="HttpStatusCode.OK"/>
        /// if an empty string is passed to <see cref="NonAsyncHttpClient.SetStatusCode(string)"/> 
        /// </summary>
        [Fact]
        public void SetHttpStatusCodeOkWhenEmpty()
        {
            dut.SetStatusCode("");
            Assert.Equal(HttpStatusCode.OK, dut.Response.StatusCode);
        }

        /// <summary>
        /// Verify the <see cref="WGHttpResponseMessage.StatusCode"/> is set to <see cref="HttpStatusCode.InternalServerError"/>
        /// if a populated string is passed to <see cref="NonAsyncHttpClient.SetStatusCode(string)"/> 
        /// </summary>
        [Fact]
        public void SetHttpStatusCodeOkWhenNotNullOrEmpty()
        {
            dut.SetStatusCode("Some unknown error text");
            Assert.Equal(HttpStatusCode.InternalServerError, dut.Response.StatusCode);
        }

        /// <summary>
        /// Verify the <see cref="WGHttpResponseMessage.StatusCode"/> is set to <see cref="HttpStatusCode.InternalServerError"/>
        /// if null is passed to <see cref="NonAsyncHttpClient.SetWGHttpResponseMessage(string, string, Dictionary{string, string})"/> 
        /// </summary>
        [Fact]
        public void SetWGHttpResponseMessageSetsStatusCodeFromWWW()
        {
            dut.Response = new WGHttpResponseMessage();
            dut.Response.Content = new WGHttpContent();
            dut.SetWGHttpResponseMessage("error", null, null);

            Assert.Equal(HttpStatusCode.InternalServerError, dut.Response.StatusCode);
        }

        /// <summary>
        /// Verify the <see cref="WGHttpResponseMessage.ReasonPhrase"/> is set to the text of the response error text when
        /// <see cref="NonAsyncHttpClient.SetWGHttpResponseMessage(string, string, Dictionary{string, string})"/> is called
        /// </summary>
        [Fact]
        public void SetWGHttpResponseMessageSetsErrorTextFromWWW()
        {
            dut.Response = new WGHttpResponseMessage();
            dut.Response.Content = new WGHttpContent();
            dut.SetWGHttpResponseMessage("error", null, null);

            Assert.Equal("error", dut.Response.ReasonPhrase);
        }

        /// <summary>
        /// Verify the <see cref="WGHttpContent.Body"/> is set to the text of the response when
        /// <see cref="NonAsyncHttpClient.SetWGHttpResponseMessage(string, string, Dictionary{string, string})"/> is called
        /// </summary>
        [Fact]
        public void SetWGHttpResponseMessageSetsContentBodyFromWWW()
        {
            dut.Response = new WGHttpResponseMessage();
            dut.Response.Content = new WGHttpContent();
            dut.SetWGHttpResponseMessage(null, "body", null);

            Assert.Equal("body", dut.Response.Content.Body);
        }

        /// <summary>
        /// Verify the <see cref="WGHttpResponseMessage.Headers"/> are set to expected values when
        /// <see cref="NonAsyncHttpClient.SetWGHttpResponseMessage(string, string, Dictionary{string, string})"/>
        /// is called with a <see cref="WWW.responseHeaders"/> formated dictionary
        /// </summary>
        [Fact]
        public void SetWGHttpResponseMessageSetsResponseHeadersFromWWW()
        {
            var headers = new Dictionary<string, string> { { "header_1", "value_1 value_1_2" }, { "header_2", "value_2 value_2_2" } };
            var expectedHeaders = new List<KeyValuePair<string, IEnumerable<string>>>();

            foreach (KeyValuePair<string, string> kvp in headers)
            {
                var expectedValues = new Dictionary<string, IEnumerable<string>>();

                expectedValues.Add(kvp.Key, kvp.Value.Split(" "));
                foreach (KeyValuePair<string, IEnumerable<string>> kvp2 in expectedValues)
                {
                    expectedHeaders.Add(kvp2);
                }
            }

            dut.Response = new WGHttpResponseMessage();
            dut.Response.Content = new WGHttpContent();
            dut.SetWGHttpResponseMessage(null, null, headers);

            AssertHeadersEqual(expectedHeaders, dut.Response.Headers);
        }

        private void AssertHeadersEqual(List<KeyValuePair<string, IEnumerable<string>>> expectedHeaders, IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers)
        {
            var resultHeader = headers as List<KeyValuePair<string, IEnumerable<string>>>;
            Assert.Equal(expectedHeaders.Count, resultHeader.Count);
            for (var i = 0; i < expectedHeaders.Count; i++)
            {
                Assert.Equal(expectedHeaders[i].Key, resultHeader[i].Key);
                Assert.Equal(expectedHeaders[i].Value, resultHeader[i].Value);
            }
        }

        /// <summary>
        /// Verify the <see cref="WGHttpResponseMessage.Headers"/> are set to expected values when
        /// <see cref="NonAsyncHttpClient.SetWGHttpResponseMessage(string, string, Dictionary{string, string})"/>
        /// is called with a null
        /// </summary>
        [Fact]
        public void SetWGHttpResponseMessageSetsNullResponseHeadersFromWWW()
        {
            var expectedHeaders = new List<KeyValuePair<string, IEnumerable<string>>>();
            var expectedValues = new Dictionary<string, IEnumerable<string>>();

            expectedValues.Add("", new List<string>());
            foreach (KeyValuePair<string, IEnumerable<string>> kvp in expectedValues)
            {
                expectedHeaders.Add(kvp);
            }

            dut.Response = new WGHttpResponseMessage();
            dut.Response.Content = new WGHttpContent();
            dut.SetWGHttpResponseMessage(null, null, null);

            AssertHeadersEqual(expectedHeaders, dut.Response.Headers);
        }
    }
}
