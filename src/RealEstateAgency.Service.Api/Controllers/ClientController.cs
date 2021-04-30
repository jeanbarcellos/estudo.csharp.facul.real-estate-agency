using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Application.Service;
using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Service.Api.Controllers
{

    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ClientViewModel>> Index()
        {
            return await _clientAppService.GetAll();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ClientViewModel> Show(Guid id)
        {
            return await _clientAppService.GetById(id);
        }

    }
}
