using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Interfaces
{
    public interface IApartmentAppService
    {
        Task<IEnumerable<ApartmentViewModel>> GetAll();
        Task<ApartmentViewModel> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Task<Guid> Add(ApartmentViewModel apartmentViewModel);
        Task Update(ApartmentViewModel apartmentViewModel);
        Task Delete(ApartmentViewModel apartmentViewModel);
        Task Delete(Guid id);
    }
}
