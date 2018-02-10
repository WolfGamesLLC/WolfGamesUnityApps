using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tests
{
    [TestClass()]
    public class BallControllerTests
    {
        MockPlayerController testPlayer = new MockPlayerController();
        BallController testBallController = new BallController();
        PrivateObject pObject;
        float expectedSpeed;

        #region Helper functions

        private float GetBallControllerScoreModifier()
        {
            return Convert.ToSingle(pObject.GetFieldOrProperty("scoreModifier"));
        }

        private float GetBallControllerSpeed()
        {
            return Convert.ToSingle(pObject.GetFieldOrProperty("speed"));
        }

        private void RunMoveTest(float hMove, float vMove)
        {
            Vector3 appliedForce = new Vector3(hMove, 0, vMove) * GetBallControllerSpeed();

            testBallController.Move(hMove, vMove);

            Assert.AreEqual(appliedForce, testPlayer.Force);
        }

        private void RunSetSpeedTest(float hMove, float vMove, float expSpeed)
        {
            testBallController.SetSpeed(hMove, vMove);
            Assert.AreEqual(expSpeed, GetBallControllerSpeed());
        }

        #endregion

        [TestInitialize()]
        public void SetControllers()
        {
            testBallController.SetMovementController(testPlayer);

            pObject = new PrivateObject(testBallController);
            expectedSpeed = GetBallControllerSpeed();
        }

        [TestMethod()]
        public void PositiveMoveTest()
        {
            RunMoveTest(1, 1);
        }

        [TestMethod()]
        public void NegativeMoveTest()
        {
            RunMoveTest(-1, -1);
        }

        [TestMethod()]
        public void SetSpeedNoInputTest()
        {
            RunSetSpeedTest(0, 0, BallController.MIN_SPEED);
        }

        [TestMethod()]
        public void SetSpeedHorizontalInputTest()
        {
            RunSetSpeedTest(0.1f, 0, expectedSpeed + 1);
        }

        [TestMethod()]
        public void SetSpeedNegativeHorizontalInputTest()
        {
            RunSetSpeedTest(-0.1f, 0, expectedSpeed + 1);
        }
        [TestMethod()]
        public void SetSpeedVerticalInputTest()
        {
            RunSetSpeedTest(0, 0.1f, expectedSpeed + 1);
        }

        [TestMethod()]
        public void SetSpeedNegativeVerticalInputTest()
        {
            RunSetSpeedTest(0, -0.1f, expectedSpeed + 1);
        }

        [TestMethod()]
        public void SetSpeedBothAxisInputTest()
        {
            RunSetSpeedTest(0.1f, 0.1f, expectedSpeed + 1);
        }

        [TestMethod()]
        public void SetSpeedNegativeBothAxisInputTest()
        {
            RunSetSpeedTest(-0.1f, -0.1f, expectedSpeed + 1);
        }

        [TestMethod()]
        public void ReduceSpeedAtMinValue()
        {
            expectedSpeed = BallController.MIN_SPEED;
            pObject.SetFieldOrProperty("speed", expectedSpeed);

            RunSetSpeedTest(0, 0, expectedSpeed);
        }

        [TestMethod()]
        public void IncreaseSpeedAtMaxValue()
        {
            expectedSpeed = BallController.MAX_SPEED;
            pObject.SetFieldOrProperty("speed", expectedSpeed);

            RunSetSpeedTest(0.1f, 0, expectedSpeed);
        }

        [TestMethod()]
        public void BallControllerTest()
        {
            Assert.AreEqual(BallController.MIN_SPEED, GetBallControllerSpeed());
        }

        [TestMethod()]
        public void Position()
        {
            Assert.AreEqual(Vector3.one, testBallController.Position());
        }
    }
}