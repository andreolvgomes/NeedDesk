using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Tenants")]
    public class Tenant : EntityBase
    {
        [Key]
        public Int64 Tenant_id { get; set; }
    }
}