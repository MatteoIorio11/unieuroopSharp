using System

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
        void setPersonBirthday(DateTime birthday);

        /// <summary>
        /// This method is used to get the name of the person.
        /// </summary>
        /// <param></param>
        /// <returns> the name of the person </returns>
        string getName();

        /// <summary>
        /// This method is used to get the surname of the person.
        /// </summary>
        /// <param></param>
        /// <returns> the surname of the person </returns>
        string getSurname();

        /// <summary>
        /// This method is used to get the birthday of the person.
        /// </summary>
        /// <param></param>
        /// <returns> the surname of the person</returns>
        DateTime getBirthdayDate();

        /// <summary>
        /// This method is used to get the code of the person.
        /// </summary>
        /// <param></param>
        /// <returns> the code of the person </returns>
        string getCode();

        /// <summary>
        /// This method is used to override toStrig.
        /// </summary>
        /// <param></param>
        /// <returns> the string of the person </returns>
        string toString();

        /// <summary>
        /// This method is used to override hashCode.
        /// </summary>
        /// <param></param>
        /// <returns> hashCode for person </returns>
        int hashCode();

        /// <summary>
        /// This method is used to override equals.
        /// </summary>
        /// <param></param>
        /// <returns> equals for the person </returns>
        bool equals(Object obj);
    }
}
