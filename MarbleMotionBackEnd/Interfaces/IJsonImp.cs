using System.Collections.Generic;

namespace MarbleMotionBackEnd.Interfaces
{
    /// <summary>
    /// Interface defining an <see cref="IHttpClientService"/> Json converter implementation
    /// </summary>
    public interface IJsonImp
    {
        /// <summary>
        /// Convert a <see cref="IEnumerable{char}"/> in JSON format to an <see cref="IPlayerModel"/>
        /// </summary>
        /// <param name="jsonFormatedText">the JSON <see cref="IEnumerable<char>"/> to be converted</param>
        /// <returns>the resultant <see cref="IPlayerModel"/></returns>
        IPlayerModel ToPlayer(IEnumerable<char> jsonFormatedText);

        /// <summary>
        /// Convert a <see cref="IPlayerModel"/> to a JSON formated <see cref="IEnumerable{char}"/>
        /// </summary>
        /// <param name="playerModel"></param>
        /// <returns></returns>
        IEnumerable<char> FromPlayer(IPlayerModel playerModel);
    }
}