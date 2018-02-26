using MarbleMotionBackEnd.Interfaces;
using System;

namespace MarbleMotionBackEnd.Controllers
{
    /// <summary>
    /// A start button controller
    /// </summary>
    public class StartButtonController : IStartButtonController
    {
        private readonly IStartButtonModel model;
        private readonly IStartButtonView view;

        public StartButtonController(IStartButtonModel model, IStartButtonView view)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.view = view ?? throw new ArgumentNullException(nameof(view));
        }
    }
}