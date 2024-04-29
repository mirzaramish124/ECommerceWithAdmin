using System.ComponentModel.DataAnnotations;

namespace ECommerceSiteWithAPIs.Models.Dtos
{
    public class ColorDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? ColorCode { get; set; }
        public string? Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modify { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifyUser { get; set; }
    }
}
