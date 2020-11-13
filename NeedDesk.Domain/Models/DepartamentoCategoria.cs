using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Departamentos_Categorias")]
    public class DepartamentoCategoria : EntityBase, IEntity
    {
        [Key]
        public Guid Dec_id { get; set; }
        public Guid Dep_id { get; set; }
        public Guid Cat_id { get; set; }
    }
}