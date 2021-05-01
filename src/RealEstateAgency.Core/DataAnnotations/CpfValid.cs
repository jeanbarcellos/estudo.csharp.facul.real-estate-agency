using RealEstateAgency.Core.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class CpfValid : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputValue = value as string;
            return CpfValidator.IsValid(inputValue);
        }
    }
}
