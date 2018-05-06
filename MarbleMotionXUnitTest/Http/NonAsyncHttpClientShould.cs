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
        /// Verify the <see cref="HttpStatusCode"/> is set to <see cref="HttpStatusCode.OK"/>
        /// if the <see cref="WWW"/> objects <see cref="WWW.error"/> property is null
        /// </summary>
        [Fact]
        public void SetHttpStatusCodeOkWhenNull()
        {
            dut.SetStatusCode(null);
            Assert.Equal(HttpStatusCode.OK, dut.Response.StatusCode);
        }

        /// <summary>
        /// Verify the <see cref="HttpStatusCode"/> is set to <see cref="HttpStatusCode.OK"/>
        /// if the <see cref="WWW"/> objects <see cref="WWW.error"/> property is empty
        /// </summary>
        [Fact]
        public void SetHttpStatusCodeOkWhenEmpty()
        {
            dut.SetStatusCode("");
            Assert.Equal(HttpStatusCode.OK, dut.Response.StatusCode);
        }

        /// <summary>
        /// Verify the <see cref="HttpStatusCode"/> is set to <see cref="HttpStatusCode.InternalServerError"/>
        /// if the <see cref="WWW"/> objects <see cref="WWW.error"/> property is not null or empty
        /// </summary>
        [Fact]
        public void SetHttpStatusCodeOkWhenNotNullOrEmpty()
        {
            dut.SetStatusCode("Some unknown error text");
            Assert.Equal(HttpStatusCode.InternalServerError, dut.Response.StatusCode);
        }
    }
}
