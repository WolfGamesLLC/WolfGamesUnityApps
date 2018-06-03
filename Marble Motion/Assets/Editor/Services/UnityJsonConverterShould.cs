using MarbleMotionBackEnd.Models;
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
        public void ConvertBasicJsonToObject()
        {
            string jsonText = "{\"text\" : \"value\", \"num\" : 123 }";

            BasicJsonTestObject _dut = JsonUtility.FromJson<BasicJsonTestObject>(jsonText);

            Assert.AreEqual("value", _dut.text);
            Assert.AreEqual(123L, _dut.num);
        }

        private class ComplexJsonTestObject
        {
            public string notNeeded;
            public string text;
            public long num;
        }

        /// <summary>
        /// Verify a complex object that contains fields that do not need
        /// to be parsed can be converted from JSON
        /// </summary>
        [Test]
        public void ConvertComplexsJsonToObject()
        {
            string jsonText = "{\"text\" : \"value\", \"num\" : 123 }";

            ComplexJsonTestObject _dut = JsonUtility.FromJson<ComplexJsonTestObject>(jsonText);

            Assert.AreEqual("value", _dut.text);
            Assert.AreEqual(123L, _dut.num);
        }

        private class TestPlayerModelResource
        {
            public long score;
            public int xPosition;
            public int zPosition;
        }

        /// <summary>
        /// Verify a <see cref="PlayerModelResource"/> object can be converted from JSON
        /// </summary>
        [Test]
        public void ConvertJsonToPlayerModelResource()
        {
            string jsonText = "{\"href\":\"https://localhost:44340/api/players/11111111-1111-1111-1111-111111111111\",\"score\":1,\"xPosition\":10,\"zPosition\":100}";

            PlayerModelResource _dut = JsonUtility.FromJson<PlayerModelResource>(jsonText);

            Assert.AreEqual(1L, _dut.score);
            Assert.AreEqual(10, _dut.xPosition);
            Assert.AreEqual(100, _dut.zPosition);
        }
    }
}
