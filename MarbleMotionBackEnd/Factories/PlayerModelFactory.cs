using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Models;

namespace MarbleMotionBackEnd.Factories
{
    /// <summary>
    /// Factory for creating start button models
    /// </summary>
    public class PlayerModelFactory : IPlayerModelFactory
    {
        /// <summary>
        /// Return an object that implements the <see cref="IPlayerModel"/> interface
        /// </summary>
        public IPlayerModel Model { get; private set; }

        /// <summary>
        /// Create the instance of the <see cref="PlayerModel"/>
        /// </summary>
        public PlayerModelFactory()
        {
            Model = new PlayerModel();
        }
    }
}