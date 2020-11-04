using Dapper;
using NeedDesk.Domain.Interfaces;
using NeedDesk.Domain.Interfaces.Repositories;
using NeedDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeedDesk.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public User FindByLogin(string email)
        {
            return _connectionFactory.Connect().Find<User>(new { use_email = email });
        }
    }
}