using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using MarbleMotionBackEnd.Controllers;

namespace MarbleMotionBackEnd.Options
{
    /// <summary>
    /// Options to configure a <see cref="PlayerController"/>
    /// </summary>
    public class PlayerControllerOptions : IPlayerControllerOptions
    {
        /// <summary>
        /// The default Uri used by the <see cref="PlayerController"/> 
        /// </summary>
        public static readonly Uri DefaultUri = new Uri("https://marbelmotion.wolfgamesllc.com/api/players/");

        /// <summary>
        /// Initialize the options
        /// </summary>
        public PlayerControllerOptions()
        {
            Uri = DefaultUri;
        }

        /// <summary>
        /// Set the player data REST Api url
        /// </summary>
        public Uri Uri { get; set; }
    }
}