using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Admin
{
    public class TB_CATEGORY
    {
        public long TB_ID { get; set; }
        [Required]
        public string? TB_NAME { get; set; }
        public string? TB_IMG { get; set; }
        public string? TB_DESC { get; set; }
        public string? TB_PARENTID { get; set; }
        public string? TB_STATUS { get; set; }
        public string? TB_ORDER { get; set; }
        public DateTime TB_CREATE { get; set; }
        public DateTime TB_MODIFY { get; set; }
        public string? TB_CREATE_USER { get; set; }
        public string? TB_MODIFY_USER { get; set; }
    }
}
