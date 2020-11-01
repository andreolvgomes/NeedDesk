using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NeedDesk.Domain.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection Connect();
    }
}