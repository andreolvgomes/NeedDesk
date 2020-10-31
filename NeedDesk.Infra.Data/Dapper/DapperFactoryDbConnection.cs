using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NeedDesk.Infra.Data.Dapper
{
    public class DapperFactory: IDapperDbConnection
    {
        private readonly IDapperDbConnection _dapperConnection;

        public DapperFactory(IDapperDbConnection dapperConnection)
        {
            _dapperConnection = dapperConnection;
        }

        public IDbConnection Connect()
        {
            return _dapperConnection.Connect();
        }
    }
}
