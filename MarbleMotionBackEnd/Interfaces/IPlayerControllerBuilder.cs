namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface of a player factory
    /// </summary>
    public interface IPlayerControllerBuilder
    {
        /// <summary>
        /// Build a new <see cref="IPlayerController"/>
        /// </summary>
        /// <returns>the controller</returns>
        IPlayerController Build();

        /// <summary>
        /// Allow a controller to be built with a set of configuration options
        /// </summary>
        /// <param name="options">The <see cref="IPlayerControllerOptions"/> to be used when building the new controller</param>
        /// <returns>A reference to this builder</returns>
        IPlayerControllerBuilder Configure(IPlayerControllerOptions options);

        /// <summary>
        /// Allow a controller to be built with a set of configuration options
        /// </summary>
        /// <param name="httpClientService">The <see cref="IHttpClientService"/> to be used when building the new controller</param>
        /// <returns>A reference to this builder</returns>
        IPlayerControllerBuilder ConfigureHttpClientService(IHttpClientService httpClientService);
    }
}