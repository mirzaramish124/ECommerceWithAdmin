using AutoMapper;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using ECommerceSiteWithAPIs.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteWithAPIs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;
        private readonly IWebHostEnvironment _webHost;
        private IMapper _mapper;
        public CategoryController(ICategoryRepository category, IWebHostEnvironment webHost, IMapper mapper)
        {
            _webHost = webHost;
            _category = category;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> cats = await _category.GetCats();
            var catList = _mapper.Map<List<CategoryDto>>(cats);
            return View(catList);
        }
        public async Task<IActionResult> Upsert(long id)
        {
            CategoryDto category = new();
            if (id > 0)
            {
                Category cat = await _category.GetCatById(id);
                category = _mapper.Map<CategoryDto>(cat);
            }
            else
            {
                long orderBy = await _category.GetCatCounts() + 1;
                category.Order = orderBy;
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(CategoryDto model, IFormFile file)
        {
            bool success = false;
            //(bool success, bool isExist) result = (false, true);
            Category cat = _mapper.Map<Category>(model);
            if (model.Id > 0)
            {
                bool isExist = await _category.IsCatExist(model.Name, model.Id);
                if (!isExist)
                {
                    if (file != null)
                    {
                        string imageUrl = InsertImage(file, model.Image);
                        cat.Image = imageUrl;
                    }
                    success = await _category.UpdateCat(cat);
                }
            }
            else
            {
                bool isExist = await _category.IsCatExist(model.Name, model.Id);
                if (!isExist)
                {
                    if (file != null)
                    {
                        string imageUrl = InsertImage(file, "");
                        cat.Image = imageUrl;
                    }
                    success = await _category.CreateCat(cat);
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
            await _category.DeleteCat(id);
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
            string path = Path.Combine(rootPath, @"admin\images\categories");
            string imagePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(imagePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            imagePath = @"\admin\images\categories\" + fileName;
            return imagePath;
        }
    }
}
