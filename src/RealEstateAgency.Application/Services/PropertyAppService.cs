using AutoMapper;
using RealEstateAgency.Application.Interfaces;
using RealEstateAgency.Application.ViewModel;
using RealEstateAgency.Domain.Entities;
using RealEstateAgency.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Services
{
    public class PropertyAppService : IPropertyAppService
    {
        private readonly IMapper _mapper;
        private readonly IPropertyRepository _propertyRepository;

        public PropertyAppService(IMapper mapper, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<PropertyViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<PropertyViewModel>>(await _propertyRepository.GetAll());
        }

        public async Task<PropertyViewModel> GetById(Guid id)
        {
            return _mapper.Map<PropertyViewModel>(await _propertyRepository.GetById(id));
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _propertyRepository.Exists(id);
        }

        public async Task<Guid> Add(PropertyViewModel propertyViewModel)
        {
            var property = _mapper.Map<Property>(propertyViewModel);

            _propertyRepository.Insert(property);

            await _propertyRepository.UnitOfWork.Commit();

            return property.Id;
        }

        public async Task Update(PropertyViewModel propertyViewModel)
        {
            var property = _mapper.Map<Property>(propertyViewModel);

            _propertyRepository.Update(property);

            await _propertyRepository.UnitOfWork.Commit();
        }

        public async Task Delete(PropertyViewModel propertyViewModel)
        {
            var property = _mapper.Map<Property>(propertyViewModel);

            _propertyRepository.Delete(property);

            await _propertyRepository.UnitOfWork.Commit();
        }

        public async Task Delete(Guid id)
        {
            _propertyRepository.Delete(id);

            await _propertyRepository.UnitOfWork.Commit();
        }
    }
}
