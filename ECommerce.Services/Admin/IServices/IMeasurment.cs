using ECommerce.Entities.Admin;
using ECommerce.Entities.Admin.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Admin.IServices
{
    public interface IMeasurment
    {
        IEnumerable<TB_MEASURMENT> GetMeasurments();
        TB_MEASURMENT GetMeasurmentById(long id);
        string DeleteMeasurment(long id, out bool error);
        string CreateMeasurment(TB_MEASURMENT model, out bool error);
        string UpdateMeasurment(TB_MEASURMENT model, out bool error);
    }
}
