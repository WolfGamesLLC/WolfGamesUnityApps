using MarbleMotionBackEnd.Models;
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
        private const string WGProdUri = "http://www.wolfgamesllc.com";
        private const string MMDevApiUri = "https://marblemotiondev.wolfgamesllc.com";
        private const string MMLocalApiUri = "https://localhost:44340/api";
        private const string LocalPlayerDataUri = "https://localhost:44340/api/players";

        private HttpClient _client;

        public HttpClientServiceShould()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://www.wolfgamesllc.com/simplegames/webgl/marblemotion");
        }

        /// <summary>
        /// Verify that an Http get request can be made
        /// </summary>
        [Fact]
        public void MakeHttpGetRequest()
        {
            NonAsyncHttpClientService _dut = new NonAsyncHttpClientService();
            var response = _dut.RequestPlayerData(new Uri(WGProdUri));

            Assert.Equal(new PlayerModel(), response);
        }
    }
}
