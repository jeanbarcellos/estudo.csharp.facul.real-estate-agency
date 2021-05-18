using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Interfaces
{
    public interface ILandAppService
    {
        Task<IEnumerable<LandViewModel>> GetAll();
        Task<LandViewModel> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Task<Guid> Add(LandViewModel landViewModel);
        Task Update(LandViewModel landViewModel);
        Task Delete(LandViewModel landViewModel);
        Task Delete(Guid id);
    }
}
