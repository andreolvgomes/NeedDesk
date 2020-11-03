using Dapper;
using Dapper.EasyCrud;
using MySql.Data.MySqlClient;
using NeedDesk.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NeedDesk.Infra.Data.Dapper
{
    public class ConnectionSqlServer : IConnectionFactory
    {
        public ConnectionSqlServer()
        {
            DapperEasyCrud.SetDialect(Dialect.SQLServer);
        }

        public IDbConnection Connect()
        {
            //return new SqlConnection(new ConnectionStrings().ToString());
            return new SqlConnection("server=.\\sql2;database=need;user id=sa;pwd=sic742");
        }
    }
}