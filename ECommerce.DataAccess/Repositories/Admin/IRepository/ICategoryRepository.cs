using ECommerce.Entities.Models;

namespace ECommerce.DataAccess.Repositories.Admin.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCats();
        Task<Category> GetCatById(long Id);
        Task<bool> IsCatExist(string Name, long Id);
        //Task<(bool Success, bool IsExist)> CreateCat(Category obj);
        Task<bool> CreateCat(Category model);
        //Task<(bool Success, bool IsExist)> UpdateCat(Category obj);
        Task<bool> UpdateCat(Category model);
        Task DeleteCat(long Id);
        Task<long> GetCatCounts();
        Task<bool> IsSubCatExist(string Name, long Id);
        Task<List<Category>> GetSubCats();
        Task<long> GetSubCatCount();
        Task<List<Category>> GetCatsSelectList();
    }
}
