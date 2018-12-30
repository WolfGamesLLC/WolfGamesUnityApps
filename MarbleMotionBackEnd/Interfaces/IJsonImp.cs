using System.Collections.Generic;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface defining an <see cref="IHttpClientService"/> Json converter implementation
    /// </summary>
    public interface IJsonImp
    {
        /// <summary>
        /// Convert a <see cref="IEnumerable{char}"/> in JSON format to an object
        /// </summary>
        /// <param name="jsonFormatedText">the JSON <see cref="IEnumerable<char>"/> to be converted</param>
        /// <returns>the resultant object of type T</returns>
        T FromJson<T>(IEnumerable<char> jsonFormatedText);

        /// <summary>
        /// Convert an object to a JSON formated <see cref="IEnumerable{char}"/>
        /// </summary>
        /// <param name="obj">the object to be converted</param>
        /// <returns>the JSON formated string</returns>
        IEnumerable<char> ToJson(object obj);

        /// <summary>
        /// Convert a <see cref="IEnumerable{char}"/> in JSON format to an object that implements <see cref="IPlayerModel"/>
        /// </summary>
        /// <param name="jsonFormatedText">the JSON <see cref="IEnumerable<char>"/> to be converted</param>
        /// <param name="playerModel">the <see cref="IPlayerModel"/> to be populated</param>
        void PlayerFromJson(IEnumerable<char> jsonFormatedText, IPlayerModel playerModel);
    }
}