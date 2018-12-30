using System;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface for a <see cref="IPlayerController"/> configuration options 
    /// </summary>
    public interface IPlayerControllerOptions
    {
        /// <summary>
        /// The Uri used to retieve <see cref="IPlayerModel"/> data from the 
        /// REST api
        /// </summary>
        Uri Uri { get; set; }
    }
}