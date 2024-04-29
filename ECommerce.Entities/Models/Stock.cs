using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Entities.Models
{
    public class Stock
    {
        [Key]
        public long Id { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        //public string? MType { get; set; }
        public long MeasurmentTypeId { get; set; }
        [ForeignKey("MeasurmentTypeId")]
        public MeasurmentType MeasurmentType { get; set; }
        public long MeasurmentId { get; set; }
        [ForeignKey("MeasurmentId")]
        public Measurment Measurment { get; set; }
        public long ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Color Color { get; set; }
        public string? RefNo { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public long Qty { get; set; }
        public string? Status { get; set; }
        public DateTime? Create { get; set; }
        public DateTime? Modify { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifyUser { get; set; }

        //public long BrandId { get; set; }
        //[ForeignKey("BrandId")]
        //public virtual Brand Brand { get; set; }
        //public long CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        //public virtual Category Category { get; set; }
        //public long BranchId { get; set; }
        //public long VendorId { get; set; }
        //public string? VenderProCode { get; set; }
    }
}
