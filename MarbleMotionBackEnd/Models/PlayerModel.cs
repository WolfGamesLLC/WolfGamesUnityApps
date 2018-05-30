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
        /// The player's position in 3D space
        /// </summary>
        public IVector3 Position { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            PlayerModel other = obj as PlayerModel;

            return other.Id == this.Id && other.Score == this.Score && other.Position == this.Position;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}