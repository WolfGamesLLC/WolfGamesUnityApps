using MarbleMotionBackEnd.Controllers;
using System;
using Xunit;

namespace MarbleMotionXUnitTest
{
    /// <summary>
    /// Test suite for the PlayerController
    /// </summary>
    public class PlayerControllerShould
    {
        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a PlayerModel is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullPlayerModel()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new PlayerController(null));
            Assert.Equal("Value cannot be null.\r\nParameter name: playerModel", ex.Message);
        }
    }
}
