using System;

namespace unieuroopSharp.Ferri
{
	public interface IClient
	{
        /// <summary>
		/// This method is used to get the base person.
		/// </summary>
		/// <param></param>
		/// <returns> base person</returns>
		BasePerson GetPerson();

        /// <summary>
        /// This method is used to override toStrig.
        /// </summary>
        /// <param></param>
        /// <returns> the string of the client </returns>
        string toString();

        /// <summary>
        /// This method is used to override hashCode.
        /// </summary>
        /// <param></param>
        /// <returns> hashCode for client </returns>
        int hashCode();

        /// <summary>
        /// This method is used to override equals.
        /// </summary>
        /// <param></param>
        /// <returns> equals for the client </returns>
        bool equals(Object obj);
    }
}

