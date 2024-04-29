using ECommerce.Entities.Admin;
using ECommerce.Entities.Admin.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Admin.IServices
{
    public interface IProduct
    {
        IEnumerable<TB_PRO> GetProducts();
        TB_PRO GetProductById(long id);
        string DeleteProduct(long id, out bool error);
        string CreateProduct(TB_PRO model, out bool error);
        string UpdateProduct(TB_PRO model, out bool error);
        long GetProductCount();
        IEnumerable<TB_BRANDS> GetBrands();
        IEnumerable<TB_CATEGORY> GetCats();
        IEnumerable<TB_CATEGORY> GetSubCats();
    }
}
