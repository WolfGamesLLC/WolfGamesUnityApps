using MarbleMotionBackEnd.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace MarbleMotionBackEnd.Integration.XUnitTestSuite
{
    /// <summary>
    /// Behavior integration test suite of an Http client service 
    /// </summary>
    public class HttpClientServiceShould
    {
        /// <summary>
        /// Verify that an Http get request can be made
        /// </summary>
        [Fact]
        public async void MakeHttpGetRequest()
        {
            HttpClientService _dut = new HttpClientService(new HttpClient());
            var response = await _dut.RequestAsync(new Uri("http://www.wolfgamesllc.com"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
