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
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonControllerBuilder(null, null, null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: model", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="StartButtonControllerBuilder"/> throws an 
        /// <see cref="ArgumentNullException"/> unless a valid <see cref="StartButtonView"/> is used
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullStartButtonView()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonControllerBuilder(new Mock<IStartButtonModel>().Object, null, null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: view", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="StartButtonControllerBuilder"/> throws an 
        /// <see cref="ArgumentNullException"/> unless a valid <see cref="PlayerModel"/> is used
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullPlayerModel()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonControllerBuilder(new Mock<IStartButtonModel>().Object, 
                                                                                                new Mock<IStartButtonView>().Object, null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: player", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="StartButtonControllerBuilder"/> throws an 
        /// <see cref="ArgumentNullException"/> unless a valid <see cref="HttpClientService"/> is used
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullHttpClientService()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonControllerBuilder(new Mock<IStartButtonModel>().Object,
                                                                                                new Mock<IStartButtonView>().Object,
                                                                                                new Mock<IPlayerModel>().Object, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: httpClientService", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="StartButtonControllerBuilder"/> can be created from valid
        /// <see cref="StartButtonModel"/>, <see cref="StartButtonView"/> and <see cref="PlayerModel"/> objects
        /// </summary>
        [Fact]
        public void CreateStartButtonController()
        {
            IStartButtonControllerBuilder builder = new StartButtonControllerBuilder(new Mock<IStartButtonModel>().Object, 
                                                                                    new Mock<IStartButtonView>().Object, 
                                                                                    new Mock<IPlayerModel>().Object,
                                                                                    new Mock<IHttpClientService>().Object);
            Assert.IsAssignableFrom<IStartButtonController>(builder.Controller);
        }

        /// <summary>
        /// Verify that a <see cref="StartButtonControllerBuilder"/> can configure the <see cref="StartButtonController"/>
        /// it creates
        /// </summary>
        [Fact]
        public void ConfigureStartButton()
        {
            StartButtonController controller = new StartButtonControllerBuilder(new Mock<IStartButtonModel>().Object,
                                                                                    new Mock<IStartButtonView>().Object,
                                                                                    new Mock<IPlayerModel>().Object,
                                                                                    new Mock<IHttpClientService>().Object)
                                                                                    .Configure(new StartButtonControllerOptions())
                                                                                    .Build();
            Assert.NotNull(controller.Options);
        }
    }
}
