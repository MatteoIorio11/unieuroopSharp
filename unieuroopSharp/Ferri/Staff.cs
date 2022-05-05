using System;
using System.Collections.Generic;

namespace unieuroopSharp.Ferri
{
	public class Staff : IStaff
	{
		private string _email;
		private int _password;
		private Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>> _worktime;
		private readonly IBasePerson _person;

		public Staff(string name, string surname, DateTime birthday, string code, string email, int password, Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>> worktime)
		{
			this._person = new BasePerson(name, surname, birthday, code);
			this._email = email;
			this._password = password;
			this._worktime = worktime;
		}

		public void SetEmail(string email)
        {
			this._email = email;
        }

		public void SetPassword(int password)
        {
			this._password = password;
        }

		public void SetWorkTime(Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>> worktime)
        {
			this._worktime = worktime;
        }

		public string GetEmail()
        {
			return this._email;
        }

		public int GetPassword()
        {
			return this._password;
        }

		public KeyValuePair<DateTime, DateTime> GetWorkTime(DayOfWeek day)
        {
            if (this._worktime.ContainsKey(day))
            {
				return this._worktime[day];
            }
            else
            {
				throw new ArgumentException("day out of workdays");
            }
        }

		public Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>> getWorkingTimeTable()
        {
			return new Dictionary<DayOfWeek, KeyValuePair<DateTime, DateTime>>(this._worktime);
        }

		public IBasePerson GetPerson()
        {
			return this._person;
        }

        public override string ToString()
        {
			return this._person.ToString() + " " + this._email;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + this._email.GetHashCode() + this._password.GetHashCode() + this._person.GetHashCode() + this._worktime.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            Staff other = (Staff)obj;
            return object.Equals(this._email, other._email) && this._password == other._password && object.Equals(this._person, other._person)
                    && object.Equals(this._worktime, other._worktime);
        }
    }
}

