using MarbleMotionBackEnd.Controllers;
using MarbleMotionBackEnd.EventArgs;
using MarbleMotionBackEnd.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using WGXUnit.Facts;
using Xunit;
using Xunit.Abstractions;

namespace MarbleMotionXUnitTest
{
    /// <summary>
    /// Test suite for the <see cref="StartButtonController"/>
    /// </summary>
    public class StartButtonControllerShould : FactWriteToStdOut
    {
        private Mock<IStartButtonModel> _mockModel;
        private StartButtonController _dut;
        private Mock<IStartButtonView> _mockView;
        private Mock<IPlayerModel> _mockPlayer;

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        /// <param name="outputHelper">Allows the test to write data to stdout</param>
        public StartButtonControllerShould(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            _mockModel = new Mock<IStartButtonModel>();
            _mockView = new Mock<IStartButtonView>();
            _mockPlayer = new Mock<IPlayerModel>();
            _dut = new StartButtonController(_mockModel.Object, _mockView.Object, _mockPlayer.Object);
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IStartButtonModel"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullModel()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(null, null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: model", ex.Message);
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IStartButtonView"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullView()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(_mockModel.Object, null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: view", ex.Message);
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IPlayerModel"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullPlayer()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(_mockModel.Object, _mockView.Object, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: player", ex.Message);
        }

        /// <summary>
        /// Create a <see cref="StartButtonController"/> when a <see cref="StartButtonView"/> and a <see cref="StartButtonModel"/> are 
        /// injected
        /// </summary>
        [Fact]
        public void CreateStartButtonController()
        {
            Assert.NotNull(new StartButtonController(_mockModel.Object, _mockView.Object, _mockPlayer.Object));
        }

        /// <summary>
        /// Verify that the <see cref="IStartButtonView.OnClicked"/> event is set
        /// </summary>
        [Fact]
        public void LoadPlayerDataOnClickedEventAsync()
        {
            _mockPlayer.SetupProperty(player => player.Id);
            _dut.HandleOnClickedEvent(this, new StartButtonClickedEventArgs());
            Assert.Equal("1", _mockPlayer.Object.Id);
            _mockPlayer.VerifySet(player => player.Id = "1");
        }
    }
}
