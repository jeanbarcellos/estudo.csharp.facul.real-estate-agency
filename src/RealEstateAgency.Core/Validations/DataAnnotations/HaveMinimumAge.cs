using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Core.Validations.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class HaveMinimumAge : ValidationAttribute
    {
        private int _age;

        public HaveMinimumAge(int age)
        {
            _age = age;
        }

        public override bool IsValid(object value)
        {
            var birthDate = (DateTime) value;
            return birthDate <= DateTime.Now.AddYears(-_age);
        }
    }
}
