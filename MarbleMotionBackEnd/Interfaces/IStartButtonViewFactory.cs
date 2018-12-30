using MarbleMotionBackEnd.Factories;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface for a <see cref="StartButtonViewFactory"/>
    /// </summary>
    public interface IStartButtonViewFactory
    {
        IStartButtonView View { get; }
    }
}