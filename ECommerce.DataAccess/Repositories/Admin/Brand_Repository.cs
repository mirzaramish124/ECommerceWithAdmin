using Dapper;
using ECommerce.DataAccess.UOW;
using ECommerce.Entities.Admin;
using ECommerce.Entities.Admin.Brand;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories.Admin
{
    public class Brand_Repository
    {
        private readonly IUnitOfWork _unitOfWork;
        public Brand_Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<TB_BRANDS> GetBrands()
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetBrands");
            return _unitOfWork.Connection.Query<TB_BRANDS>("sp_ABrands", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public TB_BRANDS? GetBrandById(long id)
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetBrandById");
            dbParams.Add("@TB_ID", id);
            return _unitOfWork.Connection.QueryFirstOrDefault<TB_BRANDS>("sp_ABrands", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public string DeleteBrand(long id, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "DeleteBrand");
            dbParams.Add("@TB_ID", id);
            var affectedRow = _unitOfWork.Connection.Execute("sp_ABrands", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Brand Deleted successfully";
            }
            return "This Brand does not Deleted. Please try again later.";
        }
        public string CreateBrand(TB_BRANDS model, out bool error)
        {
            error = true;
            DynamicParameters exitdbParams = new DynamicParameters();
            exitdbParams.Add("Operation", "IsExist");
            exitdbParams.Add("@TB_NAME", model.TB_NAME);
            var exist = _unitOfWork.Connection.QueryFirstOrDefault<TB_BRANDS>("sp_ABrands", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: exitdbParams);
            if (exist != null)
            {
                error = true;
                return "This brand is already exist";
            }
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "CreateBrand");
            dbParams.Add("@TB_NAME", model.TB_NAME);
            dbParams.Add("@TB_DESC", model.TB_DESC);
            dbParams.Add("@TB_STATUS", model.TB_STATUS);
            dbParams.Add("@TB_ORDER", model.TB_ORDER);
            dbParams.Add("@TB_IMG", model.TB_IMG);
            dbParams.Add("@TB_CREATE", DateTime.Now);
            dbParams.Add("@TB_MODIFY", DateTime.Now);
            dbParams.Add("@TB_CREATE_USER", model.TB_CREATE_USER);
            dbParams.Add("@TB_MODIFY_USER", model.TB_MODIFY_USER);
            var affectedRow = _unitOfWork.Connection.Execute("sp_ABrands", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Brand successfully created";
            }
            return "This Brand does not updated. Please try again later.";
        }
        public string UpdateBrand(TB_BRANDS model, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "UpdateBrand");
            dbParams.Add("@TB_ID", model.TB_ID);
            dbParams.Add("@TB_NAME", model.TB_NAME);
            dbParams.Add("@TB_DESC", model.TB_DESC);
            dbParams.Add("@TB_STATUS", model.TB_STATUS);
            dbParams.Add("@TB_ORDER", model.TB_ORDER);
            dbParams.Add("@TB_IMG", model.TB_IMG);
            dbParams.Add("@TB_MODIFY", DateTime.Now);
            dbParams.Add("@TB_MODIFY_USER", model.TB_MODIFY_USER);
            var affectedRow = _unitOfWork.Connection.Execute("sp_ABrands", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Brand successfully updated";
            }
            return "This Brand does not saved. Please try again later.";
        }
        public long GetbrandsCount()
        {
            long counts = 0;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetBrandsCount");
            dbParams.Add("@BrandCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _unitOfWork.Connection.Execute("sp_ABrands", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            counts = dbParams.Get<int>("@BrandCount");
            return counts;
        }
    }
}
