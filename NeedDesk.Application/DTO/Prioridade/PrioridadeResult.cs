using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Prioridade
{
    public class PrioridadeResult
    {
        public Guid Pri_id { get; set; }
        public string Pri_descricao { get; set; }
        public bool Pri_inativo { get; set; }
    }
}