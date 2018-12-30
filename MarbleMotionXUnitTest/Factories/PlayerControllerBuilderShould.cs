using MarbleMotionBackEnd.Factories;
using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Factories
{
    /// <summary>
    /// Test suite for the player factory
    /// </summary>
    public class PlayerControllerBuilderShould
    {
        /// <summary>
        /// Verify a <see cref="PlayerControllerBuilder"/> throws an 
        /// <see cref="ArgumentNullException"/> unless a valid <see cref="PlayerModel"/> is used
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullPlayerModel()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new PlayerControllerBuilder(null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: model", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="PlayerControllerBuilder"/> throws an 
        /// <see cref="ArgumentNullException"/> unless a valid <see cref="PlayerView"/> is used
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullPlayerView()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new PlayerControllerBuilder(new Mock<IPlayerModel>().Object, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: view", ex.Message);
        }

        /// <summary>
        /// Verify a <see cref="PlayerControllerBuilder"/> can be created from valid
        /// <see cref="PlayerModel"/>, <see cref="PlayerView"/> and <see cref="PlayerModel"/> objects
        /// </summary>
        [Fact]
        public void CreatePlayerController()
        {
            IPlayerController controller = new PlayerControllerBuilder(new Mock<IPlayerModel>().Object,
                                                                                    new Mock<IPlayerView>().Object)
                                                                                    .Build();
            Assert.NotNull(controller);
        }

        /// <summary>
        /// Verify that a <see cref="PlayerControllerBuilder"/> can configure the <see cref="PlayerController"/>
        /// it creates
        /// </summary>
        [Fact]
        public void ConfigurePlayer()
        {
            IPlayerController controller = new PlayerControllerBuilder(new Mock<IPlayerModel>().Object,
                                                                                    new Mock<IPlayerView>().Object)
                                                                                    .Configure(new PlayerControllerOptions())
                                                                                    .Build();
            Assert.NotNull(controller.Options);
        }

        /// <summary>
        /// Verify that a <see cref="PlayerControllerBuilder"/> can set the <see cref="IHttpClientService"/> on
        /// the <see cref="PlayerController"/> it creates
        /// </summary>
        [Fact]
        public void ConfigureHttpClientService()
        {
            IPlayerController controller = new PlayerControllerBuilder(new Mock<IPlayerModel>().Object,
                                                                                    new Mock<IPlayerView>().Object)
                                                                                    .ConfigureHttpClientService(new Mock<IHttpClientService>().Object)
                                                                                    .Build();
            Assert.NotNull(controller.HttpClientService);
        }
    }
}
