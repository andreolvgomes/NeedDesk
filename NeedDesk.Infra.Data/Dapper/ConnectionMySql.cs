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
    public class ConnectionMySql : IConnectionFactory
    {
        public ConnectionMySql()
        {
            DapperEasyCrud.SetDialect(Dialect.MySQL);
        }

        public IDbConnection Connect()
        {
            //return new MySqlConnection(new ConnectionStrings().ToString());
            return new MySqlConnection(String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", "localhost", "3306", "root", "123456", "need"));
        }
    }
}