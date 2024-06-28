using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleAPI.Models;
using VehicleAPI.Services;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAll([FromBody] BrandFilterModel filter)
        {
            var result = await _brandService.ReadAll(filter);
            return Ok(result);
        }
        [HttpGet("{brandID:int}")]
        public async Task<IActionResult> Detail(int brandID)
        {
            var result = await _brandService.Read(brandID);
            return Ok(result);
        }

        [HttpGet("lov")]
        public async Task<IActionResult> GetLov()
        {
            var result = await _brandService.ReadLov();
            return Ok(result);
        }

        [HttpDelete("{brandID:int}")]
        public async Task<IActionResult> Delete(int brandID)
        {
            await _brandService.Delete(brandID);
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] BrandModel brandModel)
        {
            var result = await _brandService.CreateBrand(brandModel);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] BrandModel brandModel)
        {
            await _brandService.Update(brandModel);
            return Ok();
        }
    }
}
