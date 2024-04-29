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
    public class Category : ICategory
    {
        public IEnumerable<TB_CATEGORY> GetCats()
        {
            IEnumerable<TB_CATEGORY> Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Category_Repository repo = new Category_Repository(unitOfWork);
                    Obj = repo.GetCats();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }

        public TB_CATEGORY GetCatById(long id)
        {
            TB_CATEGORY Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Category_Repository repo = new Category_Repository(unitOfWork);
                    Obj = repo.GetCatById(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }
        public string DeleteCat(long id, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Category_Repository repo = new Category_Repository(unitOfWork);
                    message = repo.DeleteCat(id, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }
        public string CreateCat(TB_CATEGORY model, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Category_Repository repo = new Category_Repository(unitOfWork);
                    message = repo.CreateCat(model, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }

        public string UpdateCat(TB_CATEGORY model, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Category_Repository repo = new Category_Repository(unitOfWork);
                    message = repo.UpdateCat(model, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }
        public long GetCategoriesCount()
        {
            long bCount = 0;
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Category_Repository repo = new Category_Repository(unitOfWork);
                    bCount = repo.GetCategoriesCount();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return bCount;
        }
        public IEnumerable<TB_CATEGORY> GetSubCats()
        {
            IEnumerable<TB_CATEGORY> Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Category_Repository repo = new Category_Repository(unitOfWork);
                    Obj = repo.GetSubCats();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }
        public long GetSubCatsCount()
        {
            long bCount = 0;
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Category_Repository repo = new Category_Repository(unitOfWork);
                    bCount = repo.GetSubCatCount();
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
