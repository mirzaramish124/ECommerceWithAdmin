using AutoMapper;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using ECommerceSiteWithAPIs.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceSiteWithAPIs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;
        public ProductController(IProductRepository product, IMapper mapper, IWebHostEnvironment webHost)
        {
            _webHost = webHost;
            _mapper = mapper;
            _product = product;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> objList = await _product.GetProducts();
            List<ProductDto> pros = _mapper.Map<List<ProductDto>>(objList);
            return View(pros);
        }

        public async Task<IActionResult> Upsert(long id)
        {
            ProductDto product = new();
            if (id > 0)
            {
                Product tb_product = await _product.GetProductById(id);
                product = _mapper.Map<ProductDto>(tb_product);
                if (product.CategoryId > 0)
                {
                    ViewBag.SubCatList = await GetSubCatByIdSelectList(product.CategoryId);
                }
            }
            else
            {
                long orderBy = await _product.GetProductCount() + 1;
                product.Order = orderBy.ToString();
                ViewBag.SubCatList = await GetSubCatSelectList();
            }
            ViewBag.BrandList = await GetBrandSelectList();
            ViewBag.CatList = await GetCatSelectList();
            ViewBag.MTypesList = await GetMeasurmentTypesSelectList();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(ProductDto model, IFormFile file)
        {
            (bool success, bool isExist) result = (false, true); Product tb_product = _mapper.Map<Product>(model);
            if (model.Id > 0)
            {
                //if (file != null)
                //{
                //    string imageUrl = InsertImage(file, model.TB_IMG);
                //    model.TB_IMG = imageUrl;
                //}

                result = await _product.UpdateProduct(tb_product);
            }
            else
            {
                //if (file != null)
                //{
                //    string imageUrl = InsertImage(file, "");
                //    model.TB_IMG = imageUrl;
                //}
                result = await _product.CreateProduct(tb_product);
            }
            if (result.success && !result.isExist)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.BrandList = await GetBrandSelectList();
            ViewBag.CatList = await GetCatSelectList();
            ViewBag.SubCatList = await GetSubCatSelectList();
            ViewBag.MTypesList = await GetMeasurmentTypesSelectList();
            return View(model);
        }
        public async Task<IActionResult> Delete(long id)
        {
            await _product.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> GetSubCatsByCatId(long id)
        {
            List<Category> subCats = await _product.GetSubCatsByCatId(id);
            List<CategoryDto> subCatsDto = _mapper.Map<List<CategoryDto>>(subCats);
            return Json(new { subCats = subCatsDto });
        }
        public string InsertImage(IFormFile file, string oldImage)
        {
            string? rootPath = _webHost.WebRootPath;
            if (!string.IsNullOrEmpty(oldImage))
            {
                oldImage = Path.Combine(rootPath, @oldImage.Replace('\\', '/'));
                if (System.IO.File.Exists(oldImage))
                {
                    System.IO.File.Delete(oldImage);
                }
            }
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string path = Path.Combine(rootPath, @"admin\images\categories");
            string imagePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(imagePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            imagePath = @"\admin\images\categories\" + fileName;
            return imagePath;
        }
        public async Task<SelectList> GetBrandSelectList()
        {
            var tb_brands = await _product.GetBrands();
            var brands = _mapper.Map<List<BrandDto>>(tb_brands);
            return new SelectList(brands, "Id", "Name");
        }
        public async Task<SelectList> GetCatSelectList()
        {
            var tb_cats = await _product.GetCats();
            var cats = _mapper.Map<List<CategoryDto>>(tb_cats);
            return new SelectList(cats, "Id", "Name");
        }
        public async Task<SelectList> GetSubCatSelectList()
        {
            var tb_subcats = await _product.GetSubCats();
            var subcats = _mapper.Map<List<CategoryDto>>(tb_subcats);

            //List<CategoryDto> subcats = new List<CategoryDto>();
            return new SelectList(subcats, "Id", "Name");
        }
        public async Task<SelectList> GetSubCatByIdSelectList(long id)
        {
            var tb_subcats = await _product.GetSubCatsByCatId(id);
            var subcats = _mapper.Map<List<CategoryDto>>(tb_subcats);
            return new SelectList(subcats, "Id", "Name");
        }
        public async Task<SelectList> GetMeasurmentTypesSelectList()
        {
            var tb_measurs = await _product.GetMeasurmentTypes();
            var measurs = _mapper.Map<List<MeasurmentTypeDto>>(tb_measurs);
            return new SelectList(measurs, "Id", "Name");
        }
    }
}
