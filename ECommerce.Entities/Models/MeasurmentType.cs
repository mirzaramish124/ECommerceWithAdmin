using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Models
{
    public class MeasurmentType
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modify { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifyUser { get; set; }
    }
}
