using MarbleMotionBackEnd.Factories;
using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using MarbleMotionBackEnd.Models;
using MarbleMotionBackEnd.Services;
using MarbleMotionBackEnd.Options;
using MarbleMotionBackEnd.Controllers;

namespace MarbleMotionXUnitTest.Factories
{
    /// <summary>
    /// Test suite for the StartButtonModelFactory
    /// </summary>
    public class StartButtonControllerBuilderShould
    {
        /// <summary>
        /// Verify a <see cref="StartButtonControllerBuilder"/> throws an 
        /// <see cref="ArgumentNullException"/> unless a valid <see cref="StartButtonModel"/> is used
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullStartButtonModel()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonControllerBuilder(null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: model", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="StartButtonControllerBuilder"/> throws an 
        /// <see cref="ArgumentNullException"/> unless a valid <see cref="StartButtonView"/> is used
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullStartButtonView()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonControllerBuilder(new Mock<IStartButtonModel>().Object, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: view", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="StartButtonControllerBuilder"/> can be created from valid
        /// <see cref="StartButtonModel"/>, <see cref="StartButtonView"/> and <see cref="PlayerModel"/> objects
        /// </summary>
        [Fact]
        public void CreateStartButtonController()
        {
            IStartButtonController controller = new StartButtonControllerBuilder(new Mock<IStartButtonModel>().Object, 
                                                                                    new Mock<IStartButtonView>().Object)
                                                                                    .Build();
            Assert.NotNull(controller);
        }

        /// <summary>
        /// Verify that a <see cref="StartButtonControllerBuilder"/> can configure the <see cref="StartButtonController"/>
        /// it creates
        /// </summary>
        [Fact]
        public void ConfigureStartButton()
        {
            IStartButtonController controller = new StartButtonControllerBuilder(new Mock<IStartButtonModel>().Object,
                                                                                    new Mock<IStartButtonView>().Object)
                                                                                    .Configure(new StartButtonControllerOptions())
                                                                                    .Build();
            Assert.NotNull(controller.Options);
        }
    }
}
