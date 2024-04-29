using AutoMapper;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using ECommerceSiteWithAPIs.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteWithAPIs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brand;
        private IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;
        public BrandController(IBrandRepository brand, IMapper mapper, IWebHostEnvironment webHost)
        {
            _brand = brand;
            _mapper = mapper;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            List<Brand> brands = await _brand.GetBrands();
            List<BrandDto> brandList = _mapper.Map<List<BrandDto>>(brands);
            return View(brandList);
        }
        public async Task<IActionResult> Upsert(long id)
        {
            BrandDto brand = new();
            if (id > 0)
            {
                Brand obj = await _brand.GetBrandById(id);
                brand = _mapper.Map<BrandDto>(obj);
            }
            else
            {
                long orderBy = await _brand.GetBrandsCount() + 1;
                brand.Order = orderBy.ToString();
            }
            return View(brand);
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(BrandDto model, IFormFile file)
        {
            bool success = false;
            //(bool success, bool isExist) result = (false,true);
            var brand = _mapper.Map<Brand>(model);
            if (model.Id > 0)
            {
                var isExist = await _brand.IsExistBrand(model.Name, model.Id);
                if (!isExist)
                {
                    if (file != null)
                    {
                        string imageUrl = InsertImage(file, model.Image);
                        brand.Image = imageUrl;
                    }
                    //success = await _brand.UpdateBrand(brand);
                    success = await _brand.UpdateBrand(brand);
                }
            }
            else
            {
                var isExist = await _brand.IsExistBrand(model.Name, 0);
                if (!isExist)
                {
                    if (file != null)
                    {
                        string imageUrl = InsertImage(file, "");
                        brand.Image = imageUrl;
                    }
                    success = await _brand.CreateBrand(brand);
                    //success = true;
                }
            }
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(long id)
        {
            await _brand.DeleteBrand(id);
            return RedirectToAction(nameof(Index));
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
            string path = Path.Combine(rootPath, @"admin\images\brands");
            string imagePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(imagePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            imagePath = @"\admin\images\brands\" + fileName;
            return imagePath;
        }
    }
}
