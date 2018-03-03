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

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        /// <param name="outputHelper">Allows the test to write data to stdout</param>
        public StartButtonControllerShould(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            _mockModel = new Mock<IStartButtonModel>();
            _mockView = new Mock<IStartButtonView>();
            _dut = new StartButtonController(_mockModel.Object, _mockView.Object);
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IStartButtonModel"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullModel()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(null, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: model", ex.Message);
        }

        /// <summary>
        /// Throw an <see cref="ArgumentNullException"/> when a <see cref="IStartButtonView"/> is not injected on construction
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionFromConstructorWithNullView()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new StartButtonController(_mockModel.Object, null));
            Assert.Equal("Value cannot be null.\r\nParameter name: view", ex.Message);
        }

        /// <summary>
        /// Create a <see cref="StartButtonController"/> when a <see cref="StartButtonView"/> and a <see cref="StartButtonModel"/> are 
        /// injected
        /// </summary>
        [Fact]
        public void CreateStartButtonController()
        {
            Assert.NotNull(new StartButtonController(_mockModel.Object, _mockView.Object));
        }

        /// <summary>
        /// Verify that the <see cref="IStartButtonView.OnClicked"/> event is set
        /// </summary>
        [Fact]
        public async void LoadPlayerDataOnClickedEventAsync()
        {
            var res = await _dut.HandleOnClickedEvent(this, new StartButtonClickedEventArgs());
            OutputHelper.WriteLine("Result: " + res);
        }
    }
}
