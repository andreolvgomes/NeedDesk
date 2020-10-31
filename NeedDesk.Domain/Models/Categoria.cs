using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Categorias")]
    public class Categoria : EntityBase
    {
        [Key]
        public Int64 Cat_id { get; set; }
        public Int64 Tenant_id { get; set; }
        public string Cat_descricao { get; set; }
        public bool Cat_inativo { get; set; }
    }
}