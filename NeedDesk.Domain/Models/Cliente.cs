using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class Cliente : EntityBase
    {
        public Int64 Cli_id { get; set; }
        public string Cli_nome { get; set; }
        public bool Cli_inativo { get; set; }
    }
}