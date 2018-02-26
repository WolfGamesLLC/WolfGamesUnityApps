using MarbleMotionBackEnd.Controllers;
using MarbleMotionBackEnd.Interfaces;
using Moq;
using System;
using Xunit;

namespace MarbleMotionXUnitTest
{
    /// <summary>
    /// Test suite for the <see cref="StartButtonController"/>
    /// </summary>
    public class StartButtonControllerShould
    {
        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IStartButtonModel"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullModel()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: StartButtonModel", ex.Message);
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IStartButtonView"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullView()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: StartButtonModel", ex.Message);
        }

        /// <summary>
        /// Create a <see cref="StartButtonController"/> when a <see cref="StartButtonView"/> and a <see cref="StartButtonModel"/> are 
        /// injected
        /// </summary>
        [Fact]
        public void CreateStartButtonController()
        {
            Assert.NotNull(new StartButtonController((new Mock<IStartButtonModel>()).Object, (new Mock<IStartButtonView>().Object)));
        }
    }
}
