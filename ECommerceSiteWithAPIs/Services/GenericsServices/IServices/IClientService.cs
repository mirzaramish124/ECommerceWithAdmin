using ECommerceSiteWithAPIs.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSiteWithAPIs.Services.GenericsServices.IServices
{
    public interface IClientService
    {
        Task<ResponseDTO> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
