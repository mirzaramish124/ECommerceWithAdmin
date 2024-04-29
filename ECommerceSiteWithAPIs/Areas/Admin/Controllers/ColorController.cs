using AutoMapper;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using ECommerceSiteWithAPIs.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteWithAPIs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IColorRepository _color;
        private IMapper _mapper;
        public ColorController(IColorRepository color, IMapper mapper)
        {
            _color = color;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<Color> colors = await _color.GetColors();
            List<ColorDto> color = _mapper.Map<List<ColorDto>>(colors);
            return View(color);
        }
        public async Task<IActionResult> Upsert(long id)
        {
            ColorDto colordto = new();
            if (id > 0)
            {
                Color color = await _color.GetColorById(id);
                colordto = _mapper.Map<ColorDto>(color);
            }
            return View(colordto);
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(ColorDto model)
        {
            (bool success, bool isExist) result = (false, true);
            Color color = new Color();
            color = _mapper.Map<Color>(model);
            if (model.Id > 0)
            {
                result = await _color.UpdateColor(color);
            }
            else
            {
                result = await _color.CreateColor(color);
            }
            if (result.success && !result.isExist)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(long id)
        {
            await _color.DeleteColor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
