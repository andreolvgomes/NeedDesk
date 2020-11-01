using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Prioridades")]
    public class Prioridade : EntityBase
    {
        [Key]
        public Int64 Pri_id { get; set; }
        public Int64 Tenant_id { get; set; }
        public string Pri_descricao { get; set; }
        public bool Pri_inativo { get; set; }
    }
}
