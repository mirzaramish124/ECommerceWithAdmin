using ECommerce.Entities.Admin.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Admin.IServices
{
    public interface IBrand
    {
        IEnumerable<TB_BRANDS> GetBrands();
        TB_BRANDS GetBrandById(long id);
        string DeleteBrand(long id, out bool error);
        string CreateBrand(TB_BRANDS model, out bool error);
        string UpdateBrand(TB_BRANDS model, out bool error);
        long GetBrandsCount();
    }
}
