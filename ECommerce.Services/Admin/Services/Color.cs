using ECommerce.DataAccess.Generics;
using ECommerce.DataAccess.Repositories.Admin;
using ECommerce.DataAccess.UOW;
using ECommerce.Entities.Admin;
using ECommerce.Services.Admin.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Admin.Services
{
    public class Color : IColor
    {
        public IEnumerable<TB_COLOR> GetColors()
        {
            IEnumerable<TB_COLOR> Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Color_Reporsitory repo = new Color_Reporsitory(unitOfWork);
                    Obj = repo.GetColors();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }

        public TB_COLOR GetColorById(long id)
        {
            TB_COLOR Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Color_Reporsitory repo = new Color_Reporsitory(unitOfWork);
                    Obj = repo.GetColorById(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }
        public string DeleteColor(long id, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Color_Reporsitory repo = new Color_Reporsitory(unitOfWork);
                    message = repo.DeleteColor(id, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }
        public string CreateColor(TB_COLOR model, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Color_Reporsitory repo = new Color_Reporsitory(unitOfWork);
                    message = repo.CreateColor(model, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }

        public string UpdateColor(TB_COLOR model, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Color_Reporsitory repo = new Color_Reporsitory(unitOfWork);
                    message = repo.UpdateColor(model, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }
    }
}
