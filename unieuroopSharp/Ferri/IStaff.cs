using System;
using System.Collections.Generic;

namespace unieuroopSharp.Ferri
{
	public interface IStaff
	{
		/// <summary>
		/// This method is used to set the email of the staff.
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		void SetEmail(string email);

		/// <summary>
		/// This method is used to set the pasword of the staff.
		/// </summary>
		/// <param name="password"></param>
		/// <returns></returns>
		void SetPassword(int password);

		/// <summary>
		/// This method is used to set the worktime of the staff.
		/// </summary>
		/// <param name="worktime"></param>
		/// <returns></returns>
		void SetWorkTime(Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>> worktime)

		/// <summary>
		/// This method is used to get the email of the staff.
		/// </summary>
		/// <param></param>
		/// <returns> string email </returns>
		string GetEmail();

		/// <summary>
		/// This method is used to get the passowrd of the staff.
		/// </summary>
		/// <param></param>
		/// <returns> int password </returns>
		int GetPassword();

		/// <summary>
		/// This method is used to get the pair of start worktime and endworktime of the staff.
		/// </summary>
		/// <param></param>
		/// <returns> worktime </returns>
		KeyValuePair<DateTime, DateTime> GetWorkTime(DayOfWeek day);

		/// <summary>
		/// This method is used to get person of the staff.
		/// </summary>
		/// <param></param>
		/// <returns></returns>
		BasePerson GetPerson();

		/// <summary>
		/// This method is used to override ToString of the staff.
		/// </summary>
		/// <param></param>
		/// <returns> string staff </returns>
		string ToString();

		/// <summary>
		/// This method is used to override GetHashCode of the staff.
		/// </summary>
		/// <param></param>
		/// <returns> int staff </returns>
		int GetHashCode();

		/// <summary>
		/// This method is used to override Equals of the staff.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>equals staff</returns>
		bool Equals(object obj);
	}
}

