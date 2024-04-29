using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Repositories.Admin.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _db;
        public CategoryRepository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<List<Category>> GetCats()
        {
            return await _db.Categories.Where(x => x.ParentId == 0).ToListAsync();
        }

        public async Task<Category> GetCatById(long Id)
        {
            return await _db.Categories.FirstOrDefaultAsync(x => x.Id == Id);
        }

        //public async Task<(bool Success, bool IsExist)> CreateCat(Category model)
        public async Task<bool> CreateCat(Category model)
        {
            bool success = false;
            //bool isExist = true;
            //var isExistCat = await _db.Categories.FirstOrDefaultAsync(x => x.Name.ToLower() == model.Name.ToLower());
            //if (isExistCat is null)
            //{
                model.Create = DateTime.Now;
                model.Modify = DateTime.Now;
                await _db.Categories.AddAsync(model);
                await _db.SaveChangesAsync();
                success = true;
                //isExist = false;
            //}
            return success;
        }

        //public async Task<(bool Success, bool IsExist)> UpdateCat(Category model)
        public async Task<bool> UpdateCat(Category model)
        {
            bool success = false;
            //bool isExist = true;
            //var isExistCat = await _db.Categories.FirstOrDefaultAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id);
            //if (isExistCat is null)
            //{
                var cat = await _db.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (cat != null)
                {
                    cat.Name = model.Name;
                    cat.Image = model.Image;
                    cat.Description = model.Description;
                    cat.ParentId = model.ParentId;
                    cat.Status = model.Status;
                    cat.Order = model.Order;
                    cat.Modify = DateTime.Now;
                    cat.ModifyUser = model.ModifyUser;
                    _db.Categories.Update(cat);
                    await _db.SaveChangesAsync();
                    success = true;
                    //isExist = false;
                }
            //}

            return success;
        }

        public async Task DeleteCat(long Id)
        {
            _db.Categories.Remove(_db.Categories?.FirstOrDefault(x => x.Id == Id));
            await _db.SaveChangesAsync();
        }


        public async Task<long> GetCatCounts()
        {
            return await _db.Categories.Where(x => x.ParentId == 0).CountAsync();
        }

        public async Task<long> GetSubCatCount()
        {
            return await _db.Categories.Where(x => x.ParentId > 0).CountAsync();
        }

        public async Task<List<Category>> GetSubCats()
        {
            return await _db.Categories.ToListAsync();
            //return await _db.Categories.Where(x => x.ParentId > 0).ToListAsync();
        }

        public async Task<bool> IsCatExist(string Name, long Id)
        {
            bool isExist = false;
            if (Id > 0)
            {
                var cat = await _db.Categories.FirstOrDefaultAsync(x => x.Name.ToUpper() == Name.ToUpper() && x.Id != Id && x.ParentId == 0);
                if (isExist)
                {
                    isExist = true;
                }
            }
            else
            {
                var cat = await _db.Categories.FirstOrDefaultAsync(x => x.Name.ToUpper() == Name.ToUpper() && x.ParentId == 0);
                if (isExist)
                {
                    isExist = true;
                }
            }
            return isExist;
        }

        public async Task<bool> IsSubCatExist(string Name, long Id)
        {
            bool isExist = false;
            if (Id > 0)
            {
                var cat = await _db.Categories.FirstOrDefaultAsync(x => x.Name.ToUpper() == Name.ToUpper() && x.Id != Id && x.ParentId > 0);
                if (isExist)
                {
                    isExist = true;
                }
            }
            else
            {
                var cat = await _db.Categories.FirstOrDefaultAsync(x => x.Name.ToUpper() == Name.ToUpper() && x.ParentId > 0);
                if (isExist)
                {
                    isExist = true;
                }
            }
            return isExist;
        }
        public async Task<List<Category>> GetCatsSelectList()
        {
            return await _db.Categories.Where(x => x.ParentId == 0 && x.Status == "0").Select(x => new Category()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }

    }
}
