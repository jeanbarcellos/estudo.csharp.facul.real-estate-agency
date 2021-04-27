using RealEstateAgency.Core.Validations.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Application.ViewModel
{
    public class ClientViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [CpfValid(ErrorMessage = "O CPF informado é inválido.")]
        public string SocialNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(2, ErrorMessage = "Este campo deve conter no máximo 2 caracteres")]
        [MaxLength(150, ErrorMessage = "Este campo deve conter no mínimo 150 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [HaveMinimumAge(18, ErrorMessage = "O cliente deve ter 18 anos ou mais.")]
        public DateTime Birthday { get; set; }
    }
}
