using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Application.Interfaces;
using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Service.Api.Controllers
{
    [Route("api/apartment")]
    public class ApartmentController : ApiController
    {
        private readonly IApartmentAppService _apartmentAppService;

        public ApartmentController(IApartmentAppService apartmentAppService)
        {
            _apartmentAppService = apartmentAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ApartmentViewModel>> Index()
        {
            return await _apartmentAppService.GetAll();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Show(Guid id)
        {
            var result = await _apartmentAppService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody] ApartmentViewModel apartmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            apartmentViewModel.Id = await _apartmentAppService.Add(apartmentViewModel);

            return CreatedAtAction(nameof(Show), new { id = apartmentViewModel.Id }, apartmentViewModel);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ApartmentViewModel apartmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return ResponseValidation(ModelState);
            }

            if (apartmentViewModel == null || id == Guid.Empty || id != apartmentViewModel.Id)
            {
                return NotFound();
            }

            var result = await _apartmentAppService.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            await _apartmentAppService.Update(apartmentViewModel);

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

            var result = await _apartmentAppService.Exists(id);

            if (!result)
            {
                return NotFound();
            }

            await _apartmentAppService.Delete(id);

            return Ok();
        }

    }
}
