using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entities.Models
{
    public class Stock_Temp
    {
        [Key]
        public long Id { get; set; }
        public long StockId { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public long MeasurmentTypeId { get; set; }
        [ForeignKey("MeasurmentTypeId")]
        public MeasurmentType MeasurmentType { get; set; }
        public long MeasurmentId { get; set; }
        [ForeignKey("MeasurmentId")]
        public Measurment Measurment { get; set; }
        public long ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Color Color { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public long Qty { get; set; }
        public string? Status { get; set; }
        public long UserId { get; set; }
        //public DateTime Create { get; set; }
        //public DateTime Modify { get; set; }
        //public string? CreateUser { get; set; }
        //public string? ModifyUser { get; set; }
    }
}
