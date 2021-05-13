using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Application.Service;
using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Service.Api.Controllers
{
    [Route("api/house")]
    public class HouseController : ApiController
    {
        private readonly IHouseAppService _houseAppService;

        public HouseController(IHouseAppService houseAppService)
        {
            _houseAppService = houseAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<HouseViewModel>> Index()
        {
            return await _houseAppService.GetAll();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Show(Guid id)
        {
            var result = await _houseAppService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] HouseViewModel houseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            houseViewModel.Id = await _houseAppService.Add(houseViewModel);

            return CreatedAtAction(nameof(Show), new { id = houseViewModel.Id }, houseViewModel);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] HouseViewModel houseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            if (houseViewModel == null || id == Guid.Empty || id != houseViewModel.Id)
            {
                return NotFound();
            }

            var result = await _houseAppService.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            await _houseAppService.Update(houseViewModel);

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

            var result = await _houseAppService.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            await _houseAppService.Delete(id);

            return Ok();
        }

    }
}
