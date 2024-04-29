using ECommerceSiteWithAPIs.Models.Dtos;

namespace ECommerceSiteWithAPIs.Services.AdminServices.IServices
{
    public interface ICatService
    {
        Task<IEnumerable<CategoryDto>> GetCats();
        Task<CategoryDto> GetCatById(long id);
        Task<bool> InsertCat(CategoryDto model);
        Task<bool> UpdateCat(CategoryDto model);
        Task<bool> DeleteCat(long id);
    }
}
