using System;
namespace unieuroopSharp.Ferri
{
	public class BasePerson : IBasePerson
	{
		private string _name;
		private string _surname;
		private DateTime _birthday;
		private readonly string _code;

		public BasePerson(string name, string surname, DateTime birthday, string code)
		{
			this._name = name;
			this._surname = surname;
			this._birthday = birthday;
			this._code = code;
		}

		public void SetPersonName(string name)
        {
			this._name = name;
        }

		public void SetPersonSurname(string surname)
        {
			this._surname = surname;
        }

		public void SetPersonBirthday(DateTime birthday)
        {
			this._birthday = birthday;
        }

		public string GetName()
        {
			return this._name;
        }

		public string GetSurname()
        {
			return this._surname;
        }

		public DateTime GetBirthday()
        {
			return this._birthday;
        }

		public string GetCode()
        {
			return this._code;
        }

        public override string ToString()
        {
			return this._name + " " + this._surname + " " + this._birthday + " " + this._code;
        }

        public override int GetHashCode()
        {
			int prime = 31;
			int result = 1;
			result = prime * result + ((this._birthday == null) ? 0 : this._birthday.GetHashCode());
			result = prime * result + ((this._name == null) ? 0 : this._name.GetHashCode());
			result = prime * result + ((this._surname == null) ? 0 : this._surname.GetHashCode());
			return result;
		}

        public override bool Equals(object obj)
        {
			if (this == obj)
			{
				return true;
			}
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			if (GetType() != obj.GetType())
			{
				return false;
			}
			BasePerson other = (BasePerson)obj;
			return this._code.Equals(other.GetCode());
		}
    }
}
