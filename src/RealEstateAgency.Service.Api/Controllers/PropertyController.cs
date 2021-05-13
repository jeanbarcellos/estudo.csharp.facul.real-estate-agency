using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Application.Interfaces;
using RealEstateAgency.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Service.Api.Controllers
{
    [Route("api/property")]
    public class PropertyController : ApiController
    {
        private readonly IPropertyAppService _houseAppService;

        public PropertyController(IPropertyAppService houseAppService)
        {
            _houseAppService = houseAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PropertyViewModel>> Index()
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
    }
}
