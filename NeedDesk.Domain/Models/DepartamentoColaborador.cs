using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Departamentos_Colaboradores")]
    public class DepartamentoColaborador : EntityBase, IEntity
    {
        [Key]
        public Guid Dec_id { get; set; }
        public Guid Dep_id { get; set; }
        public Guid Col_id { get; set; }
    }
}
