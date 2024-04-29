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
    public class Product_Repository
    {
        private readonly IUnitOfWork _unitOfWork;
        public Product_Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<TB_PRO> GetProducts()
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetProducts");
            return _unitOfWork.Connection.Query<TB_PRO>("sp_AProduct", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public TB_PRO? GetProductById(long id)
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetProductById");
            dbParams.Add("@TB_ID", id);
            return _unitOfWork.Connection.QueryFirstOrDefault<TB_PRO>("sp_AProduct", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public string DeleteProduct(long id, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "DeleteProduct");
            dbParams.Add("@TB_ID", id);
            var affectedRow = _unitOfWork.Connection.Execute("sp_AProduct", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Product Deleted successfully";
            }
            return "This Product does not Deleted. Please try again later.";
        }
        public string CreateProduct(TB_PRO model, out bool error)
        {
            error = true;
            //DynamicParameters exitdbParams = new DynamicParameters();
            //exitdbParams.Add("Operation", "IsExist");
            //exitdbParams.Add("@TB_NAME", model.TB_NAME);
            //var exist = _unitOfWork.Connection.QueryFirstOrDefault<TB_CATEGORY>("sp_ACategories", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: exitdbParams);
            //if (exist != null)
            //{
            //    error = true;
            //    return "This category is already exist";
            //}
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "CreateProduct");
            dbParams.Add("@TB_NAME", model.TB_BRAND_ID);
            dbParams.Add("@TB_NAME", model.TB_CAT_ID);
            dbParams.Add("@TB_NAME", model.TB_SUBCAT_ID);
            dbParams.Add("@TB_NAME", model.TB_NAME);
            dbParams.Add("@TB_DESC", model.TB_DESC);
            dbParams.Add("@TB_NAME", model.TB_STATUS);
            dbParams.Add("@TB_STATUS", model.TB_ORDER);
            dbParams.Add("@TB_CREATE", DateTime.Now);
            dbParams.Add("@TB_MODIFY", DateTime.Now);
            dbParams.Add("@TB_CREATE_USER", model.TB_CREATE_USER);
            dbParams.Add("@TB_MODIFY_USER", model.TB_MODIFY_USER);
            var affectedRow = _unitOfWork.Connection.Execute("sp_AProduct", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Product successfully created";
            }
            return "This Product does not updated. Please try again later.";
        }
        public string UpdateProduct(TB_PRO model, out bool error)
        {
            error = true;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "UpdateProduct");
            dbParams.Add("@TB_ID", model.TB_ID);
            dbParams.Add("@TB_BRAND_ID", model.TB_BRAND_ID);
            dbParams.Add("@TB_CAT_ID", model.TB_CAT_ID);
            dbParams.Add("@TB_SUBCAT_ID", model.TB_SUBCAT_ID);
            dbParams.Add("@TB_NAME", model.TB_NAME);
            dbParams.Add("@TB_DESC", model.TB_DESC);
            dbParams.Add("@TB_STATUS", model.TB_STATUS);
            dbParams.Add("@TB_ORDER", model.TB_ORDER);
            dbParams.Add("@TB_MODIFY", DateTime.Now);
            dbParams.Add("@TB_MODIFY_USER", model.TB_MODIFY_USER);
            var affectedRow = _unitOfWork.Connection.Execute("sp_AProduct", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            if (affectedRow > 0)
            {
                error = false;
                return "Product successfully updated";
            }
            return "This Product does not saved. Please try again later.";
        }
        public long GetProductCount()
        {
            long counts = 0;
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetProductCount");
            dbParams.Add("@CatCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _unitOfWork.Connection.Execute("sp_AProduct", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
            counts = dbParams.Get<int>("@CatCount");
            return counts;
        }
        public IEnumerable<TB_BRANDS> GetBrands()
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetBrands");
            return _unitOfWork.Connection.Query<TB_BRANDS>("sp_AProduct", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        } 
        public IEnumerable<TB_CATEGORY> GetCats()
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetCats");
            return _unitOfWork.Connection.Query<TB_CATEGORY>("sp_AProduct", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
        public IEnumerable<TB_CATEGORY> GetSubCats()
        {
            DynamicParameters dbParams = new DynamicParameters();
            dbParams.Add("Operation", "GetSubCats");
            return _unitOfWork.Connection.Query<TB_CATEGORY>("sp_AProduct", transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure, param: dbParams);
        }
    }
}
