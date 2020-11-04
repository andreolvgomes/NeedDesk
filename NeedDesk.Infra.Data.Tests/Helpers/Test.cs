using System;
using System.Collections.Generic;
using System.Text;
using NeedDesk.Domain.Interfaces;
using NeedDesk.Infra.Data.Dapper;

namespace NeedDesk.Infra.Data.Tests
{
    public class Test
    {
        public static IConnectionFactory Connect
        {
            get
            {
                //return new ConnectionSqlServer();
                return new ConnectionMySql();
            }
        }
    }
}
