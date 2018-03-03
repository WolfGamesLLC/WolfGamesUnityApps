using MarbleMotionBackEnd.EventArgs;
using System;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface for a start button view
    /// </summary>
    public interface IStartButtonView
    {
        event EventHandler<StartButtonClickedEventArgs> OnClicked;
    }
}