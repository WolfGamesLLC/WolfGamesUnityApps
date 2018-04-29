using MarbleMotionBackEnd.Controllers;
using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Options;
using System;

namespace MarbleMotionBackEnd.Factories
{
    /// <summary>
    /// Factory for creating a StartButtonController
    /// </summary>
    public class StartButtonControllerBuilder : IStartButtonControllerBuilder
    {
        private StartButtonControllerOptions options;
        private IStartButtonModel model;
        private IStartButtonView view;
        private IPlayerModel player;
        private IHttpClientService httpClientService;

        public IStartButtonController Controller { get; private set; }

        /// <summary>
        /// Create a start button controller factory
        /// </summary>
        public StartButtonControllerBuilder(IStartButtonModel model, IStartButtonView view, IPlayerModel player, IHttpClientService httpClientService)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));

            Controller = new StartButtonController(model, view, player, httpClientService);
        }

        /// <summary>
        /// Allow the options for any future controllers to be set 
        /// </summary>
        /// <param name="startButtonControllerOptions">The options to be used by future controllers</param>
        /// <returns>A reference to the current builder</returns>
        public StartButtonControllerBuilder Configure(StartButtonControllerOptions startButtonControllerOptions)
        {
            options = startButtonControllerOptions;
            return this;
        }

        /// <summary>
        /// Build a controller with the currently specified requirements 
        /// </summary>
        /// <returns>The newly constructed controller</returns>
        public StartButtonController Build()
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (view == null) throw new ArgumentNullException(nameof(view));
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (httpClientService == null) throw new ArgumentNullException(nameof(httpClientService));

            var controller = new StartButtonController(model, view, player, httpClientService);
            controller.Options = options;

            return controller;
        }
    }
}