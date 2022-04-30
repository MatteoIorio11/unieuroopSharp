using System;
using System.Collections.Generic;
using System.Text;

namespace unieuroopSharp.Iorio
{
    public class Optional<T>
    {
        private T _value;
        public bool IsPresent { get => !(this._value == null);}
        public bool IsEmpty{ get => this._value == null; }
        public T  Get { get=> this._value;}
        private T SetValue { set => this._value = value; }

        private Optional() { }
        public static Optional<T> Of(T value)
        {
            Optional<T> optional = new Optional<T>();
            optional.SetValue = value;
            return optional;
        }
        public static Optional<T> Empty()
        {
            return new Optional<T>();
        }
    }
}
