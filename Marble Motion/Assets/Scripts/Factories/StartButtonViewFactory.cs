using MarbleMotionBackEnd.Interfaces;

/// <summary>
/// Factory for creating instances of <see cref="StartButtonView"/>
/// </summary>
public class StartButtonViewFactory : IStartButtonViewFactory
{
    /// <summary>
    /// <see cref="IStartButtonView"/> implementor object accessor
    /// </summary>
    public IStartButtonView View { get; private set; }

    /// <summary>
    /// Create the instance of the <see cref="StartButtonView"/> 
    /// </summary>
    public StartButtonViewFactory()
    {
        View = new StartButtonView();
    }
}