using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour, IScoreController
{
    MainMenuController mainMenuController;
    public Text scoreText;

    // Run when the enable event is fired
    public void OnEnable()
    {
        mainMenuController = new MainMenuController();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    #region IScoreController implementation

    public void SetScoreText(string score)
    {
        scoreText.text = score;
    }

    #endregion
}
