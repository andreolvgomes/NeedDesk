using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Status")]
    public class Status : EntityBase
    {
        [Key]
        public Int64 Sta_id { get; set; }
        public Int64 Tenant_id { get; set; }
        public string Sta_descricao { get; set; }
        public bool Sta_inativo { get; set; }
    }
}