using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Service
{
    public interface IHouseAppService
    {
        Task<IEnumerable<HouseViewModel>> GetAll();
        Task<HouseViewModel> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Task<Guid> Add(HouseViewModel houseViewModel);
        Task Update(HouseViewModel houseViewModel);
        Task Delete(HouseViewModel houseViewModel);
        Task Delete(Guid id);
    }
}
