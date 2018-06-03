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
        /// The instance of an object that implements <see cref="IPlayerModel"/>
        /// that this object is the view for
        /// </summary>
        IPlayerModel Model { get; set; }
        
        /// <summary>
        /// Fired when a player object position changes
        /// </summary>
        event EventHandler<OnPlayerLoadEventArgs> OnLoad;

        /// <summary>
        /// Method used to allow unity to run the OnLoad event
        /// </summary>
        void RunOnLoadEvent();

        /// <summary>
        /// Method used to allow the <see cref="IPlayerController"/> to set the view's position
        /// with the <see cref="IPlayerModel"/> data
        /// </summary>
        /// <param name="">The <see cref="IPlayerModel"/> that contains the new position</param>
        void SetPosition(IPlayerModel playerModel);
    }
}
