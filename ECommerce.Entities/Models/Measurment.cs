
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entities.Models
{
    public class Measurment
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modify { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifyUser { get; set; }
    }
}
