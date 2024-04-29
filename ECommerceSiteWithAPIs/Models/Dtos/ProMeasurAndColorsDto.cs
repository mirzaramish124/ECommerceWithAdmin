namespace ECommerceSiteWithAPIs.Models.Dtos
{
    public class ProMeasurAndColorsDto
    {
        public long TB_ID { get; set; }
        public long TB_PRO_ID { get; set; }
        public long TB_MTYPE { get; set; }
        public long TB_MEASUR_ID { get; set; }
        public long TB_COLOR_ID { get; set; }
        public string? TB_DESC { get; set; }
        public string? TB_STATUS { get; set; }
        public string? TB_ORDER { get; set; }
        public DateTime TB_CREATE { get; set; }
        public DateTime TB_MODIFY { get; set; }
        public string? TB_CREATE_USER { get; set; }
        public string? TB_MODIFY_USER { get; set; }
    }
}
