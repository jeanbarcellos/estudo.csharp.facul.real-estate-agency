using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MinimumDate : ValidationAttribute
    {
        private DateTime _date;

        public MinimumDate(DateTime date)
        {
            _date = date;
        }

        public override bool IsValid(object value)
        {
            return _date <= (DateTime) value;
        }
    }
}
