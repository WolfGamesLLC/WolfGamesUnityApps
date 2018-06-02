using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Services;
using MarbleMotionBackEnd.Models;

namespace Assets.Editor.Services
{
    /// <summary>
    /// Verify the behaviors of the <see cref="TypeConverter"/>
    /// </summary>
    public class TypeConverterShould
    {
        [Test]
        public void ConvertWGVector3ToVector3()
        {
            Vector3 expectedVector = new Vector3(1.0f, 2.0f, 3.0f);

            Vector3 vector = TypeConverter.WGVector3ToVector3(new WGVector3(1.0f, 2.0f, 3.0f));

            Assert.AreEqual(expectedVector, vector);
        }
    }
}
