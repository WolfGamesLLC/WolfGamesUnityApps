using MarbleMotionBackEnd.Interfaces;
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
        private PlayerModel _expectedPlayer;

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        public PlayerModelShould()
        {
            _player = new PlayerModel();
            _expectedPlayer = new PlayerModel();
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
            Guid expected = new Guid();
            _player.Id = expected;
            Assert.Equal(expected, _player.Id);
        }

        /// <summary>
        /// The score should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetScore()
        {
            long expected = 12345;
            _player.Score = expected;
            Assert.Equal(expected, _player.Score);
        }

        /// <summary>
        /// The position should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetPosition()
        {
            WGVector3 expected = new WGVector3();
            _player.Position = expected;
            Assert.Equal(expected, _player.Position);
        }

        /// <summary>
        /// Verify that player is not equal to a null
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithNull()
        {
            Assert.False(_player == null);
        }

        /// <summary>
        /// Verify that player is not equal to another type
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithNonPlayer()
        {
            Object other = new Object();
            Assert.Throws<InvalidCastException>(() => _player == (PlayerModel) other);
        }

        /// <summary>
        /// Verify that two player objects with different ids return not equal
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithNotEqualId()
        {
            _expectedPlayer.Id = Guid.NewGuid();

            _player.Id = Guid.NewGuid();

            Assert.NotEqual(_expectedPlayer, _player);
        }

        /// <summary>
        /// Verify that two player objects with equal ids return equal
        /// </summary>
        [Fact]
        public void ReturnEqualWithEqualId()
        {
            _expectedPlayer.Id = Guid.NewGuid();

            _player.Id = _expectedPlayer.Id;

            Assert.Equal(_expectedPlayer, _player);
        }

        /// <summary>
        /// Verify that two player objects with different scores return not equal
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithNotEqualScore()
        {
            _expectedPlayer.Score = 1;

            _player.Score = 2;

            Assert.NotEqual(_expectedPlayer, _player);
        }

        /// <summary>
        /// Verify that two player objects with equal scores return equal
        /// </summary>
        [Fact]
        public void ReturnEqualWithEqualScore()
        {
            _expectedPlayer.Score = 1;

            _player.Score = _expectedPlayer.Score;

            Assert.Equal(_expectedPlayer, _player);
        }

        /// <summary>
        /// Verify that two player objects with equal ids return the same hash code
        /// </summary>
        [Fact]
        public void ReturnEqualHashWithEqualId()
        {
            _expectedPlayer.Id = Guid.NewGuid();

            _player.Id = _expectedPlayer.Id;

            Assert.Equal(_expectedPlayer.GetHashCode(), _player.GetHashCode());
        }
    }
}
