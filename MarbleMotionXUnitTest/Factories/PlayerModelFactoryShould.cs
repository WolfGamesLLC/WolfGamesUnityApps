using MarbleMotionBackEnd.Factories;
using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Factories
{
    /// <summary>
    /// Test suite for the PlayerModelFactory
    /// </summary>
    public class PlayerModelFactoryShould
    {
        /// <summary>
        /// Verify a <see cref="PlayerModelFactory"/> can be created
        /// </summary>
        [Fact]
        public void CreatePlayerModelFactory()
        {
            Assert.NotNull(new PlayerModelFactory());
        }

        /// <summary>
        /// Verify that a standard <see cref="PlayerModel"/> object can be created
        /// </summary>
        [Fact]
        public void CreatePlayerModel()
        {
            Assert.IsAssignableFrom<IPlayerModel>(new PlayerModelFactory().Model);
        }
    }
}
