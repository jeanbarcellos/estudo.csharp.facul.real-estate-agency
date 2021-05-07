using AutoMapper;
using RealEstateAgency.Application.ViewModel;
using RealEstateAgency.Domain.Entities;
using RealEstateAgency.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Application.Service
{
    public class ClientAppService : IClientAppService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientAppService(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ClientViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ClientViewModel>>(await _clientRepository.GetAll());
        }

        public async Task<ClientViewModel> GetById(Guid id)
        {
            return _mapper.Map<ClientViewModel>(await _clientRepository.GetById(id));
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _clientRepository.Exists(id);
        }

        public async Task<Guid> Add(ClientViewModel clientViewModel)
        {
            var client = _mapper.Map<Client>(clientViewModel);

            _clientRepository.Insert(client);

            await _clientRepository.UnitOfWork.Commit();

            return client.Id;
        }

        public async Task Update(ClientViewModel clientViewModel)
        {
            var client = _mapper.Map<Client>(clientViewModel);

            _clientRepository.Update(client);

            await _clientRepository.UnitOfWork.Commit();
        }

        public async Task Delete(ClientViewModel clientViewModel)
        {
            var client = _mapper.Map<Client>(clientViewModel);

            _clientRepository.Delete(client);

            await _clientRepository.UnitOfWork.Commit();
        }

        public async Task Delete(Guid id)
        {
            _clientRepository.Delete(id);

            await _clientRepository.UnitOfWork.Commit();
        }
    }
}
