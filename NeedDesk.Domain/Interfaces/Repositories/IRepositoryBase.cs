using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NeedDesk.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        object Insert(TEntity entity, IDbTransaction transaction = null);
        TEntity FindById(object id, IDbTransaction transaction = null);
        int Update(TEntity entity, IDbTransaction transaction = null);
        int Delete(TEntity entity, IDbTransaction transaction = null);
        int Delete(object id, IDbTransaction transaction = null);
        IEnumerable<TEntity> All(string conditions, object param = null, IDbTransaction transaction = null);
    }
}