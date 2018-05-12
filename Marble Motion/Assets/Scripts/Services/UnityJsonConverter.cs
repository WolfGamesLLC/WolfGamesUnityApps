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
}
