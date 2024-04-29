using ECommerceSiteWithAPIs.Models.ClientModels;
using ECommerceSiteWithAPIs.Models.Dtos;
using ECommerceSiteWithAPIs.Services.AdminServices.IServices;
using ECommerceSiteWithAPIs.Services.GenericsServices.IServices;
using Newtonsoft.Json;
using NuGet.Packaging;
using static ECommerceSiteWithAPIs.Utility.SD;

namespace ECommerceSiteWithAPIs.Services.AdminServices.Services
{
    public class CatService : ICatService
    {
        private readonly IClientService _clientService;
        public CatService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IEnumerable<CategoryDto>> GetCats()
        {
            List<CategoryDto>? objList = new();
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                Url = $"{APIBaseUrl}api/ACategory/Categories",
                APIType = APITypes.Get,
            });
            if (response.Data != null && response.Success)
            {
                objList = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Data));
            }
            return objList;
        }
        public async Task<CategoryDto> GetCatById(long id)
        {
            CategoryDto? objList = new();
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                Url = $"{APIBaseUrl}api/ACategory/Category?id={id}",
                APIType = APITypes.Get,
            });
            if (response.Data != null && response.Success)
            {
                objList = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(response.Data));
            }
            return objList;
        }
        public async Task<bool> InsertCat(CategoryDto model)
        {
            bool isSuccess = false;
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                Url = $"{APIBaseUrl}api/ACategory/Category",
                APIType = APITypes.Post,
                Data = model
            });
            if (response.Success)
            {
                isSuccess = true;
            }
            return isSuccess;
        }
        public async Task<bool> UpdateCat(CategoryDto model)
        {
            bool isSuccess = false;
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                Url = $"{APIBaseUrl}api/ACategory/Category",
                APIType = APITypes.Put,
                Data = model
            });
            if (response.Success)
            {
                isSuccess = true;
            }
            return isSuccess;
        }
        public async Task<bool> DeleteCat(long id)
        {
            bool isSuccess = false;
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                Url = $"{APIBaseUrl}api/ACategory/Category?id={id}",
                APIType = APITypes.Delete,
            });
            if (response.Success)
            {
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
