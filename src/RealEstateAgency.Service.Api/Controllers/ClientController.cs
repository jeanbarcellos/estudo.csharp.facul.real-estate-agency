using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Application.Service;
using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Service.Api.Controllers
{

    [Route("api/client")]
    public class ClientController : ApiController
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
        public async Task<IActionResult> Show(Guid id)
        {
            var result = await _clientAppService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] ClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            clientViewModel.Id = await _clientAppService.Add(clientViewModel);

            return CreatedAtAction(nameof(Show), new { id = clientViewModel.Id }, clientViewModel);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            if (clientViewModel == null || id == Guid.Empty || id != clientViewModel.Id)
            {
                return NotFound();
            }

            var result = await _clientAppService.Exists(id);

            if (!result)
            {
                return NotFound();
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

            var result = await _clientAppService.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            await _clientAppService.Delete(id);

            return Ok();
        }

    }
}
