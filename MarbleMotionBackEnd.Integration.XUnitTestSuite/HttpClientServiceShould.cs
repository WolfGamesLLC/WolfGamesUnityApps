﻿using MarbleMotionBackEnd.Services;
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
        public async void MakeHttpGetRequest()
        {
            HttpClientService _dut = new HttpClientService(new HttpClient());
            var response = await _dut.RequestAsync(new Uri(WGProdUri));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Verify that an Http get request can be made to the dev game API
        /// </summary>
        [Fact(Skip = "Until I figure out how to setup SSL to Azure. This fails because I do not have a valid cert.")]
        public async void MakeDevApiHttpGetRequest()
        {
            HttpClientService _dut = new HttpClientService(new HttpClient());
            var response = await _dut.RequestAsync(new Uri(MMDevApiUri));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Verify that an Http get request can be made to the local game API
        /// </summary>
        [Fact(Skip = "Until I start the localhost")]
        public async void MakeLocalApiHttpGetRequest()
        {
            var _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44340/api");

            HttpClientService _dut = new HttpClientService(_client);
            var response = await _dut.RequestAsync(new Uri(MMLocalApiUri));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Verify that player data request can be made to the local game API
        /// </summary>
        [Fact(Skip = "Until I figure out how to send the JWT with the request.")]
        public async void MakeLocalPlayerDataRequest()
        {
            HttpClientService _dut = new HttpClientService(new HttpClient());
            var response = await _dut.RequestAsync(new Uri(LocalPlayerDataUri));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
