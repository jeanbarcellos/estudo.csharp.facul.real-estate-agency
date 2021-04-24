using System.Linq;

namespace RealEstateAgency.Core.Extensions
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
