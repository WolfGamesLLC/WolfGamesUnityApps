using MarbleMotionBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Models
{
    /// <summary>
    /// Test suite for the <see cref="PlayerModelResource"/>
    /// model
    /// </summary>
    public class PlayerModelResourceShould : ApiResourceShould
    {
        /// <summary>
        /// Initialize the test suite
        /// </summary>
        public PlayerModelResourceShould()
        {
            Model = new PlayerModelResource();
        }

        /// <summary>
        /// Verify the model can be created
        /// </summary>
        [Fact]
        public void ShouldCreateAMarbleMotionModel()
        {
            Assert.NotNull(new PlayerModelResource());
        }

        /// <summary>
        /// The score should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetScore()
        {
            int expected = 100;
            ((PlayerModelResource)Model).score = expected;
            Assert.Equal(expected, ((PlayerModelResource)Model).score);
        }

        /// <summary>
        /// The X position should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetXPosition()
        {
            int expected = 12345;
            ((PlayerModelResource)Model).xPosition = expected;
            Assert.Equal(expected, ((PlayerModelResource)Model).xPosition);
        }

        /// <summary>
        /// The Y position should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetYPosition()
        {
            int expected = 12345;
            ((PlayerModelResource)Model).zPosition = expected;
            Assert.Equal(expected, ((PlayerModelResource)Model).zPosition);
        }
    }
}
