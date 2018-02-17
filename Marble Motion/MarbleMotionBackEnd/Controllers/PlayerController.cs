using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleMotionBackEnd.Controllers
{
    /// <summary>
    /// Player controller
    /// </summary>
    public class PlayerController
    {
        /// <summary>
        /// Default constructor requires a player model and a player view 
        /// be injected
        /// </summary>
        /// <param name="model">A player model</param>
        public PlayerController(IPlayerModel model)
        {

        }
    }
}
