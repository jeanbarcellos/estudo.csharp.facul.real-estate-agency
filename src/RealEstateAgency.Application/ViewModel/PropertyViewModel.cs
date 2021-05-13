using RealEstateAgency.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Application.ViewModel
{
    public class PropertyViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        //[Range(9999.99, double.MaxValue, ErrorMessage = "O valor para {0} deve estar entre {1} e {2}.")]
        public decimal SaleValue { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public Guid ClientId { get; set; }
    }
}
