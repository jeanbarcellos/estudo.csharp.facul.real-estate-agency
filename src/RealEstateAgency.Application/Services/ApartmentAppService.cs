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
    public class ApartmentAppService : IApartmentAppService
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentAppService(IMapper mapper, IApartmentRepository apartmentRepository)
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
        }

        public async Task<IEnumerable<ApartmentViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ApartmentViewModel>>(await _apartmentRepository.GetAll());
        }

        public async Task<ApartmentViewModel> GetById(Guid id)
        {
            return _mapper.Map<ApartmentViewModel>(await _apartmentRepository.GetById(id));
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _apartmentRepository.Exists(id);
        }

        public async Task<Guid> Add(ApartmentViewModel apartmentViewModel)
        {
            var apartment = _mapper.Map<Apartment>(apartmentViewModel);

            _apartmentRepository.Insert(apartment);

            await _apartmentRepository.UnitOfWork.Commit();

            return apartment.Id;
        }

        public async Task Update(ApartmentViewModel apartmentViewModel)
        {
            var apartment = _mapper.Map<Apartment>(apartmentViewModel);

            _apartmentRepository.Update(apartment);

            await _apartmentRepository.UnitOfWork.Commit();
        }

        public async Task Delete(ApartmentViewModel apartmentViewModel)
        {
            var apartment = _mapper.Map<Apartment>(apartmentViewModel);

            _apartmentRepository.Delete(apartment);

            await _apartmentRepository.UnitOfWork.Commit();
        }

        public async Task Delete(Guid id)
        {
            _apartmentRepository.Delete(id);

            await _apartmentRepository.UnitOfWork.Commit();
        }
    }
}
