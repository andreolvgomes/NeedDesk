using Dapper;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using NeedDesk.Infra.Data.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NeedDesk.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly DapperFactoryDbConnection _dapperFactory;

        public RepositoryBase()
        {
            _dapperFactory = new DapperFactoryDbConnection(new DapperConnectionMySql());
        }

        public IEnumerable<TEntity> All(string conditions, object param = null, IDbTransaction transaction = null)
        {
            using (IDbConnection cnn = _dapperFactory.Connect())
                return cnn.All<TEntity>(conditions, param, transaction);
        }

        public int Delete(TEntity entity, IDbTransaction transaction = null)
        {
            using (IDbConnection cnn = _dapperFactory.Connect())
                return cnn.Delete<TEntity>(entity, transaction);
        }

        public object Insert(TEntity entity, IDbTransaction transaction = null)
        {
            using (IDbConnection cnn = _dapperFactory.Connect())
                return cnn.Insert<TEntity>(entity, transaction);
        }

        public int Update(TEntity entity, IDbTransaction transaction = null)
        {
            using (IDbConnection cnn = _dapperFactory.Connect())
                return cnn.Update<TEntity>(entity, transaction);
        }
    }
}