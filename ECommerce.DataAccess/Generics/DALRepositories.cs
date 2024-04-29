using ECommerce.DataAccess.UOW;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Generics
{
    public sealed class Repositories : IDisposable
    {
        private readonly IConfiguration _configuration = null;
        private IDbConnection _Connection = null;
        private UnitofWork _unitofWork =  null;
        public Repositories()
        {
            try
            {
                _Connection = new SqlConnection(DbHelper.ConnectionString());
                _Connection.Open();
                _unitofWork = new UnitofWork(_Connection);
            }
            catch (Exception ex)
            {

                throw new Exception("Error: Db Connection isn't successfully established" + ex.ToString());
            }
        }
        public UnitofWork UnitofWork
        {
            get { return _unitofWork; }
        }

        public void Dispose()
        {
            _unitofWork.Dispose();
            _Connection.Dispose();
        }
    }
}
