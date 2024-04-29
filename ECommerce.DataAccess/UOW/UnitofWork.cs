using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.UOW
{
    public class UnitofWork : IUnitOfWork
    {
        Guid _Id = Guid.Empty;
        IDbConnection _connection = null;
        IDbTransaction _transaction = null;
        public UnitofWork(IDbConnection connection)
        {
            _Id = Guid.NewGuid();
            _connection = connection;
        }

        public Guid Id
        {
            get { return _Id; }
        }

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        public IDbTransaction Transaction
        {
            get { return _transaction; }
        }

        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            if(_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}
