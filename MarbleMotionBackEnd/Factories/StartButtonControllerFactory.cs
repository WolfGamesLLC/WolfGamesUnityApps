using MarbleMotionBackEnd.Controllers;
using MarbleMotionBackEnd.Interfaces;
using System;

namespace MarbleMotionBackEnd.Factories
{
    /// <summary>
    /// Factory for creating a StartButtonController
    /// </summary>
    public class StartButtonControllerFactory : IStartButtonControllerFactory
    {
        public IStartButtonController Controller { get; private set; }

        /// <summary>
        /// Create a start button controller factory
        /// </summary>
        public StartButtonControllerFactory(IStartButtonModel model, IStartButtonView view, IPlayerModel player)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (view == null) throw new ArgumentNullException(nameof(view));
            if (player == null) throw new ArgumentNullException(nameof(player));

            Controller = new StartButtonController(model, view, player);
        }
    }
}