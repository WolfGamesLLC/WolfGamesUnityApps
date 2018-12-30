using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Services
{
    /// <summary>
    /// Verify the behavior of a <see cref="UnityJsonConverter"/>
    /// </summary>
    public class UnityJsonConverterShould
    {
        /// <summary>
        /// Verify convertion from a <see cref="string"/> to an <see cref="IPlayerModel"/>
        /// </summary>
        [Fact(Skip = "Until I can figure out how to properly unit test Unity internal methods")]
        public void ConvertStringToPlayerModel()
        {
            var mockPLayerModel = new Mock<IPlayerModel>();
            var dut = new UnityJsonConverter();

            var playerModel = dut.FromJson<IPlayerModel>("{}");

            mockPLayerModel.VerifySet(player => player.Score = 100, Times.Once);
        }

        /// <summary>
        /// Verify conversion from an <see cref="IPlayerModel"/> to a <see cref="string"/>
        /// </summary>
        [Fact(Skip = "Until I can figure out how to properly unit test Unity internal methods")]
        public void ConvertStringFromPlayerModel()
        {
            var playerModel = new PlayerModel();
            var dut = new UnityJsonConverter();
            var expectedJsonText = "{}";

            var jsonText = dut.ToJson(playerModel);

            Assert.Equal(expectedJsonText, jsonText);
        }
    }
}
