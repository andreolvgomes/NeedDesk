using Dapper;
using Dapper.EasyCrud;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NeedDesk.Infra.Data.Dapper
{
    public class ConnectionDapper
    {
        public ConnectionDapper()
        {
            DapperEasyCrud.SetDialect(Dialect.MySQL);
        }

        public IDbConnection Cnn()
        {
            return new MySqlConnection(new ConnectionStrings().ToString());
        }
    }
}
