using System;
namespace unieuroopSharp.Ferri
{
	public class Client : IClient
	{
		private readonly IBasePerson _person;

		public Client(string name, string surname, DateTime birthday, string code)
		{
			this._person = new BasePerson(name, surname, birthday, code);
		}

		public IBasePerson GetPerson()
        {
			return this._person;
        }

        public override string ToString()
        {
			return this._person.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + this._person.GetHashCode();
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
            Client other = (Client)obj;
            return object.Equals(this._person, other._person);
        }
    }
}

