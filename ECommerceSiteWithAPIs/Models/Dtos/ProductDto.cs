using ECommerce.Entities.Models;

namespace ECommerceSiteWithAPIs.Models.Dtos
{
    public class ProductDto
    {
        public long Id { get; set; }
        public long BrandId { get; set; }
        public BrandDto Brand { get; set; }
        public long CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public long SubCategoryId { get; set; }
        public CategoryDto SubCategory { get; set; }
        public long MeasurmentTypeId { get; set; }
        public MeasurmentTypeDto MeasurmentType { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Brief { get; set; }
        public string? Code { get; set; }
        public string? RefNo { get; set; }
        public double CanWrite { get; set; }
        public double WritePrice { get; set; }
        public string? Status { get; set; }
        public string? Order { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modify { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifyUser { get; set; }
    }
}
