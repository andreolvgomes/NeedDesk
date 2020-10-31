using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Clientes")]
    public class Cliente : EntityBase
    {
        [Key]
        public Int64 Cli_id { get; set; }
        public Int64 Tenant_id { get; set; }
        public string Cli_nome { get; set; }
        public bool Cli_inativo { get; set; }
    }
}