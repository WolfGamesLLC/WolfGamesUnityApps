namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface for a <see cref="IPlayerModelFactory"/>
    /// </summary>
    public interface IPlayerModelFactory
    {
        /// <summary>
        /// Return an object that implements <see cref="IPlayerModel"/>
        /// </summary>
        IPlayerModel Model { get; }
    }
}