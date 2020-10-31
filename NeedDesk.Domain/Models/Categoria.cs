using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class Categoria : EntityBase
    {
        public Int64 Cat_id { get; set; }
        public string Cat_descricao { get; set; }
        public bool Cat_inativo { get; set; }
    }
}
