using MarbleMotionBackEnd.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Services
{
    /// <summary>
    /// Verify the behavior of an Http client service 
    /// </summary>
    public class HttpClientServiceShould
    {
        /// <summary>
        /// Verify that an HttpClientService object can't be instatiated without a
        /// concrete implementation of an HttpClient
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullHttpClient()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new HttpClientService(null));
            Assert.Equal("Value cannot be null.\r\nParameter name: client", ex.Message);
        }

        [Fact]
        public void MakeGetRequest()
        {
            var _mockClient = new Mock<HttpClient>();
            _mockClient.Setup(e => e.GetAsync(It.IsAny<string>()));
            var _dut = new HttpClientService(_mockClient.Object);

            _mockClient.Verify(e => e.GetAsync(It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
