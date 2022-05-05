using System;

namespace unieuroopSharp.Ferri
{
	public interface IBasePerson
	{
        /// <summary>
        /// This method is used to set the name of the person.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
		void SetPersonName(string name);

        /// <summary>
        /// This method is used to get the surname of the person.
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        void SetPersonSurname(string surname);

        /// <summary>
        /// This method is used to set the birthday of the person.
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        void SetPersonBirthday(DateTime birthday);

        /// <summary>
        /// This method is used to get the name of the person.
        /// </summary>
        /// <param></param>
        /// <returns> the name of the person </returns>
        string GetName();

        /// <summary>
        /// This method is used to get the surname of the person.
        /// </summary>
        /// <param></param>
        /// <returns> the surname of the person </returns>
        string GetSurname();

        /// <summary>
        /// This method is used to get the birthday of the person.
        /// </summary>
        /// <param></param>
        /// <returns> the surname of the person</returns>
        DateTime GetBirthdayDate();

        /// <summary>
        /// This method is used to get the code of the person.
        /// </summary>
        /// <param></param>
        /// <returns> the code of the person </returns>
        string GetCode();

        /// <summary>
        /// This method is used to override ToStrig.
        /// </summary>
        /// <param></param>
        /// <returns> the string of the person </returns>
        string ToString();

        /// <summary>
        /// This method is used to override GetHashCode.
        /// </summary>
        /// <param></param>
        /// <returns> hashCode for person </returns>
        int GetHashCode();

        /// <summary>
        /// This method is used to override Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> equals for the person </returns>
        bool Equals(Object obj);
    }
}
