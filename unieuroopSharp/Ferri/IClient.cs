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
		IBasePerson GetPerson();

        /// <summary>
        /// This method is used to override ToStrig.
        /// </summary>
        /// <param></param>
        /// <returns> the string of the client </returns>
        string ToString();

        /// <summary>
        /// This method is used to override GetHashCode.
        /// </summary>
        /// <param></param>
        /// <returns> hashCode for client </returns>
        int GetHashCode();

        /// <summary>
        /// This method is used to override Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> equals for the client </returns>
        bool Equals(Object obj);
    }
}

