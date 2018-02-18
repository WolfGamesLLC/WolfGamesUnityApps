using MarbleMotionBackEnd.Factories;
using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

namespace MarbleMotionXUnitTest.Factories
{
    /// <summary>
    /// Test suite for the StartButtonModelFactory
    /// </summary>
    public class StartButtonControllerFactoryShould
    {
        /// <summary>
        /// Verify a <see cref="StartButtonControllerFactory"/> throws an 
        /// <see cref="ArgumentNullException"/> unless a valid <see cref="StartButtonModel"/> is used
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullStartButtonModel()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonControllerFactory(null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: model", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="StartButtonControllerFactory"/> throws an 
        /// <see cref="ArgumentNullException"/> unless a valid <see cref="StartButtonModel"/> is used
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullStartButtonView()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonControllerFactory(new Mock<IStartButtonModel>().Object, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: view", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="StartButtonControllerFactory"/> can be created from valid
        /// <see cref="StartButtonModel"/> and <see cref="StartButtonView"/> objects
        /// </summary>
        [Fact]
        public void CreateStartButtonController()
        {
            IStartButtonControllerFactory factory = new StartButtonControllerFactory(new Mock<IStartButtonModel>().Object, new Mock<IStartButtonView>().Object);
            Assert.IsAssignableFrom<IStartButtonController>(factory.Controller);
        }
    }
}
