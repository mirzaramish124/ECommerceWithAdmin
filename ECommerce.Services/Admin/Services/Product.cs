using ECommerce.DataAccess.Generics;
using ECommerce.DataAccess.Repositories.Admin;
using ECommerce.DataAccess.UOW;
using ECommerce.Entities.Admin;
using ECommerce.Entities.Admin.Brand;
using ECommerce.Services.Admin.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Admin.Services
{
    public class Product : IProduct
    {
        public IEnumerable<TB_PRO> GetProducts()
        {
            IEnumerable<TB_PRO> Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Product_Repository repo = new Product_Repository(unitOfWork);
                    Obj = repo.GetProducts();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }

        public TB_PRO GetProductById(long id)
        {
            TB_PRO Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Product_Repository repo = new Product_Repository(unitOfWork);
                    Obj = repo.GetProductById(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }
        public string DeleteProduct(long id, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Product_Repository repo = new Product_Repository(unitOfWork);
                    message = repo.DeleteProduct(id, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }
        public string CreateProduct(TB_PRO model, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Product_Repository repo = new Product_Repository(unitOfWork);
                    message = repo.CreateProduct(model, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }

        public string UpdateProduct(TB_PRO model, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Product_Repository repo = new Product_Repository(unitOfWork);
                    message = repo.UpdateProduct(model, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }
        public long GetProductCount()
        {
            long PCount = 0;
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Product_Repository repo = new Product_Repository(unitOfWork);
                    PCount = repo.GetProductCount();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return PCount;
        }
        public IEnumerable<TB_BRANDS> GetBrands()
        {
            IEnumerable<TB_BRANDS> Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Product_Repository repo = new Product_Repository(unitOfWork);
                    Obj = repo.GetBrands();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }
        public IEnumerable<TB_CATEGORY> GetCats()
        {
            IEnumerable<TB_CATEGORY> Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Product_Repository repo = new Product_Repository(unitOfWork);
                    Obj = repo.GetCats();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }
        public IEnumerable<TB_CATEGORY> GetSubCats()
        {
            IEnumerable<TB_CATEGORY> Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Product_Repository repo = new Product_Repository(unitOfWork);
                    Obj = repo.GetSubCats();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }
    }
}
