using System;

namespace MarbleMotionBackEnd.Models
{
    /// <summary>
    /// Player data model for the Marble Motion game
    /// </summary>
    public class PlayerModelResource : ApiResource
    {
        /// <summary>
        /// The player's most recent recorded score
        /// </summary>
        public long score;

        /// <summary>
        /// The payer's character X position
        /// </summary>
        public int xPosition;

        /// <summary>
        /// The payer's character Z position
        /// </summary>
        public int zPosition;
    }
}