using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using MarbleMotionBackEnd.Factories;
using MarbleMotionBackEnd.Models;
using System;
using MarbleMotionBackEnd.Options;
using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Services;

public class GameController : MonoBehaviour
{
    public MenuController menu;
    public OldPlayerController player;
    public GameObject mainMenu;

    Game game;

    // Initilaize the game
    private void Awake()
    {
        Debug.Log("Game Controller Awake running");

        mainMenu.AddComponent<NonAsyncHttpClient>();
        CreateStartButton();
        CreatePlayer();
    }

    private void CreateStartButton()
    {
        Debug.Log("Game Controller CreateStartButton running");

        var startButtonView = mainMenu.GetComponentInChildren<StartButtonView>();
        if (startButtonView == null)
        {
            Debug.Log("couldn't locate StartButtonView in main menu");
        }

        var player = new PlayerModel
        {
            Id = new Guid("11111111-1111-1111-1111-111111111112"),
            Position = new WGVector3()
        };

        StartButtonModelFactory startButtonModelFactory = new StartButtonModelFactory();
        StartButtonControllerBuilder startButtonControllerBuilder = new StartButtonControllerBuilder(startButtonModelFactory.Model,
                                                                                                    startButtonView);
        IStartButtonControllerOptions options = new StartButtonControllerOptions();
        startButtonControllerBuilder.Configure(options).Build();
    }

    private void CreatePlayer()
    {
        Debug.Log("Game Controller CreatePlayer running");

        var playerView = player.GetComponent<PlayerView>();
        if (playerView == null)
        {
            Debug.Log("couldn't locate PlayerView in main menu");
        }
        
        PlayerModelFactory PlayerModelFactory = new PlayerModelFactory();
        PlayerModelFactory.Model.Id = new Guid("11111111-1111-1111-1111-111111111112");
        PlayerModelFactory.Model.Position = new WGVector3();

        PlayerControllerBuilder PlayerControllerBuilder = new PlayerControllerBuilder(PlayerModelFactory.Model,
                                                                                                    playerView);
        
        
        IPlayerControllerOptions options = new PlayerControllerOptions();
        if (Debug.isDebugBuild) options.Uri = new Uri("https://marblemotiondev.wolfgamesllc.com/api/players/");
        if (Application.isEditor) options.Uri = new Uri("https://localhost:44340/api/players/");
        options.Uri = new Uri("https://localhost:44340/api/players/");

        IHttpClientService httpClient = new HttpClientService(mainMenu.GetComponent<NonAsyncHttpClient>(), new UnityJsonConverter());
        Debug.Log("cookie = {" + httpClient.HandleGetCookieClicked() + "}");

        PlayerControllerBuilder.Configure(options).ConfigureHttpClientService(httpClient).Build();
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("Game Controller Start running");

        MainMenuController mainMenu = new MainMenuController();
        mainMenu.SetScoreController(this.menu);

        BallController ball = new BallController();
        ball.SetMovementController(player);

        game = new Game(mainMenu, ball);

        //        SaveLoad.Load();
        //        game.Score = SaveLoad.data.score;

//        StartCoroutine(GetScores());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel")) mainMenu.SetActive(true);
        game.Update(Time.deltaTime);
    }

    public void OnDestroy()
    {
        Debug.Log("Game Controller OnDestroy running");

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

//        PostScores(transform.position.x.ToString(), transform.position.z.ToString(), game.Score);
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

