
namespace ECommerceSiteWithAPIs.Models.Dtos
{
    public class StockDto
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public ProductDto Product { get; set; }
        //public string? MType { get; set; }
        public long? MeasurmentTypeId { get; set; }
        public MeasurmentTypeDto MeasurmentType { get; set; }
        public long? MeasurmentId { get; set; }
        public MeasurmentDto Measurment { get; set; }
        public long? ColorId { get; set; }
        public ColorDto Color { get; set; }
        public string? RefNo { get; set; }
        public double? PurchasePrice { get; set; }
        public double? SalePrice { get; set; }
        public long? Qty { get; set; }
        public string? Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modify { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifyUser { get; set; }
    }
}
