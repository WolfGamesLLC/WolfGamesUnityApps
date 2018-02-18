namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface for a <see cref="IStartButtonControllerFactory"/>
    /// </summary>
    public interface IStartButtonControllerFactory
    {
        /// <summary>
        /// Return an object that implements <see cref="IStartButtonController"/>
        /// </summary>
        IStartButtonController Controller { get; }
    }
}