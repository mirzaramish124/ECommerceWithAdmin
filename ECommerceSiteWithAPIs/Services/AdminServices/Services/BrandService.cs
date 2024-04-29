using ECommerceSiteWithAPIs.Models.ClientModels;
using ECommerceSiteWithAPIs.Models.Dtos;
using ECommerceSiteWithAPIs.Services.AdminServices.IServices;
using ECommerceSiteWithAPIs.Services.GenericsServices.IServices;
using Newtonsoft.Json;
using NuGet.Packaging;
using static ECommerceSiteWithAPIs.Utility.SD;

namespace ECommerceSiteWithAPIs.Services.AdminServices.Services
{
    public class BrandService : IBrandService
    {
        private readonly IClientService _clientService;
        public BrandService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IEnumerable<BrandDto>> GetBrands()
        {
            List<BrandDto>? objList = new();
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                Url = $"{APIBaseUrl}api/ABrand/Brands",
                APIType = APITypes.Get,
            });
            if (response.Data != null && response.Success)
            {
                objList = JsonConvert.DeserializeObject<List<BrandDto>>(Convert.ToString(response.Data));
            }
            return objList;
        }
        public async Task<BrandDto> GetBrandById(long id)
        {
            BrandDto? objList = new();
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                Url = $"{APIBaseUrl}api/ABrand/Brand?id={id}",
                APIType = APITypes.Get,
            });
            if (response.Data != null && response.Success)
            {
                objList = JsonConvert.DeserializeObject<BrandDto>(Convert.ToString(response.Data));
            }
            return objList;
        }
        public async Task<bool> InsertBrand(BrandDto model)
        {
            bool isSuccess = false;
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                Url = $"{APIBaseUrl}api/ABrand/Brand",
                APIType = APITypes.Post,
                Data = model
            });
            if (response.Success)
            {
                isSuccess = true;
            }
            return isSuccess;
        }
        public async Task<bool> UpdateBrand(BrandDto model)
        {
            bool isSuccess = false;
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                Url = $"{APIBaseUrl}api/ABrand/Brand",
                APIType = APITypes.Put,
                Data = model
            });
            if (response.Success)
            {
                isSuccess = true;
            }
            return isSuccess;
        }
        public async Task<bool> DeleteBrand(long id)
        {
            bool isSuccess = false;
            ResponseDTO response = await _clientService.SendAsync(new()
            {
                Url = $"{APIBaseUrl}api/ABrand/Brand?id={id}",
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
