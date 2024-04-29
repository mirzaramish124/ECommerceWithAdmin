using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Admin
{
    public class TB_PRO
    {
        public long TB_ID { get; set; }
        public long TB_BRAND_ID { get; set; }
        public long TB_CAT_ID { get; set; }
        public long TB_SUBCAT_ID { get; set; }
        public string? TB_MTYPE { get; set; }
        public string? TB_NAME { get; set; }
        public string? TB_DESC { get; set; }
        public string? TB_BRIEF { get; set; }
        public string? TB_CODE { get; set; }
        public string? TB_REF_NO { get; set; }
        public decimal CAN_WRITE { get; set; }
        public decimal WRITE_PRICE { get; set; }
        public string? TB_STATUS { get; set; }
        public string? TB_ORDER { get; set; }
        public DateTime TB_CREATE { get; set; }
        public DateTime TB_MODIFY { get; set; }
        public string? TB_CREATE_USER { get; set; }
        public string? TB_MODIFY_USER { get; set; }
    }
}
