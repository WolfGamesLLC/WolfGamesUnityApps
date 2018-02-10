using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Reflection;
using UnityEngine;

public interface IPlayerController
{
    void StartPlayer();
}

public interface IScoreController
{
    void SetScoreText(string score);
}

public interface IMovementController
{
    Vector3 Position();
    void MoveObject(Vector3 force);
}

public class Game
{
    public const float SCORE_MULTIPLIER = 0.75f;

    MainMenuController mainMenu;
    BallController player;
    long score;
    Vector3 playerPreviousPosition;

    public long Score
    {
        get { return score; }

        set
        {
            score = value;
            mainMenu.SetScoreText(Score);
        }
    }

    public Game(MainMenuController menu, BallController ball)
    {
        mainMenu = menu;
        player = ball;
    }

    public void Start()
    {
        Score = 0;
        playerPreviousPosition = player.Position();
    }

    public void Update(float elapsedTime)
    {
        Vector3 delta = (playerPreviousPosition - player.Position()) / elapsedTime;
        Score += (long)(Math.Abs(delta.x * SCORE_MULTIPLIER) + Math.Abs(delta.z * SCORE_MULTIPLIER));
        playerPreviousPosition = player.Position();
    }
}

[Serializable()]
public class SaveData : ISerializable
{
    public long score;

    public SaveData() { }

    // This constructor is called automatically by the parent class, ISerializable
    // We get to custom-implement the serialization process here
    public SaveData(SerializationInfo info, StreamingContext ctxt)
    {
        // Get the values from info and assign them to the appropriate properties. Make sure to cast each variable.
        // Do this for each var defined in the Values section above
        score = (long)info.GetValue("score", typeof(long));
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("score", (score));
    }
}

// === This is the class that will be accessed from scripts ===
public class SaveLoad
{
    public static SaveData data;
    public static string currentFilePath = Application.persistentDataPath + "SaveData.cjc";    // Edit this for different save files

    // Call this to write data
    public static void Save()  // Overloaded
    {
        Save(currentFilePath);
    }
    public static void Save(string filePath)
    {
        Stream stream = File.Open(filePath, FileMode.Create);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Binder = new VersionDeserializationBinder();
        bformatter.Serialize(stream, data);
        stream.Close();
    }

    // Call this to load from a file into "data"
    public static void Load() { Load(currentFilePath); }   // Overloaded
    public static void Load(string filePath)
    {
        data = new SaveData();
        Stream stream = File.Open(filePath, FileMode.Open);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Binder = new VersionDeserializationBinder();
        data = (SaveData)bformatter.Deserialize(stream);
        stream.Close();

        // Now use "data" to access your Values
    }

}

// === This is required to guarantee a fixed serialization assembly name, which Unity likes to randomize on each compile
// Do not change this
public sealed class VersionDeserializationBinder : SerializationBinder
{
    public override Type BindToType(string assemblyName, string typeName)
    {
        if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName))
        {
            Type typeToDeserialize = null;

            assemblyName = Assembly.GetExecutingAssembly().FullName;

            // The following line of code returns the type. 
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));

            return typeToDeserialize;
        }

        return null;
    }
}
