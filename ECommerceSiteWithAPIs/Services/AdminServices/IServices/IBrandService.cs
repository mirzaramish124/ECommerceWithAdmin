using ECommerceSiteWithAPIs.Models.Dtos;
using ECommerceSiteWithAPIs.Services.GenericsServices.IServices;
using System.Diagnostics;

namespace ECommerceSiteWithAPIs.Services.AdminServices.IServices
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetBrands();
        Task<BrandDto> GetBrandById(long id);
        Task<bool> InsertBrand(BrandDto model);
        Task<bool> UpdateBrand(BrandDto model);
        Task<bool> DeleteBrand(long id);
    }
}
