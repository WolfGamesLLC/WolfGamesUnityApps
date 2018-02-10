﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HSController : MonoBehaviour
{
    private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
    public string addScoreURL = "http://www.wolfgamesllc.com/testadddata.php?"; //be sure to add a ? to your url
    public string highscoreURL = "http://www.wolfgamesllc.com/testdisplaydata.php";
    public Text text;

    void Start()
    {
        StartCoroutine(GetScores());
    }

    // remember to use StartCoroutine when calling this function!
    IEnumerator PostScores(string position_x, string position_y, int score)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        string hash = MD5Test.Md5Sum(position_x + position_y + score + secretKey);

        string post_url = addScoreURL + "position_x=" + WWW.EscapeURL(position_x) + "position_y=" + WWW.EscapeURL(position_y) + "&score=" + score + "&hash=" + hash;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }

    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores()
    {
        text.text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            text.text += hs_get.text; // this is a GUIText that will display the scores in game.
        }
    }
}
