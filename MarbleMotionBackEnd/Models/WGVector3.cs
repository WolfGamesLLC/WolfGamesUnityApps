using MarbleMotionBackEnd.Interfaces;

namespace MarbleMotionBackEnd.Models
{
    /// <summary>
    /// Represents an object in 3D space
    /// </summary>
    public class WGVector3 : IVector3
    {
        public WGVector3(float x = 0.0f, float y = 0.0f, float z = 0.0f)
        {
            X = x;
            Z = z;
        }

        /// <summary>
        /// The X position
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// The Y position
        /// </summary>
//        public float Y { get; set; }

        /// <summary>
        /// The Z position
        /// </summary>
        public float Z { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            IVector3 other = obj as IVector3;

            return other.X == this.X && other.Z == this.Z;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return X.GetHashCode() + Z.GetHashCode();
        }
    }
}