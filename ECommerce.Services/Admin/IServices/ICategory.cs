using ECommerce.Entities.Admin;
using ECommerce.Entities.Admin.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Admin.IServices
{
    public interface ICategory
    {
        IEnumerable<TB_CATEGORY> GetCats();
        TB_CATEGORY GetCatById(long id);
        string DeleteCat(long id, out bool error);
        string CreateCat(TB_CATEGORY model, out bool error);
        string UpdateCat(TB_CATEGORY model, out bool error);
        long GetCategoriesCount();
        IEnumerable<TB_CATEGORY> GetSubCats();
        long GetSubCatsCount();
    }
}
