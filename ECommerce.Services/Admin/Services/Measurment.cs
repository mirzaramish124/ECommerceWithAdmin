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
    public class Measurment : IMeasurment
    {
        public IEnumerable<TB_MEASURMENT> GetMeasurments()
        {
            IEnumerable<TB_MEASURMENT> Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Measurment_Repository repo = new Measurment_Repository(unitOfWork);
                    Obj = repo.GetMeasurments();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }

        public TB_MEASURMENT GetMeasurmentById(long id)
        {
            TB_MEASURMENT Obj = null;

            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Measurment_Repository repo = new Measurment_Repository(unitOfWork);
                    Obj = repo.GetMeasurmentById(id);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return Obj;
        }
        public string DeleteMeasurment(long id, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Measurment_Repository repo = new Measurment_Repository(unitOfWork);
                    message = repo.DeleteMeasurment(id, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }
        public string CreateMeasurment(TB_MEASURMENT model, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Measurment_Repository repo = new Measurment_Repository(unitOfWork);
                    message = repo.CreateMeasurment(model, out error);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return message;
        }

        public string UpdateMeasurment(TB_MEASURMENT model, out bool error)
        {
            string message = "";
            using (Repositories dalSession = new Repositories())
            {
                UnitofWork unitOfWork = dalSession.UnitofWork;
                try
                {
                    Measurment_Repository repo = new Measurment_Repository(unitOfWork);
                    message = repo.UpdateMeasurment(model, out error);
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
