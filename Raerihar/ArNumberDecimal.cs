﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Aritiafel.Organizations.RaeriharUniversity
{
    public class ArNumberDecimal : ArNumber
    {
        private int _Integer;
        private int _Fraction;

        //public const ArNumberDecimal MaxValue = 2147483647.2147483647;
        //public const ArNumberDecimal MinValue = -2147483648.2147483648;

        public override object Integer => _Integer;
        public override object Fraction => _Fraction;
        public ArNumberDecimal()
            : this (0, 0)
        { }

        public ArNumberDecimal(int integer, int fraction)
        {
            _Integer = integer;
            _Fraction = Math.Abs(fraction);
        }
        public ArNumberDecimal(ArNumberDecimal and)
        {
            _Integer = and._Integer;
            _Fraction = and._Fraction;
        }
        public static ArNumberDecimal Parse(string s)
            => Parse(s, NumberStyles.Number, null);
        public static ArNumberDecimal Parse(string s, IFormatProvider provider)
            => Parse(s, NumberStyles.Number, provider);
        public static ArNumberDecimal Parse(string s, NumberStyles style)
            => Parse(s, style, null);
        public static ArNumberDecimal Parse(string s, NumberStyles style, IFormatProvider provider)
        {
            ArNumberDecimal and = new ArNumberDecimal();
            if(s.Contains("."))
            {
                string[] splited = s.Split('.');
                and._Integer = int.Parse(splited[0]);
                and._Fraction = int.Parse(splited[1]);
                return and;
            }
            else
            {
                and._Integer = int.Parse(s, style, provider);
                return and;
            }
        }
            
        public static bool TryParse(string s, out ArNumberDecimal result)
            => TryParse(s, NumberStyles.Number, null, out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ArNumberDecimal result)
        {   
            try
            {
                result = Parse(s, style, provider);
                return true;
            }
            catch 
            {
                result = null;
                return false;
            }
        }
        public int CompareTo(object value)
        {
            //To Do
            return 1;
        }
        public int CompareTo(ArNumberDecimal value)
        {
            int c = _Integer.CompareTo(value._Integer);
            if (c != 0)
                return c;
            return _Fraction.CompareTo(value._Fraction;
        }
        public bool Equals(ArNumberDecimal value)
            => _Integer == value._Integer && _Fraction == value._Fraction;
        public override bool Equals(object value)
        {
            //To Do
            return false;
        }
        public override int GetHashCode()
            => _Integer.GetHashCode() ^ _Fraction.GetHashCode();
        public TypeCode GetTypeCode()
            => TypeCode.Object;
        public override string ToString()
            => ToString(null, null);
        public string ToString(IFormatProvider provider)
            => ToString(null, provider);
        public string ToString(string format)
            => ToString(format, null);
        public string ToString(string format, IFormatProvider provider)
        {
            if (_Fraction != 0)
                return $"{_Integer.ToString(format, provider)}.{_Fraction.ToString(format, provider)}";
            else
                return _Integer.ToString(format, provider);
        }
    }
}