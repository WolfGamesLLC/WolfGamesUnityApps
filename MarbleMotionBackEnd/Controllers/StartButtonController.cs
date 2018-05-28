using MarbleMotionBackEnd.EventArgs;
using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Models;
using MarbleMotionBackEnd.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MarbleMotionBackEnd.Controllers
{
    /// <summary>
    /// A start button controller
    /// </summary>
    public class StartButtonController : IStartButtonController
    {
        private readonly IStartButtonModel _model;
        private readonly IStartButtonView _view;
        private IPlayerModel _player;
        private readonly IHttpClientService _httpClientService;

        /// <summary>
        /// The object that implements <see cref="IConfiguration"/> that contains the
        /// configuration information for the <see cref="StartButtonController"/>
        /// </summary>
        public IStartButtonControllerOptions Options { get; set; }

        /// <summary>
        /// Initialize a <see cref="StartButtonController"/> object
        /// </summary>
        /// <param name="model">an instance of an object that implements <see cref="IStartButtonModel"/></param>
        /// <param name="view">an instance of an object that implements <see cref="IStartButtonView"/></param>
        /// <param name="player">an instance of an object that implements <see cref="IPlayerModel"/></param>
        public StartButtonController(IStartButtonModel model, IStartButtonView view, IPlayerModel player, IHttpClientService httpClientService)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));

            _view.OnClicked += HandleOnClickedEvent;
        }

        /// <summary>
        /// Event handler for the <see cref="IStartButtonView.OnClicked"/> event
        /// </summary>
        /// <param name="sender">A reference to the object that fired the event</param>
        /// <param name="startButtonClickedEventArgs">An instance of a <see cref="StartButtonClickedEventArgs"/> class</param>
        public void HandleOnClickedEvent(object sender, StartButtonClickedEventArgs startButtonClickedEventArgs)
        {
            Uri uri = new Uri(Options.Uri.ToString().TrimEnd('/') + "/" + _player.Id.ToString());
            _player = _httpClientService.RequestPlayerData(uri);
        }
    }
}