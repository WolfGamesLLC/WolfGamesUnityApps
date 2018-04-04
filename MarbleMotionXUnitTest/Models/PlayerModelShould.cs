using MarbleMotionBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Models
{
    /// <summary>
    /// Test suite for the Marble Motion player model
    /// </summary>
    public class PlayerModelShould
    {
        private PlayerModel _player;

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        public PlayerModelShould()
        {
            _player = new PlayerModel();
        }

        /// <summary>
        /// verify that an instance of PlayerModel can be created
        /// </summary>
        [Fact]
        public void CreatePlayerModel()
        {
            Assert.NotNull(new PlayerModel());
        }

        /// <summary>
        /// The id should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetId()
        {
            string expected = "Hello World";
            _player.Id = expected;
            Assert.Equal(expected, _player.Id);
        }
    }
}
