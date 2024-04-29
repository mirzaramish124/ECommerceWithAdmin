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
    public class Color_Reporsitory
    {
        private readonly IUnitOfWork _unitOfWork;
        public Color_Reporsitory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<TB_COLOR> GetColors()
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetColors");
            return _unitOfWork.Connection.Query<TB_COLOR>("sp_AColor", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public TB_COLOR? GetColorById(long id)
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetColorById");
            dbParams.Add("@TB_ID", id);
            return _unitOfWork.Connection.QueryFirstOrDefault<TB_COLOR>("sp_AColor", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public string DeleteColor(long id, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "DeleteColor");
            dbParams.Add("@TB_ID", id);
            var affectedRow = _unitOfWork.Connection.Execute("sp_AColor", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Color Deleted successfully";
            }
            return "This Color does not Deleted. Please try again later.";
        }
        public string CreateColor(TB_COLOR model, out bool error)
        {
            error = true;
            DynamicParameters exitdbParams = new DynamicParameters();
            exitdbParams.Add("Operation", "IsExist");
            exitdbParams.Add("@TB_NAME", model.TB_NAME);
            var exist = _unitOfWork.Connection.QueryFirstOrDefault<TB_COLOR>("sp_AColor", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: exitdbParams);
            if (exist != null)
            {
                error = true;
                return "This color is already exist";
            }
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "CreateColor");
            dbParams.Add("@TB_NAME", model.TB_NAME);
            dbParams.Add("@TB_COLOR_ID", model.TB_COLOUR_ID);
            dbParams.Add("@TB_STATUS", model.TB_STATUS);
            dbParams.Add("@TB_CREATE", DateTime.Now);
            dbParams.Add("@TB_MODIFY", DateTime.Now);
            dbParams.Add("@TB_CREATE_USER", model.TB_CREATE_USER);
            dbParams.Add("@TB_MODIFY_USER", model.TB_MODIFY_USER);
            var affectedRow = _unitOfWork.Connection.Execute("sp_AColor", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Color successfully created";
            }
            return "This Color does not updated. Please try again later.";
        }
        public string UpdateColor(TB_COLOR model, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "UpdateColor");
            dbParams.Add("@TB_ID", model.TB_ID);
            dbParams.Add("@TB_NAME", model.TB_NAME);
            dbParams.Add("@TB_COLOR_ID", model.TB_COLOUR_ID);
            dbParams.Add("@TB_STATUS", model.TB_STATUS);
            dbParams.Add("@TB_MODIFY", DateTime.Now);
            dbParams.Add("@TB_MODIFY_USER", model.TB_MODIFY_USER);
            var affectedRow = _unitOfWork.Connection.Execute("sp_AColor", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Color successfully updated";
            }
            return "This Color does not saved. Please try again later.";
        }
    }
}
