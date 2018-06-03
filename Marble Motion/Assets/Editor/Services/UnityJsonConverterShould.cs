using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Editor.Services
{
    /// <summary>
    /// Verify <see cref="UnityJsonConverter"/> behaviors
    /// </summary>
    public class UnityJsonConverterShould
    {
        private class BasicJsonTestObject
        {
            public string text;
            public long num;
        }

        /// <summary>
        /// Verify a basic object can be convert from JSON
        /// </summary>
        [Test]
        public void ConvertJsonToObject()
        {
            string jsonText = "{\"text\" : \"value\", \"num\" : 123 }";

            BasicJsonTestObject _dut = JsonUtility.FromJson<BasicJsonTestObject>(jsonText);

            Assert.AreEqual("value", _dut.text);
            Assert.AreEqual(123L, _dut.num);
        }
    }
}
