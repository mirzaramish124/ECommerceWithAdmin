using AutoMapper;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using ECommerceSiteWithAPIs.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceSiteWithAPIs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCatController : Controller
    {
        private readonly ICategoryRepository _category;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;
        public SubCatController(ICategoryRepository category, IMapper mapper, IWebHostEnvironment webHost)
        {
            _webHost = webHost;
            _mapper = mapper;
            _category = category;
        }
        public async Task<IActionResult> Index()
        {
            var objList = await _category.GetSubCats();
            var subCats = _mapper.Map<List<CategoryDto>>(objList);
            return View(subCats);
        }
        public async Task<IActionResult> Upsert(long id)
        {
            CategoryDto category = new();
            if (id > 0)
            {
                var cat = await _category.GetCatById(id);
                category = _mapper.Map<CategoryDto>(cat);
            }
            else
            {
                long orderBy = await _category.GetSubCatCount() + 1;
                category.Order = orderBy;
            }
            ViewBag.Categories = await GetCategorySelectList();
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(CategoryDto model, IFormFile file)
        {
            //(bool success, bool isExist) result = (false, true);
            bool isSuccess = false;
            Category cat = _mapper.Map<Category>(model);
            if (model.Id > 0)
            {
                bool isExist = await _category.IsSubCatExist(model?.Name, model.Id);
                if (!isExist)
                {
                    if (file != null)
                    {
                        string imageUrl = InsertImage(file, model?.Image);
                        cat.Image = imageUrl;
                    }
                    isSuccess = await _category.UpdateCat(cat);
                }
            }
            else
            {
                bool isExist = await _category.IsSubCatExist(model?.Name, model.Id);
                if (!isExist)
                {
                    if (file != null)
                    {
                        string imageUrl = InsertImage(file, "");
                        cat.Image = imageUrl;
                    }
                    isSuccess = await _category.CreateCat(cat);
                }
            }
            if (isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = await GetCategorySelectList();
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
        public async Task<SelectList> GetCategorySelectList()
        {
            IEnumerable<Category> cats = await _category.GetCatsSelectList();
            return new SelectList(cats, "Id", "Name");
        }
    }
}
