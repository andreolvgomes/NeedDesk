using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Classificacao")]
    public class Classificacao : EntityBase, IEntity
    {
        [Key]
        public Guid Cla_id { get; set; }
        public string Cla_descricao { get; set; }
        public bool Cla_inativo { get; set; }
    }
}
