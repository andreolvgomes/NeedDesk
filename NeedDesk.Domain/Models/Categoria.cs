using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Categorias")]
    public class Categoria : EntityBase, IEntity
    {
        [Key]
        public Guid Cat_id { get; set; }
        public string Cat_descricao { get; set; }
        public bool Cat_inativo { get; set; }
    }
}