using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public abstract class EntityBase
    {
        //public Int64 Tenant_id { get; set; }
        public Guid Identifier { get; set; }
        [CreateAt]
        public DateTime CreateAt { get; set; }
        [UpdateAt]
        public DateTime UpdateAt { get; set; }
    }
}