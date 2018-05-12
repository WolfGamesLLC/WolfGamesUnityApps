using MarbleMotionBackEnd.Interfaces;
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
    /// Convert an <see cref="IPlayerModel"/> to a <see cref="IEnumerable{char}"/>
    /// </summary>
    /// <param name="playerModel">the player data object to be converted</param>
    /// <returns>the resultant string</returns>
    public IEnumerable<char> FromPlayer(IPlayerModel playerModel)
    {
        return JsonUtility.ToJson(playerModel);
    }

    /// <summary>
    /// Convert an <see cref="IEnumerable{char}"/> to a <see cref="IPlayerModel"/>
    /// </summary>
    /// <param name="jsonFormatedText">the string to convert</param>
    /// <returns>the resultant player data object</returns>
    public IPlayerModel ToPlayer(IEnumerable<char> jsonFormatedText)
    {
        return JsonUtility.FromJson<IPlayerModel>(jsonFormatedText as string);
    }
}
