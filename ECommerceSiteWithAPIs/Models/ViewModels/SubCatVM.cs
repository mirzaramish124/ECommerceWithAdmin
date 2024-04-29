using ECommerceSiteWithAPIs.Models.Dtos;

namespace ECommerceSiteWithAPIs.Models.ViewModels
{
    public class SubCatVM
    {
        public List<CategoryDto> SubCats { get; set; }
        public List<CategoryDto> Cats { get; set; }
    }
}
