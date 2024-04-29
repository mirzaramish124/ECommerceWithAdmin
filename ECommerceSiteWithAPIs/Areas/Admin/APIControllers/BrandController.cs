using AutoMapper;
using ECommerce.Entities.Admin.Brand;
using ECommerce.Services.Admin.IServices;
using ECommerceSiteWithAPIs.Models.ClientModels;
using ECommerceSiteWithAPIs.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Net;

namespace ECommerceSiteWithAPIs.Areas.Admin.APIControllers
{
    [Route("api/ABrand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrand _brand;
        private IMapper _mapper;
        public BrandController(IBrand brand,IMapper mapper)
        {
            _brand = brand;
            _mapper = mapper;
        }
        [HttpGet("Brands")]
        public IActionResult GetBrands()
        {
            string message = "";
            var resultData = _brand.GetBrands();
            if (resultData == null)
            {
                message = "Brands aren't found";
                return BadRequest(new APIResponse(true, true, message, HttpStatusCode.NotFound, null));
            }
            List<BrandDto> objList = _mapper.Map<List<BrandDto>>(resultData);
            return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, objList));
        }
        [HttpGet("Brand")]
        public IActionResult GetBrandById(long id)
        {
            string message = "";
            var resultData = _brand.GetBrandById(id);
            if (resultData == null)
            {
                message = "Brands aren't found";
                return BadRequest(new APIResponse(false, true, message, HttpStatusCode.NotFound, null));
            }
            BrandDto obj = _mapper.Map<BrandDto>(resultData);
            return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, resultData));
        }
        [HttpPost("Brand")]
        public IActionResult InsertBrand(BrandDto model)
        {
            string message = "";
            bool error = true;
            TB_BRANDS obj = _mapper.Map<TB_BRANDS>(model);
            message = _brand.CreateBrand(obj, out error);
            if (error)
            {
                return BadRequest(new APIResponse(false, true, message, HttpStatusCode.NotFound, null));
            }
            return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, null));
        }
        [HttpPut("Brand")]
        public IActionResult UpdateBrand([FromBody] BrandDto model)
        {
            string message = "";
            bool error = true;
            TB_BRANDS obj = _mapper.Map<TB_BRANDS>(model);
            message = _brand.UpdateBrand(obj, out error);
            if (error)
            {
                return BadRequest(new APIResponse(false, true, message, HttpStatusCode.NotFound, null));
            }
            return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, null));
        }
        [HttpDelete("Brand")]
        public IActionResult DeleteBrand(long id)
        {
            string message = "";
            bool error = true;
            message = _brand.DeleteBrand(id, out error);
            if (error)
            {
                return BadRequest(new APIResponse(false, true, message, HttpStatusCode.NotFound, null));
            }
            return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, null));
        }
    }
}
