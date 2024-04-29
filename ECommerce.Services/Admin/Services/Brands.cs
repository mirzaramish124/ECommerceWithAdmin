using ECommerce.DataAccess.Generics;
using ECommerce.DataAccess.Repositories.Admin;
using ECommerce.DataAccess.UOW;
using ECommerce.Entities.Admin.Brand;
using ECommerce.Services.Admin.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Admin.Services
{
    public class Brands : IBrand
    {
        public IEnumerable<TB_BRANDS> GetBrands()
        {
            IEnumerable<TB_BRANDS> Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Brand_Repository repo = new Brand_Repository(unitOfWork);
                    Obj = repo.GetBrands();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }

        public TB_BRANDS GetBrandById(long id)
        {
            TB_BRANDS Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Brand_Repository repo = new Brand_Repository(unitOfWork);
                    Obj = repo.GetBrandById(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }
        public string DeleteBrand(long id, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Brand_Repository repo = new Brand_Repository(unitOfWork);
                    message = repo.DeleteBrand(id, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }
        public string CreateBrand(TB_BRANDS model, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Brand_Repository repo = new Brand_Repository(unitOfWork);
                    message = repo.CreateBrand(model, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }

        public string UpdateBrand(TB_BRANDS model, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Brand_Repository repo = new Brand_Repository(unitOfWork);
                    message = repo.UpdateBrand(model, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }
        public long GetBrandsCount()
        {
            long bCount = 0;
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Brand_Repository repo = new Brand_Repository(unitOfWork);
                    bCount = repo.GetbrandsCount();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return bCount;
        }


    }
}
