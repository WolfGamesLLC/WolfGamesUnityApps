using MarbleMotionBackEnd.Controllers;
using MarbleMotionBackEnd.EventArgs;
using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Models;
using MarbleMotionBackEnd.Options;
using MarbleMotionBackEnd.Services;
using MarbleMotionXUnitTest.TestingUtilities;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WGXUnit.Facts;
using Xunit;
using Xunit.Abstractions;

namespace MarbleMotionXUnitTest.Controllers
{
    /// <summary>
    /// Test suite for the <see cref="StartButtonController"/>
    /// </summary>
    public class StartButtonControllerShould : FactWriteToStdOut
    {
        private Mock<IStartButtonModel> _mockModel;
        private StartButtonController _dut;
        private Mock<IStartButtonView> _mockView;
        private PlayerModel _player;
        private Mock<IHttpClientService> _mockHttpClientService;
        private Dictionary<Uri, HttpResponseMessage> _mockResponses = new Dictionary<Uri, HttpResponseMessage>();
        private Guid _guid;

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        /// <param name="outputHelper">Allows the test to write data to stdout</param>
        public StartButtonControllerShould(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            _mockModel = new Mock<IStartButtonModel>();
            _mockView = new Mock<IStartButtonView>();
            _mockHttpClientService = new Mock<IHttpClientService>();
            var _mockHandler = new MockResponseHandler(_mockResponses);
            var _mockClient = new HttpClient(_mockHandler);
            var mockHttpClientService = new HttpClientService(_mockClient);

            _guid = Guid.NewGuid();
            _player = new PlayerModel();
            _dut = new StartButtonController(_mockModel.Object, _mockView.Object, _player, mockHttpClientService);
            _dut.Options = new StartButtonControllerOptions();
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IStartButtonModel"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullModel()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(null, null, null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: model", ex.Message);
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IStartButtonView"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullView()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(_mockModel.Object, null, null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: view", ex.Message);
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IPlayerModel"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullPlayer()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(_mockModel.Object, _mockView.Object, null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: player", ex.Message);
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IPlayerModel"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullHttpClientService()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(_mockModel.Object, _mockView.Object, _player, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: httpClientService", ex.Message);
        }

        /// <summary>
        /// Create a <see cref="StartButtonController"/> when all required objects are supplied
        /// </summary>
        [Fact]
        public void CreateStartButtonController()
        {
            Assert.NotNull(new StartButtonController(_mockModel.Object, _mockView.Object, _player, _mockHttpClientService.Object));
        }

        /// <summary>
        /// Set a <see cref="StartButtonController"/> objects configuration 
        /// </summary>
        [Fact]
        public void SetStartButtonControllerOptions()
        {
            var mockConfig = new Mock<StartButtonControllerOptions>();
            _dut.Options = mockConfig.Object;

            Assert.NotNull(_dut.Options);
        }

        /// <summary>
        /// Verify that the <see cref="IStartButtonView.OnClicked"/> event is set
        /// </summary>
        [Fact]
        public void LoadPlayerDataOnClickedEventAsync()
        {
            var expectedPlayer = new PlayerModel();
            expectedPlayer.Id = _guid;
            expectedPlayer.Score = 1;
            expectedPlayer.XPosition = 20;
            expectedPlayer.ZPosition = 300;

            byte[] content = Encoding.Default.GetBytes("{\"href\": " + $"\"{StartButtonControllerOptions.DefaultUri}{_guid}\"" + ",\"score\": 1,\"xPosition\": 20,\"zPosition\": 300}");
            var contentStream = new MemoryStream(content);
            var expectedHttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            expectedHttpResponseMessage.Content = new StreamContent(contentStream);

            _mockResponses.Add(new Uri($"{StartButtonControllerOptions.DefaultUri}{_guid}"), expectedHttpResponseMessage);
            _player.Id = _guid;

            _mockView.Raise(x => x.OnClicked += null, new StartButtonClickedEventArgs());

            Assert.Equal(expectedPlayer, _player);
        }
    }
}
