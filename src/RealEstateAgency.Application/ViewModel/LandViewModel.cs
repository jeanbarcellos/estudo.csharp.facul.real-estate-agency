using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Application.ViewModel
{
    public class LandViewModel : PropertyViewModel
    {
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public bool OnACorner { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public decimal Width { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public decimal Height { get; set; }
    }
}
