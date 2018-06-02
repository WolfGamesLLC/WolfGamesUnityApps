namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface of a start button controller
    /// </summary>
    public interface IPlayerController
    {
        /// <summary>
        /// <see cref="IPlayerControllerOptions"/> options for the controller
        /// </summary>
        IPlayerControllerOptions Options { get; set; }

        /// <summary>
        /// <see cref="IHttpClientService"/> used by the controller
        /// </summary>
        IHttpClientService HttpClientService { get; set; }
    }
}