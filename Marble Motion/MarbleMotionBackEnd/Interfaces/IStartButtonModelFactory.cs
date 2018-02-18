namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface for a <see cref="IStartButtonModelFactory"/>
    /// </summary>
    public interface IStartButtonModelFactory
    {
        /// <summary>
        /// Return an object that implements <see cref="IStartButtonModel"/>
        /// </summary>
        IStartButtonModel Model { get; }
    }
}