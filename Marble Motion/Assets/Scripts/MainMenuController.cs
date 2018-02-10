using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MainMenuController
{
    private IScoreController scoreController;

    public void SetScoreController(IScoreController controller)
    {
        scoreController = controller;
    }

    // Set the score text
    public void SetScoreText(long score)
    {
        scoreController.SetScoreText(score.ToString());
    }
}
