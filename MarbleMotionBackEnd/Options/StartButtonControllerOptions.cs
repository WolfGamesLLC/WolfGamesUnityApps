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
        public static readonly Uri DefaultUri = new Uri("https://marbelmotion.wolfgamesllc.com/api/players");

        /// <summary>
        /// Initialize the options
        /// </summary>
        public StartButtonControllerOptions()
        {
            Uri = DefaultUri;
        }

        /// <summary>
        /// Set the player data REST Api url
        /// </summary>
        public Uri Uri { get; set; }
    }
}