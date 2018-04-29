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
        /// Should use the local host http address by default
        /// </summary>
        [Fact]
        public void UseLocalHttpByDefault()
        {
            var _dut = new StartButtonControllerOptions();

            Assert.Equal(StartButtonControllerOptions.DefaultUri, _dut.Uri);
        }
    }
}
