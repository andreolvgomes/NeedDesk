using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    [Table("Categorias_Classificacao")]
    public class CategoriaClassificacao : EntityBase
    {
        public Int64 Tenant_id { get; set; }
        [Key]
        public Int64 Cal_id { get; set; }
        public Int64 Cat_id { get; set; }
        public Int64 Cla_id { get; set; }
    }
}