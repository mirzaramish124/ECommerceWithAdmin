
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Entities.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public long BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public long SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public Category SubCategory { get; set; }
        public long MeasurmentTypeId { get; set; }
        [ForeignKey("MeasurmentTypeId")]
        public MeasurmentType MeasurmentType { get; set; }
        //public string? MType { get; set; }
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
