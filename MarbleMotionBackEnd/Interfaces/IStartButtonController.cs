namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface of a start button controller
    /// </summary>
    public interface IStartButtonController
    {
        /// <summary>
        /// Configurations options for the controller
        /// </summary>
        IStartButtonControllerOptions Options { get; set; }
    }
}