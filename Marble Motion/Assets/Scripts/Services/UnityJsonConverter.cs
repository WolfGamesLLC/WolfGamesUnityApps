using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Implementation of a <see cref="IJsonImpl"/> for the Unity engine
/// </summary>
public class UnityJsonConverter : IJsonImp
{
    /// <summary>
    /// Convert a <see cref="IEnumerable{char}"/> in JSON format to an object
    /// </summary>
    /// <param name="jsonFormatedText">the JSON <see cref="IEnumerable<char>"/> to be converted</param>
    /// <returns>the resultant object of type T</returns>
    public T FromJson<T>(IEnumerable<char> jsonFormatedText)
    {
        return JsonUtility.FromJson<T>(jsonFormatedText as string);
    }

    /// <summary>
    /// Convert an object to a JSON formated <see cref="IEnumerable{char}"/>
    /// </summary>
    /// <param name="obj">the object to be converted</param>
    /// <returns>the JSON formated string</returns>
    public IEnumerable<char> ToJson(object obj)
    {
        return JsonUtility.ToJson(obj);
    }

    /// <summary>
    /// Convert a <see cref="IEnumerable{char}"/> in JSON format to an object that implements <see cref="IPlayerModel"/>
    /// </summary>
    /// <param name="jsonFormatedText">the JSON <see cref="IEnumerable<char>"/> to be converted</param>
    /// <returns>the resultant object implementing <see cref="IPlayerModel"/></returns>
    public IPlayerModel PlayerFromJson(IEnumerable<char> jsonFormatedText)
    {
        var playerModelResource = FromJson<PlayerModelResource>(jsonFormatedText);

        Debug.Log("playerModelResource = {" + playerModelResource + "}");

        var playerModel = new PlayerModel();
        playerModel.Score = playerModelResource.Score;
        playerModel.Position.X = playerModelResource.XPosition;
        playerModel.Position.Z = playerModelResource.ZPosition;

        return playerModel;
    }
}
