using Dapper;
using ECommerce.DataAccess.UOW;
using ECommerce.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories.Admin
{
    public class Measurment_Repository
    {
        private readonly IUnitOfWork _unitOfWork;
        public Measurment_Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<TB_MEASURMENT> GetMeasurments()
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetMeasurments");
            return _unitOfWork.Connection.Query<TB_MEASURMENT>("sp_AMeasurment", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public TB_MEASURMENT? GetMeasurmentById(long id)
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetMeasurmentById");
            dbParams.Add("@TB_ID", id);
            return _unitOfWork.Connection.QueryFirstOrDefault<TB_MEASURMENT>("sp_AMeasurment", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public string DeleteMeasurment(long id, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "DeleteMeasurment");
            dbParams.Add("@TB_ID", id);
            var affectedRow = _unitOfWork.Connection.Execute("sp_AMeasurment", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Measurment Deleted successfully";
            }
            return "This Brand does not Deleted. Please try again later.";
        }
        public string CreateMeasurment(TB_MEASURMENT model, out bool error)
        {
            error = true;
            DynamicParameters exitdbParams = new DynamicParameters();
            exitdbParams.Add("Operation", "IsExist");
            exitdbParams.Add("@TB_NAME", model.TB_NAME);
            var exist = _unitOfWork.Connection.QueryFirstOrDefault<TB_MEASURMENT>("sp_AMeasurment", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: exitdbParams);
            if (exist != null)
            {
                error = true;
                return "This measurment is already exist";
            }
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "CreateMeasurment");
            dbParams.Add("@TB_NAME", model.TB_NAME);
            dbParams.Add("@TB_TYPE", model.TB_TYPE);
            dbParams.Add("@TB_STATUS", model.TB_STATUS);
            dbParams.Add("@TB_CREATE", DateTime.Now);
            dbParams.Add("@TB_MODIFY", DateTime.Now);
            dbParams.Add("@TB_CREATE_USER", model.TB_CREATE_USER);
            dbParams.Add("@TB_MODIFY_USER", model.TB_MODIFY_USER);
            var affectedRow = _unitOfWork.Connection.Execute("sp_AMeasurment", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Measurment successfully created";
            }
            return "This Measurment does not updated. Please try again later.";
        }
        public string UpdateMeasurment(TB_MEASURMENT model, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "UpdateMeasurment");
            dbParams.Add("@TB_ID", model.TB_ID);
            dbParams.Add("@TB_NAME", model.TB_NAME);
            dbParams.Add("@TB_TYPE", model.TB_TYPE);
            dbParams.Add("@TB_STATUS", model.TB_STATUS);
            dbParams.Add("@TB_MODIFY", DateTime.Now);
            dbParams.Add("@TB_MODIFY_USER", model.TB_MODIFY_USER);
            var affectedRow = _unitOfWork.Connection.Execute("sp_AMeasurment", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Measurment successfully updated";
            }
            return "This Measurment does not saved. Please try again later.";
        }
    }
}
