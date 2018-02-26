using MarbleMotionBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Models
{
    /// <summary>
    /// Test suite for the <see cref="MarbleMotionBackEnd.Models.StartButtonModel"/> class
    /// </summary>
    public class StartButtonModelShould
    {
        [Fact]
        public void CreateStartButtonModel()
        {
            Assert.NotNull(new StartButtonModel());
        }
    }
}
