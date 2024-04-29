using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entities.Models
{
    public class StockMain
    {
        [Key]
        public long Id { get; set; }
        public long MainId { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        //public string? MType { get; set; }
        public long MeasurmentTypeId { get; set; }
        [ForeignKey("MeasurmentTypeId")]
        public MeasurmentType MeasurmentType { get; set; }
        public string? RefNo { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public long Qty { get; set; }
        public string? Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modify { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifyUser { get; set; }
    }
}
