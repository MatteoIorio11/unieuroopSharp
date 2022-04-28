using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopSharp.Iorio
{
    class Product
    {
        public enum Category
        {

        }
        private readonly Category _category;
        private readonly String _name;

        public Category GetCategory()
        {
            return this._category;
        }
        public String GetName()
        {
            return this._name;
        }
    }
}
