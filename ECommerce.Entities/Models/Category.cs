
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entities.Models
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public long ParentId { get; set; }
        public string? Status { get; set; }
        public long Order { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modify { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifyUser { get; set; }
    }
}
