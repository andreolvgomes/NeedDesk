using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Categorias_Classificacao")]
    public class CategoriaClassificacao : EntityBase, IEntity
    {
        [Key]
        public Guid Cal_id { get; set; }
        public Guid Cat_id { get; set; }
        public Guid Cla_id { get; set; }
    }
}