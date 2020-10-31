using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class Classificacao : EntityBase
    {
        public Int64 Pri_id { get; set; }
        public string Pri_descricao { get; set; }
        public bool Pri_inativo { get; set; }
    }
}
