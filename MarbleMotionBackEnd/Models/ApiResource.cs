﻿namespace MarbleMotionBackEnd.Models
{
    /// <summary>
    /// Base class for all API resource models
    /// </summary>
    public abstract class ApiResource
    {
        /// <summary>
        /// Contains the link used to access the resource
        /// </summary>
        public string href;
    }
}