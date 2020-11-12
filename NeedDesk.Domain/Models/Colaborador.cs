using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Colaboradores")]
    public class Colaborador : EntityBase, IEntity
    {
        [Key]
        public Int64 Col_id { get; set; }
        public Int64 Use_id { get; set; }
        public string Col_nome { get; set; }
        public string Col_sobrenome { get; set; }
        public bool Col_inativo { get; set; }
    }
}