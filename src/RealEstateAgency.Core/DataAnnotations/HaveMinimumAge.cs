using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Core.DataAnnotations
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
            if (value == null)
            {
                return false;
            }

            if (value.GetType() == typeof(DateTime))
            {
                var birthDate = (DateTime)value;

                if (birthDate == DateTime.MinValue)
                {
                    return false;
                }


                return birthDate <= DateTime.Now.AddYears(-_age);
            }

            return false;
        }
    }
}
