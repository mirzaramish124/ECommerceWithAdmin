using AutoMapper;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using ECommerceSiteWithAPIs.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteWithAPIs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MeasurmentController : Controller
    {
        private readonly IMeasurmentRepository _measurment;
        private IMapper _mapper;
        public MeasurmentController(IMeasurmentRepository measurment, IMapper mapper)
        {
            _measurment = measurment;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<Measurment> measurments = await _measurment.GetMeasurments();
            List<MeasurmentDto> measurmentList = new List<MeasurmentDto>();
            measurmentList = _mapper.Map<List<MeasurmentDto>>(measurments);
            return View(measurmentList);
        }
        public async Task<IActionResult> Upsert(long id)
        {
            MeasurmentDto measurment = new();
            if (id > 0)
            {
                Measurment measurments = new();
                measurments = await _measurment.GetMeasurmentById(id);
                measurment = _mapper.Map<MeasurmentDto>(measurments);
            }
            return View(measurment);
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(MeasurmentDto model)
        {
            bool success = false;
            (bool success, bool isExist) result = (false, true);
            Measurment measurment = new();
            measurment = _mapper.Map<Measurment>(model);
            if (model.Id > 0)
            {
                result = await _measurment.UpdateMeasurment(measurment);
            }
            else
            {
                result = await _measurment.CreateMeasurment(measurment);
            }
            if (result.success && !result.isExist)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Delete(long id)
        {
            _measurment.DeleteMeasurment(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
