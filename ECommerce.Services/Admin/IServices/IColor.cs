using ECommerce.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Admin.IServices
{
    public interface IColor
    {
        IEnumerable<TB_COLOR> GetColors();
        TB_COLOR GetColorById(long id);
        string DeleteColor(long id, out bool error);
        string CreateColor(TB_COLOR model, out bool error);
        string UpdateColor(TB_COLOR model, out bool error);
    }
}
