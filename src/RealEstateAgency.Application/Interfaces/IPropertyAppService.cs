using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Interfaces
{
    public interface IPropertyAppService
    {
        Task<IEnumerable<PropertyViewModel>> GetAll();
        Task<PropertyViewModel> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Task<Guid> Add(PropertyViewModel propertyViewModel);
        Task Update(PropertyViewModel propertyViewModel);
        Task Delete(PropertyViewModel propertyViewModel);
        Task Delete(Guid id);
    }
}
