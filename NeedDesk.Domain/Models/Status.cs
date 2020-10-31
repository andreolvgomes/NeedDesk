using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class Status : EntityBase
    {
        public Int64 Sta_id { get; set; }
        public string Sta_descricao { get; set; }
        public bool Sta_inativo { get; set; }
    }
}