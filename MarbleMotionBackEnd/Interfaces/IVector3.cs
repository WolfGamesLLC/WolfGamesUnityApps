namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// An interface for an object  that represents a point in 3D space
    /// </summary>
    public interface IVector3
    {
        /// <summary>
        /// The payer's character X position
        /// </summary>
        float X { get; set; }

        /// <summary>
        /// The payer's character Z position
        /// </summary>
        float Z { get; set; }
    }
}