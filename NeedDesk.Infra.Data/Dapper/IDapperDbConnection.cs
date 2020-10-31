using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NeedDesk.Infra.Data.Dapper
{
    public interface IDapperDbConnection
    {
        IDbConnection Connect();
    }
}
