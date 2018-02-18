using MarbleMotionBackEnd.Factories;
using MarbleMotionBackEnd.Interfaces;
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
        /// Verify a <see cref="StartButtonModelFactory"/> can be created
        /// </summary>
        [Fact]
        public void CreateStartButtonModelFactory()
        {
            Assert.NotNull(new StartButtonModelFactory());
        }

        /// <summary>
        /// Verify that a standard <see cref="StartButtonModel"/> object can be created
        /// </summary>
        [Fact]
        public void CreateStartButtonModel()
        {
            Assert.IsAssignableFrom<IStartButtonModel>(new StartButtonModelFactory().Model);
        }
    }
}
