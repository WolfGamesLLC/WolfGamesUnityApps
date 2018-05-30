namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// An interface for an object  that represents a point in 3D space
    /// </summary>
    public interface IVector3
    {
        /// <summary>
        /// The X position
        /// </summary>
        float X { get; set; }

        /// <summary>
        /// The Y position
        /// </summary>
        float Y { get; set; }

        /// <summary>
        /// The Z position
        /// </summary>
        float Z { get; set; }
    }
}