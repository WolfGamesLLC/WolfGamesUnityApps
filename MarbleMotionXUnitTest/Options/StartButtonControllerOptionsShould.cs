using MarbleMotionBackEnd.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Options
{
    /// <summary>
    /// Verify the behaviors of a <see cref="StartButtonControllerOptions"/>
    /// </summary>
    public class StartButtonControllerOptionsShould
    {
        /// <summary>
        /// Verify the local host http address is used by default
        /// </summary>
        [Fact]
        public void UseLocalHttpByDefault()
        {
            var _dut = new StartButtonControllerOptions();

            Assert.Equal(StartButtonControllerOptions.DefaultUri, _dut.Uri);
        }

        /// <summary>
        /// Verify the Uri used can be changed
        /// </summary>
        [Fact]
        public void GetAndSetUri()
        {
            var uri = new Uri("http://www.someuri.com");
            var _dut = new StartButtonControllerOptions();

            _dut.Uri = uri;

            Assert.Equal(uri, _dut.Uri);
        }
    }
}
