﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Departamentos_Status")]
    public class DepartamentosStatus : EntityBase
    {
        public Int64 Tenant_id { get; set; }
        [Key]
        public Int64 Des_id { get; set; }
        public Int64 Dep_id { get; set; }
        public Int64 Sta_id { get; set; }
    }
}