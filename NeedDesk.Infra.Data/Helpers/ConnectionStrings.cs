using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Infra.Data
{
    public class ConnectionStrings
    {
        public override string ToString()
        {
            string database = "need";
            //return String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", "localhost", "3306", "root", "123456", database);
            return String.Format("server=.\\sql2;database=need;user id=sa;pwd=sic742");
        }
    }
}
