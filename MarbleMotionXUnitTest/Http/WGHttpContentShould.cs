using MarbleMotionBackEnd.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Http
{
    /// <summary>
    /// Verify the behavior of a <see cref="WGHttpResponseContent"/> object
    /// </summary>
    public class WGHttpContentShould
    {
        /// <summary>
        /// Verify the http response's content body can be 
        /// accessed
        /// </summary>
        [Fact]
        public void SetAndGetContentBody()
        {
            WGHttpContent dut = new WGHttpContent();
            var expectedBody = "hello";

            dut.Body = expectedBody;

            Assert.Equal(expectedBody, dut.Body);

        }
    }
}
