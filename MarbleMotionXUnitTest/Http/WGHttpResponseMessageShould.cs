using MarbleMotionBackEnd.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Http
{
    /// <summary>
    /// Verify a <see cref="WGHttpResponseMessage"/> objects behavior
    /// </summary>
    public class WGHttpResponseMessageShould
    {
        [Fact]
        public void SetAndGetWGHttpResponseContent()
        {
            WGHttpResponseMessage dut = new WGHttpResponseMessage();
            WGHttpContent expectedContent = new WGHttpContent();

            dut.Content = expectedContent;

            Assert.Equal(expectedContent, dut.Content);
        }
    }
}
