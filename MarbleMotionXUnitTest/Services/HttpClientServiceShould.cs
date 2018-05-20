using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Xunit;
using Moq;
using MarbleMotionBackEnd.Models;
using MarbleMotionBackEnd.Http;
using MarbleMotionBackEnd.Services;

namespace MarbleMotionXUnitTest.Services
{
    /// <summary>
    /// Verify the behaviors of an <see cref="HttpClientService"/> 
    /// </summary>
    public class HttpClientServiceShould
    {
        private Mock<IHttpClientImp> mockHttpClientImp = new Mock<IHttpClientImp>();
        private Mock<IJsonImp> mockJsonImp = new Mock<IJsonImp>();

        /// <summary>
        /// Verify a <see cref="ArgumentNullException"/> is thrown when a <see cref="HttpClientService"/>
        /// is constructed with a null <see cref="IHttpClientImp"/>
        /// </summary>
        [Fact]
        public void ThrowNullArgumentExceptionFromConstructorWithNullHttpClientImp()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new HttpClientService(null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: httpClientImp", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="ArgumentNullException"/> is thrown when a <see cref="HttpClientService"/>
        /// is constructed with a null <see cref="IJson"/>
        /// </summary>
        [Fact]
        public void ThrowNullArgumentExceptionFromConstructorWithNullJsonImp()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new HttpClientService(mockHttpClientImp.Object, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: jsonImp", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="HttpClientService"/> can be constructed when a <see cref="IHttpClientImp"/>
        /// and an <see cref="IJsonImp"/> are supplied
        /// </summary>
        [Fact]
        public void CreateFromConstructorWithHttpClientImpAndJsonImp()
        {
            Assert.NotNull(new HttpClientService(mockHttpClientImp.Object, mockJsonImp.Object));
        }

        /// <summary>
        /// Requesting player data from an api should return an object that
        /// implements <see cref="IPlayerModel"/>
        /// </summary>
        [Fact]
        public void RequestPlayerData()
        {
            var expectedUri = new Uri("http://some.api.url/player");
            var expectedJson = "expected json text";
            var responseContent = new WGHttpContent();
            responseContent.Body = expectedJson;
            var responseMessage = new WGHttpResponseMessage();
            responseMessage.Content = responseContent;

            mockHttpClientImp.SetReturnsDefault<WGHttpResponseMessage>(responseMessage);

            IHttpClientService httpClientService = new HttpClientService(mockHttpClientImp.Object, mockJsonImp.Object);
            IPlayerModel player = httpClientService.RequestPlayerData(expectedUri);

            mockHttpClientImp.Verify(imp => imp.Request(expectedUri));
            mockJsonImp.Verify(imp => imp.FromJson<IPlayerModel>(responseMessage.Content.Body));
        }
    }
}
