using System;
using Xunit;
using MarbleMotionBackEnd.Controllers;
using Moq;
using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.EventArgs;
using MarbleMotionBackEnd.Models;
using MarbleMotionBackEnd.Services;
using System.Net.Http;

namespace MarbleMotionBackEnd.Integration.XUnitTestSuite
{
    /// <summary>
    /// Integration tests for the <see cref="StartButtonController"/>
    /// </summary>
    public class StartButtonShould
    {
        private StartButtonModel _startButton;
        private StartButtonController _dut;
        private StartButtonView _view;

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        public StartButtonShould()
        {
            _startButton = new StartButtonModel();
            _view = new StartButtonView();
        }
    }
}
