using System.Collections.Generic;

namespace RealEstateAgency.Service.Api.ViewModels
{
    public class ErrorResultViewModel
    {
        protected bool Success = false;
        public string Message { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
