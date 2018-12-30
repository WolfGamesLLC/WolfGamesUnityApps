using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarbleMotionXUnitTest.Models
{
    /// <summary>
    /// Test suite for the WGVector3 implementation
    /// </summary>
    public class WGVector3Should
    {
        private WGVector3 _dut;
        private WGVector3 _expected;

        /// <summary>
        /// Initialize the test suite
        /// </summary>
        public WGVector3Should()
        {
            _dut = new WGVector3();
            _expected = new WGVector3();
        }

        /// <summary>
        /// verify that an instance of WGVector3 can be created
        /// </summary>
        [Fact]
        public void CreateWGVector3()
        {
            Assert.NotNull(new WGVector3());
        }

        /// <summary>
        /// verify that an instance of WGVector3 can be created with values
        /// </summary>
        [Fact]
        public void CreateWGVector3WithValues()
        {
            _dut = new WGVector3(1f,2f,3f);

            Assert.Equal(1f, _dut.X);
            Assert.Equal(2f, _dut.Y);
            Assert.Equal(3f, _dut.Z);
        }

        /// <summary>
        /// The X position should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetXPosition()
        {
            int expected = 12345;
            _dut.X = expected;
            Assert.Equal(expected, _dut.X);
        }

        /// <summary>
        /// The Y position should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetYPosition()
        {
            int expected = 12345;
            _dut.Y = expected;
            Assert.Equal(expected, _dut.Y);
        }

        /// <summary>
        /// The Z position should be set and retrieved
        /// </summary>
        [Fact]
        public void ShouldSetAndGetZPosition()
        {
            int expected = 12345;
            _dut.Z = expected;
            Assert.Equal(expected, _dut.Z);
        }

        /// <summary>
        /// Verify that WGVector3 is not equal to a null
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithNull()
        {
            Assert.False(_dut == null);
        }

        /// <summary>
        /// Verify that WGVector3 is not equal to another type
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithNonWGVector3()
        {
            Object other = new Object();
            Assert.Throws<InvalidCastException>(() => _dut == (WGVector3) other);
        }

        /// <summary>
        /// Verify that two WGVector3 objects with different x positions return not equal
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithNotEqualXPosition()
        {
            _expected.X = 1;

            _dut.X = 2;

            Assert.NotEqual(_expected, _dut);
        }

        /// <summary>
        /// Verify that two WGVector3 objects with equal x positions return equal
        /// </summary>
        [Fact]
        public void ReturnEqualWithEqualXPosition()
        {
            _expected.X = 1;

            _dut.X = _expected.X;

            Assert.Equal(_expected, _dut);
        }

        /// <summary>
        /// Verify that two WGVector3 objects with different y positions return not equal
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithNotEqualYPosition()
        {
            _expected.Y = 1;

            _dut.Y = 2;

            Assert.NotEqual(_expected, _dut);
        }

        /// <summary>
        /// Verify that two WGVector3 objects with equal y positions return equal
        /// </summary>
        [Fact]
        public void ReturnEqualWithEqualYPosition()
        {
            _expected.Y = 1;

            _dut.Y = _expected.Y;

            Assert.Equal(_expected, _dut);
        }

        /// <summary>
        /// Verify that two WGVector3 objects with different z positions return not equal
        /// </summary>
        [Fact]
        public void ReturnNotEqualWithNotEqualZPosition()
        {
            _expected.Z = 1;

            _dut.Z = 2;

            Assert.NotEqual(_expected, _dut);
        }

        /// <summary>
        /// Verify that two WGVector3 objects with equal z positions return equal
        /// </summary>
        [Fact]
        public void ReturnEqualWithEqualZPosition()
        {
            _expected.Z = 1;

            _dut.Z = _expected.Z;

            Assert.Equal(_expected, _dut);
        }

        /// <summary>
        /// Verify that two WGVector3 objects with equal ids return the same hash code
        /// </summary>
        [Fact]
        public void ReturnEqualHashWithEqualXYZ()
        {
            _expected = new WGVector3(1f, 1f, 1f);

            _dut = _expected;

            Assert.Equal(_expected.GetHashCode(), _dut.GetHashCode());
        }
    }
}
