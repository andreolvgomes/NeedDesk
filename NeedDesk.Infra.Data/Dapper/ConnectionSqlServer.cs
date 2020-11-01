using Dapper;
using Dapper.EasyCrud;
using MySql.Data.MySqlClient;
using NeedDesk.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NeedDesk.Infra.Data.Dapper
{
    public class ConnectionSqlServer : IConnectionFactory
    {
        public IDbConnection Connect()
        {
            return new MySqlConnection(new ConnectionStrings().ToString());
        }
    }
}