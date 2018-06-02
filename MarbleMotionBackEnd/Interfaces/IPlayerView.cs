using MarbleMotionBackEnd.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// The player's view interface
    /// </summary>
    public interface IPlayerView
    {
        /// <summary>
        /// Fired when a player object position changes
        /// </summary>
        event EventHandler<OnPlayerPositionChangedEventArgs> OnPlayerPositionChanged;
    }
}
