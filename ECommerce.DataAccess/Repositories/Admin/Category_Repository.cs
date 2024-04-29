using Dapper;
using ECommerce.DataAccess.UOW;
using ECommerce.Entities.Admin;
using ECommerce.Entities.Admin.Brand;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories.Admin
{
    public class Category_Repository
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category_Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<TB_CATEGORY> GetCats()
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetCategories");
            return _unitOfWork.Connection.Query<TB_CATEGORY>("sp_ACategories", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public TB_CATEGORY? GetCatById(long id)
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetCategoryById");
            dbParams.Add("@TB_ID", id);
            return _unitOfWork.Connection.QueryFirstOrDefault<TB_CATEGORY>("sp_ACategories", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public string DeleteCat(long id, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "DeleteCategory");
            dbParams.Add("@TB_ID", id);
            var affectedRow = _unitOfWork.Connection.Execute("sp_ACategories", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Category Deleted successfully";
            }
            return "This Category does not Deleted. Please try again later.";
        }
        public string CreateCat(TB_CATEGORY model, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "CreateCategory");
            dbParams.Add("@TB_NAME", model.TB_NAME);
            dbParams.Add("@TB_DESC", model.TB_DESC);
            dbParams.Add("@TB_STATUS", model.TB_STATUS);
            dbParams.Add("@TB_PARENTID", model.TB_PARENTID);
            dbParams.Add("@TB_ORDER", model.TB_ORDER);
            dbParams.Add("@TB_IMG", model.TB_IMG);
            dbParams.Add("@TB_CREATE", DateTime.Now);
            dbParams.Add("@TB_MODIFY", DateTime.Now);
            dbParams.Add("@TB_CREATE_USER", model.TB_CREATE_USER);
            dbParams.Add("@TB_MODIFY_USER", model.TB_MODIFY_USER);
            var affectedRow = _unitOfWork.Connection.Execute("sp_ACategories", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Category successfully created";
            }
            return "This Category does not updated. Please try again later.";
        }
        public string UpdateCat(TB_CATEGORY model, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "UpdateCategory");
            dbParams.Add("@TB_ID", model.TB_ID);
            dbParams.Add("@TB_NAME", model.TB_NAME);
            dbParams.Add("@TB_DESC", model.TB_DESC);
            dbParams.Add("@TB_STATUS", model.TB_STATUS);
            dbParams.Add("@TB_PARENTID", model.TB_PARENTID);
            dbParams.Add("@TB_ORDER", model.TB_ORDER);
            dbParams.Add("@TB_IMG", model.TB_IMG);
            dbParams.Add("@TB_MODIFY", DateTime.Now);
            dbParams.Add("@TB_MODIFY_USER", model.TB_MODIFY_USER);
            var affectedRow = _unitOfWork.Connection.Execute("sp_ACategories", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Category successfully updated";
            }
            return "This Category does not saved. Please try again later.";
        }
        public long GetCategoriesCount()
        {
            long counts = 0;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetCategoriesCount");
            dbParams.Add("@CatCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _unitOfWork.Connection.Execute("sp_ACategories", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            counts = dbParams.Get<int>("@CatCount");
            return counts;
        }
        public IEnumerable<TB_CATEGORY> GetSubCats()
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetSubCat");
            return _unitOfWork.Connection.Query<TB_CATEGORY>("sp_ACategories", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public long GetSubCatCount()
        {
            long counts = 0;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetSubCatsCount");
            dbParams.Add("@CatCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _unitOfWork.Connection.Execute("sp_ACategories", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            counts = dbParams.Get<int>("@CatCount");
            return counts;
        }
    }
}
