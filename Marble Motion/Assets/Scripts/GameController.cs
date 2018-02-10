﻿using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public MenuController menu;
    public PlayerController player;
    public GameObject mainMenu;

    Game game;

    // Use this for initialization
    void Start()
    {
        MainMenuController mainMenu = new MainMenuController();
        mainMenu.SetScoreController(this.menu);

        BallController ball = new BallController();
        ball.SetMovementController(player);

        game = new Game(mainMenu, ball);

        //        SaveLoad.Load();
        //        game.Score = SaveLoad.data.score;

        StartCoroutine(GetScores());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel")) mainMenu.SetActive(true);
        game.Update(Time.deltaTime);
    }

    public void OnDestroy()
    {
        //  Use this call for wherever a player triggers a custom event
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            { "score", game.Score }
        });
        //        SaveLoad.data.score = game.Score;
        //        SaveLoad.Save();

        // Use this call for each and every place that a player triggers a monetization event
        //        Analytics.Transaction("MarbleMotion", 0.99m, "USD", null, null);

        //        Analytics.SetUserGender(Gender.Male);
        //        Analytics.SetUserBirthYear(2014);

        PostScores(transform.position.x.ToString(), transform.position.z.ToString(), game.Score);
    }

    private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
    public string addScoreURL = "http://www.wolfgamesllc.com/testadddata.php?"; //be sure to add a ? to your url
    public string highscoreURL = "http://www.wolfgamesllc.com/testdisplaydata.php";
    public Text text;

    // remember to use StartCoroutine when calling this function!
    void PostScores(string position_x, string position_y, long score)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        string hash = MD5Test.Md5Sum(position_x + position_y + score.ToString() + secretKey);
        string post_url = addScoreURL + "position_x=" + WWW.EscapeURL(position_x) + "&position_y=" + WWW.EscapeURL(position_y) + "&score=" + score + "&hash=" + hash;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);

        while (true)
        {
            if (hs_post.isDone) break;
        }

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
        else
        {
            Debug.Log("post url = {" + post_url + "}");
            Debug.Log("post returned = {" + hs_post.text + "}");
        }
    }

    // remember to use StartCoroutine when calling this function!
    //    IEnumerator PostScores(string position_x, string position_y, long score)
    //    {
    //        //This connects to a server side php script that will add the name and score to a MySQL DB.
    //        // Supply it with a string representing the players name and the players score.
    //        string hash = MD5Test.Md5Sum(position_x + position_y + score + secretKey);
    //
    //        string post_url = addScoreURL + "position_x=" + WWW.EscapeURL(position_x) + "position_y=" + WWW.EscapeURL(position_y) + "&score=" + score + "&hash=" + hash;
    //
    //        // Post the URL to the site and create a download object to get the result.
    //        WWW hs_post = new WWW(post_url);
    //        yield return hs_post; // Wait until the download is done
    //
    //        Debug.Log(hs_post.text);
    //        if (hs_post.error != null)
    //        {
    //            print("There was an error posting the high score: " + hs_post.error);
    //        }
    //    }

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
            Debug.Log(hs_get.text);
        }
    }
}

