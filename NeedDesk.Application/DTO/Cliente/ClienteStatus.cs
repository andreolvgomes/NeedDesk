using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Cliente
{
    public class ClienteStatus
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Cli_id { get; set; }
        public bool Cli_inativo { get; set; }
    }
}