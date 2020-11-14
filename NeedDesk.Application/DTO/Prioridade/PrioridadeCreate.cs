using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Prioridade
{
    public class PrioridadeCreate : Tenant_idDto
    {
        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(50, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Pri_descricao { get; set; }
    }
}