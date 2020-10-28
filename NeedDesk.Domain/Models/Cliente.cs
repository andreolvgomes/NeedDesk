using System;
using System.Collections.Generic;
using System.Text;

namespace NeedDesk.Domain.Models
{
    public class Cliente : EntityMaster
    {
        public string Cli_nome { get; set; }
        public bool Cli_inativo { get; set; }
    }
}