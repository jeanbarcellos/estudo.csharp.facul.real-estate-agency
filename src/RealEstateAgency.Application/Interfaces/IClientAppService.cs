using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Interfaces
{
    public interface IClientAppService
    {
        Task<IEnumerable<ClientViewModel>> GetAll();
        Task<ClientViewModel> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Task<Guid> Add(ClientViewModel clientViewModel);
        Task Update(ClientViewModel clientViewModel);
        Task Delete(ClientViewModel clientViewModel);
        Task Delete(Guid id);
    }
}
