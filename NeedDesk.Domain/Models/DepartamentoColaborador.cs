using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Departamentos_Colaboradores")]
    public class DepartamentoColaborador : EntityBase
    {
        public Int64 Tenant_id { get; set; }
        [Key]
        public Int64 Dec_id { get; set; }
        public Int64 Dep_id { get; set; }
        public Int64 Col_id { get; set; }
    }
}
