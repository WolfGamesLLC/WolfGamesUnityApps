using MarbleMotionBackEnd.EventArgs;
using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleMotionBackEnd.Controllers
{
    /// <summary>
    /// Player controller
    /// </summary>
    public class PlayerController : IPlayerController
    {
        private readonly IPlayerModel model;
        private readonly IPlayerView view;

        /// <summary>
        /// Default constructor requires a player model and a player view 
        /// be injected
        /// </summary>
        /// <param name="model">A player model</param>
        public PlayerController(IPlayerModel model, IPlayerView view)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.view = view ?? throw new ArgumentNullException(nameof(view));

            this.view.OnLoad += HandleOnLoadEvent;
        }

        /// <summary>
        /// The <see cref="IPlayerControllerOptions"/> to be used by this object
        /// </summary>
        public IPlayerControllerOptions Options { get; set; }

        /// <summary>
        /// The <see cref="IHttpClientService"/> to be used by this object
        /// </summary>
        public IHttpClientService HttpClientService { get; set; }

        /// <summary>
        /// Event handler for the <see cref="IPlayerView.OnLoad"/> event
        /// </summary>
        /// <param name="sender">A reference to the object that fired the event</param>
        /// <param name="onPlayerLoadEventArgs">An instance of a <see cref="OnPlayerLoadEventArgs"/> class</param>
        public void HandleOnLoadEvent(object p, OnPlayerLoadEventArgs onPlayerLoadEventArgs)
        {
            Uri uri = new Uri(Options.Uri.ToString().TrimEnd('/') + "/" + model.Id.ToString());
            HttpClientService.RequestPlayerData(uri, model);
        }
    }
}
