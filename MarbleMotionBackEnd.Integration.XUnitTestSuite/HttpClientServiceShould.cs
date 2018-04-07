using MarbleMotionBackEnd.Services;
using System;
using System.Collections.Generic;
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
        public void MakeHttpGetRequest()
        {
            HttpClientService _dut = new HttpClientService(new HttpClient());
            HttpResponseMessage response = _dut.Request(new Uri("http://www.wolfgamesllc.com"));
        }
    }
}
