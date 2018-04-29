using MarbleMotionBackEnd.Controllers;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface for a <see cref="IStartButtonControllerBuilder"/>
    /// </summary>
    public interface IStartButtonControllerBuilder
    {
        /// <summary>
        /// Build a new <see cref="IStartButtonController"/>
        /// </summary>
        /// <returns>the controller</returns>
        IStartButtonController Build();

        /// <summary>
        /// Allow a controller to be built with a set of configuration options
        /// </summary>
        /// <param name="options">The options to be used when building the new controller</param>
        /// <returns>A reference to this builder</returns>
        IStartButtonControllerBuilder Configure(IStartButtonControllerOptions options);
    }
}