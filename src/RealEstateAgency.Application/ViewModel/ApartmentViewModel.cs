using System.ComponentModel.DataAnnotations;

namespace RealEstateAgency.Application.ViewModel
{
    public class ApartmentViewModel : PropertyViewModel
    {
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public int NumberOfBedrooms { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public int NumberOfBathrooms { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public int NumberOfGarage { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public bool HasElevator { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public bool HasFurtine { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Description { get; set; }
    }
}
