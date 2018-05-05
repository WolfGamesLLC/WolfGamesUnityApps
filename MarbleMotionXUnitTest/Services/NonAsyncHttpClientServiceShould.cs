using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Xunit;

namespace MarbleMotionXUnitTest.Services
{
    public class NonAsyncHttpClientServiceShould
    {
        [Fact]
        public void RequestPlayerData()
        {
            INonAsyncHttpClientService httpClientService = new NonAsyncHttpClientService();
            IPlayerModel player = httpClientService.RequestPlayerData(new Uri("http://some.api.url/player"));
            Assert.NotNull(player);
        }
    }
}
