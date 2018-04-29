using System;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface for a <see cref="IStartButtonController"/> configuration options 
    /// </summary>
    public interface IStartButtonControllerOptions
    {
        /// <summary>
        /// The Uri used to retieve <see cref="IPlayerModel"/> data from the 
        /// REST api
        /// </summary>
        Uri Uri { get; set; }
    }
}