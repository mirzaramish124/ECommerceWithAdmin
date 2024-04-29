using AutoMapper;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerceSiteWithAPIs.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceSiteWithAPIs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StockController : Controller
    {
        private readonly IStockRepository _stock;
        private IMapper _mapper;
        public StockController(IStockRepository stock, IMapper mapper)
        {
            _stock = stock;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Upsert()
        {
            var stock = new StockDto();
            ViewBag.ProList = await GetProSelectList();
            return View(stock);
        }
        [HttpPost]
        public IActionResult SaveTempStock()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetTempStock()
        {
            var stockList = await _stock.GetTempStock(1);
            return Json(stockList);
        }
        public async Task<SelectList> GetProSelectList()
        {
            var tb_Pros = await _stock.GetProducts();
            var pros = _mapper.Map<List<ProductDto>>(tb_Pros);

            //List<CategoryDto> subcats = new List<CategoryDto>();
            return new SelectList(pros, "Id", "Name");
        }

    }
}
