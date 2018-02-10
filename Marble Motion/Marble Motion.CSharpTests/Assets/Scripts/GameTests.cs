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
    public class GameTests
    {
        public const float Y_OFFSET = 100.0f;
        public const float CURRENT_OFFSET = 1.0f;
        public const float ELAPSED_TIME = 1.0f;

        Game testGame;
        PrivateObject pObject;

        #region Helper methods

        private long GetGameScore()
        {
            return (long)pObject.GetFieldOrProperty("score");
        }

        private Vector3 GetPlayerPreviousPosition()
        {
            return (Vector3)pObject.GetFieldOrProperty("playerPreviousPosition");
        }

        private System.Object GetMainMenu()
        {
            return pObject.GetFieldOrProperty("mainMenu");
        }

        private System.Object GetPlayer()
        {
            return pObject.GetFieldOrProperty("player");
        }

        private void SetPlayerPreviousPosition(Vector3 position)
        {
            pObject.SetFieldOrProperty("playerPreviousPosition", position);
        }

        private void RunMotionTest(Vector3 prevPlayerPosition, float exp)
        {
            // players current position is Vector3.One
            SetPlayerPreviousPosition(prevPlayerPosition);
            testGame.Update(ELAPSED_TIME);
            Assert.AreEqual(exp, GetGameScore());
            Assert.AreEqual(UnityEngine.Vector3.one, GetPlayerPreviousPosition());
        }

        #endregion

        [TestInitialize]
        public void InitializeGame()
        {
            MainMenuController menu = new MainMenuController();
            menu.SetScoreController(new MockMenuController());

            BallController ball = new BallController();
            ball.SetMovementController(new MockPlayerController());

            testGame = new Game(menu, ball);
            pObject = new PrivateObject(testGame);
        }

        [TestMethod()]
        public void GameTest()
        {
            Assert.IsInstanceOfType(GetMainMenu(), typeof(MainMenuController));
            Assert.IsInstanceOfType(GetPlayer(), typeof(BallController));
        }

        [TestMethod()]
        public void StartGameTest()
        {
            testGame.Start();
            Assert.AreEqual(0, GetGameScore());
            Assert.AreEqual(UnityEngine.Vector3.one, GetPlayerPreviousPosition());
        }

        [TestMethod()]
        public void NoMotionUpdateTest()
        {
            RunMotionTest(Vector3.one, 0L);
        }

        [TestMethod()]
        public void NegativeXMotionUpdateTest()
        {
            RunMotionTest(new Vector3(1.9f, Y_OFFSET, CURRENT_OFFSET),0.0f);
        }

        [TestMethod()]
        public void PositiveXMotionUpdateTest()
        {
            RunMotionTest(new Vector3(0.1f, Y_OFFSET, CURRENT_OFFSET), 0.0f);
        }

        [TestMethod()]
        public void NegativeYMotionUpdateTest()
        {
            RunMotionTest(new Vector3(CURRENT_OFFSET, Y_OFFSET, 1.9f), 0.0f);
        }

        [TestMethod()]
        public void PositiveYMotionUpdateTest()
        {
            RunMotionTest(new Vector3(CURRENT_OFFSET, Y_OFFSET, 0.1f), 0.0f);
        }

        [TestMethod()]
        public void NegativeMotionUpdateTest()
        {
            RunMotionTest(new Vector3(1.9f, Y_OFFSET, 1.9f), 1f);
        }

        [TestMethod()]
        public void PositiveMotionUpdateTest()
        {
            RunMotionTest(new Vector3(0.1f, Y_OFFSET, 0.1f), 1.0f);
        }

        [TestMethod()]
        public void MotionOnNegativeAxisUpdateTest()
        {
            RunMotionTest(new Vector3(-1.0f, Y_OFFSET, -1.0f), 4.0f);
        }
    }
}