using MarbleMotionBackEnd.Interfaces;
using System;

namespace MarbleMotionBackEnd.Models
{
    /// <summary>
    /// The player's model
    /// </summary>
    public class PlayerModel : IPlayerModel
    {
        /// <summary>
        /// Database generated record key for this table
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The player's score
        /// </summary>
        public long Score { get; set; }

        /// <summary>
        /// The payer's character X position
        /// </summary>
        public int XPosition { get; set; }

        /// <summary>
        /// The payer's character Z position
        /// </summary>
        public int ZPosition { get; set; }
    }
}