using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ECommerce.DataAccess.Repositories.Admin.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _db;
        public ProductRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Product> GetProductById(long id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id && x.Status == "0");
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _db.Products.Include(x => x.Brand).Include(x => x.Category).Include(x => x.SubCategory).Where(x => x.Status == "0").ToListAsync();
        }

        public async Task<(bool Success, bool IsExist)> CreateProduct(Product model)
        {
            bool success = false;
            bool isExist = true;
            var isExistPro = await _db.Products.FirstOrDefaultAsync(x => x.Name.ToLower() == model.Name.ToLower());
            if (isExistPro is null)
            {
                model.Create = DateTime.Now;
                model.Modify = DateTime.Now;
                await _db.Products.AddAsync(model);
                await _db.SaveChangesAsync();
                success = true;
                isExist = false;
            }
            return (success, isExist);
        }

        public async Task<(bool Success, bool IsExist)> UpdateProduct(Product model)
        {
            bool success = false;
            bool isExist = true;
            var isExistPro = await _db.Products.FirstOrDefaultAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id);
            if (isExistPro is null)
            {
                var pro = await _db.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (pro != null)
                {
                    pro.BrandId = model.BrandId;
                    pro.CategoryId = model.CategoryId;
                    pro.SubCategoryId = model.SubCategoryId;
                    pro.MeasurmentTypeId = model.MeasurmentTypeId;
                    pro.Name = model.Name;
                    pro.Brief = model.Brief;
                    pro.Code = model.Code;
                    pro.RefNo = model.RefNo;
                    pro.CanWrite = model.CanWrite;
                    pro.WritePrice = model.WritePrice;
                    pro.Status = model.Status;
                    pro.Create = DateTime.Now;
                    pro.Modify = DateTime.Now;
                    pro.CreateUser = model.CreateUser;
                    pro.ModifyUser = model.ModifyUser;
                    _db.Products.Update(pro);
                    await _db.SaveChangesAsync();
                    success = true;
                    isExist = false;
                }
            }
            return (success, isExist);
        }

        public async Task DeleteProduct(long id)
        {
            _db.Products.Remove(await _db.Products?.FirstOrDefaultAsync(x => x.Id == id));
            await _db.SaveChangesAsync();
        }

        public async Task<long> GetProductCount()
        {
            return await _db.Products.CountAsync();
        }

        public async Task<List<Brand>> GetBrands()
        {
            return await _db.Brands.Where(x => x.Status == "0").Select(x => new Brand()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task<List<Category>> GetCats()
        {
            return await _db.Categories.Where(x => x.ParentId == 0 && x.Status == "0").Select(x => new Category()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task<List<Category>> GetSubCats()
        {
            return await _db.Categories.Where(x => x.ParentId > 0 && x.Status == "0").Select(x => new Category()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task<List<Category>> GetSubCatsByCatId(long id)
        {
            return await _db.Categories.Where(x => x.ParentId == id && x.Status == "0").Select(x => new Category()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task<List<MeasurmentType>> GetMeasurmentTypes()
        {
            return await _db.MeasurmentTypes.Where(x => x.Status == "0").Select(x => new MeasurmentType()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
