using MarbleMotionBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Services
{
    /// <summary>
    /// This class is a family of static methods used to convert from 
    /// backend data types to unity data types
    /// </summary>
    public class TypeConverter
    {
        public static Vector3 WGVector3ToVector3(WGVector3 wGVector3)
        {
            return new Vector3(wGVector3.X, wGVector3.Y, wGVector3.Z);
        }
    }
}
