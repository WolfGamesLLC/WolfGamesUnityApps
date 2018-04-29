using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;

namespace MarbleMotionBackEnd.Options
{
    /// <summary>
    /// Options to configure a <see cref="StartButtonController"/>
    /// </summary>
    public class StartButtonControllerOptions : IStartButtonControllerOptions
    {
        /// <summary>
        /// The default Uri used by the <see cref="StartButtonController"/> 
        /// </summary>
        public static readonly Uri DefaultUri = new Uri("https://localhost:44340/api/players/");

        public StartButtonControllerOptions()
        {
            Uri = DefaultUri;
        }

        public Uri Uri { get; set; }
    }
}