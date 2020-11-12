﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Departamentos_Categorias")]
    public class DepartamentoCategoria : EntityBase, IEntity
    {
        [Key]
        public Int64 Dec_id { get; set; }
        public Int64 Dep_id { get; set; }
        public Int64 Cat_id { get; set; }
    }
}