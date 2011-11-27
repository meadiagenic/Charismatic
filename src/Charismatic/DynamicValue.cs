namespace Charismatic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Dynamic;

    public class DynamicValue : DynamicObject
    {
        public DynamicValue(object value)
        {
            _rawValue = value;
            _valueType = (_rawValue != null) ? _rawValue.GetType() : typeof(object);
        }

        private readonly object _rawValue;
        private readonly Type _valueType;

        public bool HasValue
        {
            get { return _rawValue != null; }
        }

        public object Value
        {
            get { return _rawValue;  }
        }

        public override string ToString()
        {
            return (_rawValue ==  null) ? base.ToString() : Convert.ToString(_rawValue);
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type == typeof(bool))
            {

            }
            return base.TryConvert(binder, out result);
        }

        public static implicit operator bool(DynamicValue value)
        {
            if (!value.HasValue)
            {
                return false;
            }

            if (value._valueType.IsValueType)
            {
                return Convert.ToBoolean(value._rawValue);
            }

            bool result;
            if (bool.TryParse(value.ToString(), out result))
            {
                return result;
            }

            return default(bool);
        }
    }
}
