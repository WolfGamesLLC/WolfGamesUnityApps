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
        private PlayerModel _player;
        private HttpClientService httpClientService;

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        public StartButtonShould()
        {
            _startButton = new StartButtonModel();
            _view = new StartButtonView();
            _player = new PlayerModel();
            httpClientService = new HttpClientService();
        }

        /// <summary>
        /// Verify that a click on the <see cref="StartButtonView"/> loads the current user's player data
        /// </summary>
        [Fact(Skip = "This is a more difficult test. Working on getting simpler ones working first")]
        public void LoadsPlayerDataAndDisableMenuOnClick()
        {
            var dut = new StartButtonController(_startButton, _view, _player, httpClientService);
            object[] parms = { this, new StartButtonClickedEventArgs() };

            throw new NotImplementedException("This is a more difficult test. Working on getting simpler ones working first");
        }
    }
}
