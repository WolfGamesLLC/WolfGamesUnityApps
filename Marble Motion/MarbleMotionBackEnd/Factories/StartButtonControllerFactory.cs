using MarbleMotionBackEnd.Controllers;
using MarbleMotionBackEnd.Interfaces;

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
        public StartButtonControllerFactory(IStartButtonModel model, IStartButtonView view)
        {
            Controller = new StartButtonController(model, view);
        }
    }
}