﻿using MarbleMotionBackEnd.Interfaces;
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

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            PlayerModel other = obj as PlayerModel;

            return other.Id == this.Id;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }
    }
}