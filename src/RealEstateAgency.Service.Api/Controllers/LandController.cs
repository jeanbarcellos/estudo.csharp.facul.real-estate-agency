using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Application.Interfaces;
using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Service.Api.Controllers
{
    [Route("api/land")]
    public class LandController : ApiController
    {
        private readonly ILandAppService _landAppService;

        public LandController(ILandAppService landAppService)
        {
            _landAppService = landAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<LandViewModel>> Index()
        {
            return await _landAppService.GetAll();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Show(Guid id)
        {
            var result = await _landAppService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] LandViewModel landViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            landViewModel.Id = await _landAppService.Add(landViewModel);

            return CreatedAtAction(nameof(Show), new { id = landViewModel.Id }, landViewModel);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] LandViewModel landViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            if (landViewModel == null || id == Guid.Empty || id != landViewModel.Id)
            {
                return NotFound();
            }

            var result = await _landAppService.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            await _landAppService.Update(landViewModel);

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

            var result = await _landAppService.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            await _landAppService.Delete(id);

            return Ok();
        }

    }
}
