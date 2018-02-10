using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class MockMenuController : IPlayerController, IScoreController
    {
        public string Score;

        #region IGameController implementation

        public void StartPlayer()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IScoreController implementation

        public void SetScoreText(string score)
        {
            Score = score;
        }

        #endregion
    }
}
