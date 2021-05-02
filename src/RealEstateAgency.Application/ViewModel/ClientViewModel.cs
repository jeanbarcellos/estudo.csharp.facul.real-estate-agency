using RealEstateAgency.Core.Serialization;
using RealEstateAgency.Core.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RealEstateAgency.Application.ViewModel
{
    public class ClientViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [CpfValid(ErrorMessage = "O {0} informado é inválido.")]
        public string SocialNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(2, ErrorMessage = "O campo {0}  deve conter no máximo 2 caracteres")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve conter no mínimo 150 caracteres")]
        public string Name { get; set; }

        [JsonConverter(typeof(JsonDateConverter))]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [HaveMinimumAge(18, ErrorMessage = "O campo {0} deve conter a idade de 18 anos ou mais.")]
        public DateTime? Birthday { get; set; }
    }
}
