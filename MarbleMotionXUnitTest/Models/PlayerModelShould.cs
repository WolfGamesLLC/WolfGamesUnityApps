using MarbleMotionBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Models
{
    /// <summary>
    /// Test suite for the Marble Motion player model
    /// </summary>
    public class PlayerModelShould
    {
        [Fact]
        public void CreatePlayerModel()
        {
            Assert.NotNull(new PlayerModel());
        }
    }
}
