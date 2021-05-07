using System.Collections.Generic;

namespace RealEstateAgency.Service.Api.ViewModels
{
    public class ValidationResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>> Errors { get; private set; }

        public ValidationResultViewModel()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public ValidationResultViewModel AddError(string key, string value)
        {
            var exists = Errors.ContainsKey(key);

            if (exists)
            {
                Errors[key].Add(value);
            }
            else
            {
                Errors[key] = new List<string>
                {
                    value
                };
            }


            return this;
        }

        internal void AddError(string key, List<string> errors)
        {
            Errors[key] = errors;
        }
    }
}
