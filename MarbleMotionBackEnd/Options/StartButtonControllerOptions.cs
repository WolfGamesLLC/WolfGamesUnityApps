using System.Collections.Generic;

namespace MarbleMotionBackEnd.Options
{
    /// <summary>
    /// Options to configure a <see cref="StartButtonController"/>
    /// </summary>
    public class StartButtonControllerOptions
    {
        /// <summary>
        /// The default Uri used by the <see cref="StartButtonController"/> 
        /// </summary>
        public static readonly string DefaultUri = "https://localhost:44340/api/players/";

        public StartButtonControllerOptions()
        {
            Uri = DefaultUri;
        }

        public string Uri { get; set; }
    }
}