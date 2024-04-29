using static ECommerceSiteWithAPIs.Utility.SD;

namespace ECommerceSiteWithAPIs.Models.ClientModels
{
    public class RequestDto
    {
        public APITypes APIType { get; set; } = APITypes.Get;
        public string Url { get; set; }
        public object? Data { get; set; }
    }
}
