using AutoMapper;
using ECommerce.Entities.Admin;
using ECommerce.Services.Admin.IServices;
using ECommerceSiteWithAPIs.Models.ClientModels;
using ECommerceSiteWithAPIs.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceSiteWithAPIs.Areas.Admin.APIControllers
{
    [Route("api/ACategory")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _cat;
        private IMapper _mapper;
        public CategoryController(ICategory cat, IMapper mapper)
        {
            _cat = cat;
            _mapper = mapper;
        }
        [HttpGet("Categories")]
        public IActionResult GetCategories()
        {
            string message = "";
            var resultData = _cat.GetCats();
            if (resultData == null)
            {
                message = "Categories aren't found";
                return BadRequest(new APIResponse(true, true, message, HttpStatusCode.NotFound, null));
            }
            List<CategoryDto> objList = _mapper.Map<List<CategoryDto>>(resultData);
            return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, objList));
        }
        [HttpGet("Category")]
        public IActionResult GetCategoryById(long id)
        {
            string message = "";
            var resultData = _cat.GetCatById(id);
            if (resultData == null)
            {
                message = "Category aren't found";
                return BadRequest(new APIResponse(false, true, message, HttpStatusCode.NotFound, null));
            }
            CategoryDto obj = _mapper.Map<CategoryDto>(resultData);
            return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, resultData));
        }
        [HttpPost("Category")]
        public IActionResult InsertCategory(CategoryDto model)
        {
            string message = "";
            bool error = true;
            TB_CATEGORY obj = _mapper.Map<TB_CATEGORY>(model);
            message = _cat.CreateCat(obj, out error);
            if (error)
            {
                return BadRequest(new APIResponse(false, true, message, HttpStatusCode.NotFound, null));
            }
            return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, null));
        }
        [HttpPut("Category")]
        public IActionResult UpdateCategory(CategoryDto model)
        {
            string message = "";
            bool error = true;
            TB_CATEGORY obj = _mapper.Map<TB_CATEGORY>(model);
            message = _cat.UpdateCat(obj, out error);
            if (error)
            {
                return BadRequest(new APIResponse(false, true, message, HttpStatusCode.NotFound, null));
            }
            return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, null));
        }
        [HttpDelete("Category")]
        public IActionResult DeleteUpdate(long id)
        {
            string message = "";
            bool error = true;
            message = _cat.DeleteCat(id, out error);
            if (error)
            {
                return BadRequest(new APIResponse(false, true, message, HttpStatusCode.NotFound, null));
            }
            return Ok(new APIResponse(true, false, message, HttpStatusCode.OK, null));
        }
    }
}
