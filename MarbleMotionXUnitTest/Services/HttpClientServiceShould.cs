using MarbleMotionBackEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Services
{
    /// <summary>
    /// Verify the behavior of an Http client service 
    /// </summary>
    public class HttpClientServiceShould
    {
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullHttpClient()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new HttpClientService(null));
            Assert.Equal("Value cannot be null.\r\nParameter name: client", ex.Message);
        }
    }
}
