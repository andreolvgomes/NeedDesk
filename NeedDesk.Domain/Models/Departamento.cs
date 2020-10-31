﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Departamentos")]
    public class Departamento : EntityBase
    {
        [Key]
        public Int64 Dep_id { get; set; }
        public Int64 Tenant_id { get; set; }
        public string Dep_descricao { get; set; }
        public bool Dep_inativo { get; set; }
    }
}