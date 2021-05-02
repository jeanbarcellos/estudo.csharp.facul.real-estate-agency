using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RealEstateAgency.Application.Service;
using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] ClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientAppService.Add(clientViewModel);

            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClientViewModel clientViewModel)
        {
            if (clientViewModel == null || id == Guid.Empty || id != clientViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientAppService.Update(clientViewModel);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var result = await _clientAppService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            await _clientAppService.Delete(id);

            return Ok(result);
        }

    }
}
