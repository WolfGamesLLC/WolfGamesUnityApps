using MarbleMotionBackEnd.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Http
{
    /// <summary>
    /// Verify a <see cref="WGHttpResponseMessage"/> objects behavior
    /// </summary>
    public class WGHttpResponseMessageShould
    {
        /// <summary>
        /// Verify access to an http request's response content
        /// </summary>
        [Fact]
        public void SetAndGetWGHttpResponseContent()
        {
            WGHttpResponseMessage dut = new WGHttpResponseMessage();
            WGHttpContent expectedContent = new WGHttpContent();

            dut.Content = expectedContent;

            Assert.Equal(expectedContent, dut.Content);
        }

        /// <summary>
        /// Verify access to an http request's response headers
        /// </summary>
        [Fact]
        public void SetAndGetHttpResponseHeaders()
        {
            WGHttpResponseMessage dut = new WGHttpResponseMessage();
            var expectedHeaders = new List<KeyValuePair<string, IEnumerable<string>>>();

            dut.Headers = expectedHeaders;

            Assert.Equal(expectedHeaders, dut.Headers);
        }

        /// <summary>
        /// Verify access to an http request's status code
        /// </summary>
        [Fact]
        public void SetAndGetHttpStatusCode()
        {
            WGHttpResponseMessage dut = new WGHttpResponseMessage();
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            dut.StatusCode = expectedCode;

            Assert.Equal(expectedCode, dut.StatusCode);
        }

        /// <summary>
        /// Verify access to an http request's response headers
        /// </summary>
        [Fact]
        public void SetAndGetReasonPhrase()
        {
            WGHttpResponseMessage dut = new WGHttpResponseMessage();
            var expectedReasonPhrase = "Reason for fail";

            dut.ReasonPhrase = expectedReasonPhrase;

            Assert.Equal(expectedReasonPhrase, dut.ReasonPhrase);
        }

        /// <summary>
        /// Verify object can report success status
        /// </summary>
        [Fact]
        public void ReportSuccessWhenStatusCodeOk()
        {
            WGHttpResponseMessage dut = new WGHttpResponseMessage();
            dut.StatusCode = HttpStatusCode.OK;

            Assert.True(dut.IsSuccessStatusCode);
        }

        /// <summary>
        /// Verify object can report fail status
        /// </summary>
        [Fact]
        public void ReportFailWhenStatusCodeNotOk()
        {
            WGHttpResponseMessage dut = new WGHttpResponseMessage();

            Assert.False(dut.IsSuccessStatusCode);
        }
    }
}
