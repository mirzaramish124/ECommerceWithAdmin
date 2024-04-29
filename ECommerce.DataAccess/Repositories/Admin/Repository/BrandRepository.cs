using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Repositories.Admin.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly DatabaseContext _db;
        public BrandRepository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<List<Brand>> GetBrands()
        {
            return await _db.Brands.ToListAsync();
        }

        public async Task<Brand> GetBrandById(long Id)
        {
            return await _db.Brands.FirstOrDefaultAsync(x => x.Id == Id);
        }

        //public async Task<(bool Success,bool IsExist)> CreateBrand(Brand obj)
        public async Task<bool> CreateBrand(Brand obj)
        {
            bool success = false;
            //bool isExist = true;
            //var isExistBrand = await _db.Brands.FirstOrDefaultAsync(x => x.Name.ToLower() == obj.Name.ToLower());
            //if (isExistBrand is null)
            //{
                obj.Create = DateTime.Now;
                obj.Modify = DateTime.Now;
                await _db.Brands.AddAsync(obj);
                await _db.SaveChangesAsync();
                success = true;
                //isExist = false;
            //}
            return success;
        }

        //public async Task<(bool Success, bool IsExist)> UpdateBrand(Brand obj)
        public async Task<bool> UpdateBrand(Brand obj)
        {
            bool success = false;
            //bool isExist = true;
            //var isExistBrand = await _db.Brands.FirstOrDefaultAsync(x => x.Name.ToLower() == obj.Name.ToLower() && x.Id != obj.Id);
            //if (isExistBrand is null)
            //{

            //}
            var brand = await _db.Brands.FirstOrDefaultAsync(x => x.Id == obj.Id);
            if (brand != null)
            {
                brand.Name = obj.Name;
                if (!string.IsNullOrEmpty(brand.Name))
                {
                    brand.Image = obj.Image;
                }
                brand.Description = obj.Description;
                brand.Status = obj.Status;
                brand.Order = obj.Order;
                brand.Modify = DateTime.Now;
                brand.ModifyUser = obj.ModifyUser;
                _db.Brands.Update(brand);
                await _db.SaveChangesAsync();
                success = true;
                //isExist = false;
            }
            return success;
        }

        public async Task DeleteBrand(long Id)
        {
            _db.Brands.Remove(_db.Brands?.FirstOrDefault(x => x.Id == Id));
            await _db.SaveChangesAsync();
        }

        public async Task<bool> IsExistBrand(string Name,long Id)
        {
            bool isExistBrand = false;
            if(Id > 0)
            {
                var brand = await _db.Brands.FirstOrDefaultAsync(x => x.Name.ToUpper() == Name.ToUpper() && x.Id != Id);
                if (brand != null)
                {
                    isExistBrand = true;
                }
            }
            else
            {
                var brand = await _db.Brands.FirstOrDefaultAsync(x => x.Name.ToUpper() == Name.ToUpper());
                if (brand != null)
                {
                    isExistBrand = true;
                }
            }
            
            return isExistBrand;
        }

        public async Task<long> GetBrandsCount()
        {
            return await _db.Brands.CountAsync();
        }
    }
}
