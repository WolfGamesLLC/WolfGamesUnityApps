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
    public class StartButtonModelFactoryShould
    {
        /// <summary>
        /// Verify a start button model factory can be created
        /// </summary>
        [Fact]
        public void CreatePlayerFactory()
        {
            Assert.NotNull(new StartButtonModelFactory());
        }
    }
}
