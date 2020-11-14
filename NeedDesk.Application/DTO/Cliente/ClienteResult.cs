using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Cliente
{
    public class ClienteResult
    {
        public Guid Cli_id { get; set; }
        public string Cli_nome { get; set; }
        public bool Cli_inativo { get; set; }
    }
}