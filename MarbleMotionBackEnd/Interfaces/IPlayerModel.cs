using MarbleMotionBackEnd.Interfaces;
using System;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Player model interface
    /// </summary>
    public interface IPlayerModel
    {
        /// <summary>
        /// Database generated record key for this table
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// The player's score
        /// </summary>
        long Score { get; set; }

        /// <summary>
        /// The payer's character X position
        /// </summary>
        int XPosition { get; set; }

        /// <summary>
        /// The payer's character Z position
        /// </summary>
        int ZPosition { get; set; }

        /// <summary>
        /// The player's position in 3D space
        /// </summary>
        IVector3 Position { get; set; }
    }
}