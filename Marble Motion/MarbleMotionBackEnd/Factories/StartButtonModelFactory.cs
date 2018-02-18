using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Models;

namespace MarbleMotionBackEnd.Factories
{
    /// <summary>
    /// Factory for creating start button models
    /// </summary>
    public class StartButtonModelFactory : IStartButtonModelFactory
    {
        /// <summary>
        /// Return an object that implements the <see cref="IStartButtonModel"/> interface
        /// </summary>
        public IStartButtonModel Model { get; }

        public StartButtonModelFactory()
        {
            Model = new StartButtonModel();
        }
    }
}