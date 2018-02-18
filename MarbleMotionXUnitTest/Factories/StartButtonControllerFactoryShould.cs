using MarbleMotionBackEnd.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Factories
{
    /// <summary>
    /// Test suite for the StartButtonModelFactory
    /// </summary>
    public class StartButtonControllerFactoryShould
    {
        /// <summary>
        /// Verify a start button controller factory can be created
        /// </summary>
        [Fact]
        public void CreateStartButtonControllerFactory()
        {
            Assert.NotNull(new StartButtonControllerFactory());
        }
    }
}
