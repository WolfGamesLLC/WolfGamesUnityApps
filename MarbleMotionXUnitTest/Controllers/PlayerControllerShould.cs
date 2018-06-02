using MarbleMotionBackEnd.Controllers;
using System;
using Xunit;
using MarbleMotionBackEnd.Interfaces;
using Moq;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Net.Http;
using MarbleMotionBackEnd.Options;
using WGXUnit.Facts;
using MarbleMotionBackEnd.EventArgs;
using MarbleMotionBackEnd.Models;

namespace MarbleMotionXUnitTest.Controllers
{
    /// <summary>
    /// Test suite for the PlayerController
    /// </summary>
    public class PlayerControllerShould : FactWriteToStdOut
    {
        private IPlayerModel _mockModel;
        private PlayerController _dut;
        private Mock<IPlayerView> _mockView;
        private Mock<IHttpClientService> _mockHttpClientService;
        private Dictionary<Uri, HttpResponseMessage> _mockResponses = new Dictionary<Uri, HttpResponseMessage>();
        private Guid _guid;

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        /// <param name="outputHelper">Allows the test to write data to stdout</param>
        public PlayerControllerShould(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            _mockModel = new PlayerModel();
            _mockView = new Mock<IPlayerView>();
            _mockHttpClientService = new Mock<IHttpClientService>();

            _guid = Guid.NewGuid();
            _dut = new PlayerController(_mockModel, _mockView.Object);
            _dut.Options = new PlayerControllerOptions();
            _dut.HttpClientService = _mockHttpClientService.Object;
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IPlayerModel"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullPlayerModel()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new PlayerController(null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: model", ex.Message);
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IPlayerView"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullPlayerView()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new PlayerController(null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: model", ex.Message);
        }

        /// <summary>
        /// Create a <see cref="PlayerController"/> when all required objects are supplied
        /// </summary>
        [Fact]
        public void CreatePlayerController()
        {
            Assert.NotNull(new PlayerController(_mockModel, _mockView.Object));
        }

        /// <summary>
        /// Set a <see cref="PlayerController"/> objects configuration 
        /// </summary>
        [Fact]
        public void SetPlayerControllerOptions()
        {
            var mockConfig = new Mock<PlayerControllerOptions>();
            _dut.Options = mockConfig.Object;

            Assert.NotNull(_dut.Options);
        }

        /// <summary>
        /// Set a <see cref="PlayerController"/> objects <see cref="IHttpClientService"/> 
        /// </summary>
        [Fact]
        public void SetPlayerControllerHttpClientService()
        {
            var mockService = new Mock<IHttpClientService>();
            _dut.HttpClientService = mockService.Object;

            Assert.NotNull(_dut.HttpClientService);
        }

        /// <summary>
        /// Verify that the <see cref="IPlayerView.OnLoad"/> event is set
        /// </summary>
        [Fact]
        public void LoadPlayerDataOnLoadEvent()
        {
            _mockModel.Id = _guid;

            _mockView.Raise(x => x.OnLoad += null, new OnPlayerLoadEventArgs()); // I don't like testing that the handler is registered this way

            _mockHttpClientService.Verify(service => service.RequestPlayerData(new Uri($"{PlayerControllerOptions.DefaultUri}{_guid}"), _mockModel), Times.Once);
        }

        /// <summary>
        /// Verify that the <see cref="PlayerController.HandleOnLoadEvent(object, OnPlayerLoadEventArgs)"/> event 
        /// adds a / when none is present on the original path
        /// </summary>
        [Fact]
        public void PlayerDataRequestUriAddForwardSlashToEnd()
        {
            _mockModel.Id = _guid;
            _dut.Options.Uri = new Uri("https://marbelmotion.wolfgamesllc.com/api/players");

            _dut.HandleOnLoadEvent(null, new OnPlayerLoadEventArgs());

            _mockHttpClientService.Verify(service => service.RequestPlayerData(new Uri($"https://marbelmotion.wolfgamesllc.com/api/players/{_guid}"), _mockModel), Times.Once);
        }

        /// <summary>
        /// Verify that the <see cref="PlayerController.HandleOnLoadEvent(object, OnPlayerLoadEventArgs)"/> event 
        /// adds a / when none is present on the original path
        /// </summary>
        [Fact]
        public void PlayerDataRequestUriNoForwardSlashToEnd()
        {
            _mockModel.Id = _guid;
            _dut.Options.Uri = new Uri("https://marbelmotion.wolfgamesllc.com/api/players/");

            _dut.HandleOnLoadEvent(null, new OnPlayerLoadEventArgs());

            _mockHttpClientService.Verify(service => service.RequestPlayerData(new Uri($"https://marbelmotion.wolfgamesllc.com/api/players/{_guid}"), _mockModel), Times.Once);
        }
    }
}
