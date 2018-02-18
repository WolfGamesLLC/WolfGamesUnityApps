using MarbleMotionBackEnd.Factories;
using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Factories
{
    /// <summary>
    /// Test suite for the player factory
    /// </summary>
    public class PlayerFactoryShould
    {
        /// <summary>
        /// Verify a player factory can be created
        /// </summary>
        [Fact]
        public void CreatePlayerFactory()
        {
            Assert.NotNull(new PlayerFactory());
        }

        /// <summary>
        /// Verify player models can be created
        /// </summary>
        [Fact]
        public void CreatePlayerModelInstance()
        {
            var factory = new PlayerFactory();
            Assert.IsAssignableFrom<IPlayerModel>(factory.Model());
        }
    }
}
