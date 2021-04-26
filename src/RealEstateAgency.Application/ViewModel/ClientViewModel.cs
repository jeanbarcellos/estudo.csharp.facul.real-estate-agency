using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Application.ViewModel
{
    public class ClientViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string SocialNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime Birthday { get; set; }
    }
}
