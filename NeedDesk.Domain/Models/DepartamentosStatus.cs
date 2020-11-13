using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Departamentos_Status")]
    public class DepartamentosStatus : EntityBase, IEntity
    {
        [Key]
        public Guid Des_id { get; set; }
        public Guid Dep_id { get; set; }
        public Guid Sta_id { get; set; }
    }
}
