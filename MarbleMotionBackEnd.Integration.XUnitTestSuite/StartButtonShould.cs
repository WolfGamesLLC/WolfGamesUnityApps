using System;
using Xunit;
using MarbleMotionBackEnd.Controllers;
using Moq;
using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.EventArgs;

namespace MarbleMotionBackEnd.Integration.XUnitTestSuite
{
    /// <summary>
    /// Integration tests for the <see cref="StartButtonController"/>
    /// </summary>
    public class StartButtonShould
    {
        private Mock<IStartButtonModel> _mockModel;
        private StartButtonController _dut;
        private Mock<IStartButtonView> _mockView;

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        public StartButtonShould()
        {
            _mockModel = new Mock<IStartButtonModel>();
            _mockView = new Mock<IStartButtonView>();
            _dut = new StartButtonController(_mockModel.Object, _mockView.Object);
        }

        /// <summary>
        /// Verify that a click on the <see cref="StartButtonView"/> fires the <see cref="StartButtonController"/>
        /// </summary>
        [Fact]
        public void RaiseOnClickedEvent()
        {
            var dut = new StartButtonController(_mockModel.Object, _mockView.Object);
            Assert.Throws<NotImplementedException>(() => Mock.Get(_mockView.Object)
                .Raise(e => e.OnClicked += null, new StartButtonClickedEventArgs()));
        }
    }
}
