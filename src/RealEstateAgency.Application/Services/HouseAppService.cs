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
    public class HouseAppService : IHouseAppService
    {
        private readonly IMapper _mapper;
        private readonly IHouseRepository _houseRepository;

        public HouseAppService(IMapper mapper, IHouseRepository houseRepository)
        {
            _mapper = mapper;
            _houseRepository = houseRepository;
        }

        public async Task<IEnumerable<HouseViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<HouseViewModel>>(await _houseRepository.GetAll());
        }

        public async Task<HouseViewModel> GetById(Guid id)
        {
            return _mapper.Map<HouseViewModel>(await _houseRepository.GetById(id));
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _houseRepository.Exists(id);
        }

        public async Task<Guid> Add(HouseViewModel houseViewModel)
        {
            var house = _mapper.Map<House>(houseViewModel);

            _houseRepository.Insert(house);

            await _houseRepository.UnitOfWork.Commit();

            return house.Id;
        }

        public async Task Update(HouseViewModel houseViewModel)
        {
            var house = _mapper.Map<House>(houseViewModel);

            _houseRepository.Update(house);

            await _houseRepository.UnitOfWork.Commit();
        }

        public async Task Delete(HouseViewModel houseViewModel)
        {
            var house = _mapper.Map<House>(houseViewModel);

            _houseRepository.Delete(house);

            await _houseRepository.UnitOfWork.Commit();
        }

        public async Task Delete(Guid id)
        {
            _houseRepository.Delete(id);

            await _houseRepository.UnitOfWork.Commit();
        }
    }
}
