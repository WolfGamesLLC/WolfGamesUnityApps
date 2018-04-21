using MarbleMotionBackEnd.EventArgs;
using MarbleMotionBackEnd.Interfaces;
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
        private readonly IPlayerModel _player;
        private readonly IHttpClientService _httpClientService;

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
        public async void HandleOnClickedEvent(object sender, StartButtonClickedEventArgs startButtonClickedEventArgs)
        {
            HttpResponseMessage response = await _httpClientService.RequestAsync(new Uri("https://localhost:44340/api/players"));
            if (response.IsSuccessStatusCode)
            {
                _player.Id = await response.Content.ReadAsStringAsync();
            }
        }
    }
}