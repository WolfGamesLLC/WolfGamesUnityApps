using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Services
{
    /// <summary>
    /// Verify behavior of a <see cref="NonAsyncHttpClient"/> object
    /// </summary>
    public class NonAsyncHttpClientShould
    {
        [Fact]
        public void ReturnHttpResponseMessageFromRequest()
        {
            var dut = new NonAsyncHttpClient();
            Assert.IsType<HttpResponseMessage>(dut.Request(new Uri("http://some.web.uri")));
        }
    }
}
