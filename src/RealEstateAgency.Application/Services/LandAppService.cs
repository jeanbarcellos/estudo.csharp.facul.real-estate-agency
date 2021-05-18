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
    public class LandAppService : ILandAppService
    {
        private readonly IMapper _mapper;
        private readonly ILandRepository _landRepository;

        public LandAppService(IMapper mapper, ILandRepository landRepository)
        {
            _mapper = mapper;
            _landRepository = landRepository;
        }

        public async Task<IEnumerable<LandViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<LandViewModel>>(await _landRepository.GetAll());
        }

        public async Task<LandViewModel> GetById(Guid id)
        {
            return _mapper.Map<LandViewModel>(await _landRepository.GetById(id));
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _landRepository.Exists(id);
        }

        public async Task<Guid> Add(LandViewModel landViewModel)
        {
            var land = _mapper.Map<Land>(landViewModel);

            _landRepository.Insert(land);

            await _landRepository.UnitOfWork.Commit();

            return land.Id;
        }

        public async Task Update(LandViewModel landViewModel)
        {
            var land = _mapper.Map<Land>(landViewModel);

            _landRepository.Update(land);

            await _landRepository.UnitOfWork.Commit();
        }

        public async Task Delete(LandViewModel landViewModel)
        {
            var land = _mapper.Map<Land>(landViewModel);

            _landRepository.Delete(land);

            await _landRepository.UnitOfWork.Commit();
        }

        public async Task Delete(Guid id)
        {
            _landRepository.Delete(id);

            await _landRepository.UnitOfWork.Commit();
        }
    }
}
