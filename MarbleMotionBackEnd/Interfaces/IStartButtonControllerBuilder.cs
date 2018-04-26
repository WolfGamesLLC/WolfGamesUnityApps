namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface for a <see cref="IStartButtonControllerBuilder"/>
    /// </summary>
    public interface IStartButtonControllerBuilder
    {
        /// <summary>
        /// Return an object that implements <see cref="IStartButtonController"/>
        /// </summary>
        IStartButtonController Controller { get; }
    }
}