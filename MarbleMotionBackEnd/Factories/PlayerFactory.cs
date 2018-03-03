using System;
using MarbleMotionBackEnd.Interfaces;

namespace MarbleMotionBackEnd.Factories
{
    /// <summary>
    /// A player factory
    /// </summary>
    public class PlayerFactory : IPlayerFactory
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public PlayerFactory()
        {
        }

        public IPlayerModel Model()
        {
            throw new NotImplementedException();
        }
    }
}