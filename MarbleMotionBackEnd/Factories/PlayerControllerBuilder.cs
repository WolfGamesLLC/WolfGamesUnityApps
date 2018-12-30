using System;
using MarbleMotionBackEnd.Controllers;
using MarbleMotionBackEnd.Interfaces;

namespace MarbleMotionBackEnd.Factories
{
    /// <summary>
    /// Builds an <see cref="IPlayerController"/>
    /// </summary>
    public class PlayerControllerBuilder : IPlayerControllerBuilder
    {
        private IPlayerControllerOptions options;
        private readonly IPlayerModel model;
        private readonly IPlayerView view;
        private IHttpClientService httpClientService;

        /// <summary>
        /// Create a start button controller factory
        /// </summary>
        public PlayerControllerBuilder(IPlayerModel model, IPlayerView view)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.view = view ?? throw new ArgumentNullException(nameof(view));
        }

        /// <summary>
        /// Allow the options for any future controllers to be set 
        /// </summary>
        /// <param name="playerControllerOptions">The options to be used by future controllers</param>
        /// <returns>A reference to the current builder</returns>
        public IPlayerControllerBuilder Configure(IPlayerControllerOptions playerControllerOptions)
        {
            options = playerControllerOptions;
            return this;
        }

        /// <summary>
        /// Allow the options for any future controllers to be set 
        /// </summary>
        /// <param name="playerControllerHttpClientService">The options to be used by future controllers</param>
        /// <returns>A reference to the current builder</returns>
        public IPlayerControllerBuilder ConfigureHttpClientService(IHttpClientService playerControllerHttpClientService)
        {
            httpClientService = playerControllerHttpClientService;
            return this;
        }

        /// <summary>
        /// Build a controller with the currently specified requirements 
        /// </summary>
        /// <returns>The newly constructed controller</returns>
        public IPlayerController Build()
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (view == null) throw new ArgumentNullException(nameof(view));

            var controller = new PlayerController(model, view);
            controller.Options = options;
            controller.HttpClientService = httpClientService;

            return controller;
        }
    }
}