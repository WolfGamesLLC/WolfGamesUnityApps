using MarbleMotionBackEnd.EventArgs;
using MarbleMotionBackEnd.Interfaces;
using System;

namespace MarbleMotionBackEnd.Controllers
{
    /// <summary>
    /// A start button controller
    /// </summary>
    public class StartButtonController : IStartButtonController
    {
        private readonly IStartButtonModel _model;
        private readonly IStartButtonView _view;

        /// <summary>
        /// Initialize a <see cref="StartButtonController"/> object
        /// </summary>
        /// <param name="model">an instance of an object that implements <see cref="IStartButtonModel"/></param>
        /// <param name="view">an instance of an object that implements <see cref="IStartButtonView"/></param>
        public StartButtonController(IStartButtonModel model, IStartButtonView view)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));

            _view.OnClicked += HandleOnClickedEvent;
        }

        /// <summary>
        /// Event handler for the <see cref="IStartButtonView.OnClicked"/> event
        /// </summary>
        /// <param name="sender">A reference to the object that fired the event</param>
        /// <param name="startButtonClickedEventArgs">An instance of a <see cref="StartButtonClickedEventArgs"/> class</param>
        public void HandleOnClickedEvent(object sender, StartButtonClickedEventArgs startButtonClickedEventArgs)
        {
            throw new NotImplementedException();
        }
    }
}