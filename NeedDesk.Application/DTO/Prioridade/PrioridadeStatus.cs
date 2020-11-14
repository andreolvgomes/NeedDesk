using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Prioridade
{
    public class PrioridadeStatus
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Pri_id { get; set; }
        public bool Pri_inativo { get; set; }
    }
}