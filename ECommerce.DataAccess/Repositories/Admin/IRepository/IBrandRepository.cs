using ECommerce.Entities.Models;

namespace ECommerce.DataAccess.Repositories.Admin.IRepository
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetBrands();
        Task<Brand> GetBrandById(long Id);
        //Task<(bool Success, bool IsExist)> CreateBrand(Brand obj);
        Task<bool> CreateBrand(Brand obj);
        //Task<(bool Success, bool IsExist)> UpdateBrand(Brand obj);
        Task<bool> UpdateBrand(Brand obj);
        Task DeleteBrand(long Id);
        Task<bool> IsExistBrand(string Name, long Id);
        Task<long> GetBrandsCount();
    }
}
