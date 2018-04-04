using MarbleMotionBackEnd.Interfaces;

namespace MarbleMotionBackEnd.Models
{
    /// <summary>
    /// The player's model
    /// </summary>
    public class PlayerModel : IPlayerModel
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public PlayerModel()
        {
        }

        /// <summary>
        /// Database generated record key for this table
        /// </summary>
        public string Id { get; set; }
    }
}