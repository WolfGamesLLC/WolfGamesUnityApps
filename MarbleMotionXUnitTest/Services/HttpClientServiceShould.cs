using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Xunit;

namespace MarbleMotionXUnitTest.Services
{
    public class HttpClientServiceShould
    {
        [Fact]
        public void RequestPlayerData()
        {
            IHttpClientService httpClientService = new HttpClientService();
            IPlayerModel player = httpClientService.RequestPlayerData(new Uri("http://some.api.url/player"));
            Assert.NotNull(player);
        }
    }
}
