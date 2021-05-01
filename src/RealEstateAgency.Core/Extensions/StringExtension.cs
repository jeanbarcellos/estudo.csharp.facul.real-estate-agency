using System.Linq;

namespace RealEstateAgency.Core.Extensions
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

        public static string ToSnakeCase(this string str)
        {
            return string.Concat(
                         str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString().ToLower() : x.ToString().ToLower())
                     );
        }
    }
}
