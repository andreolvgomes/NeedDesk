using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Departamento
{
    public class DepartamentoCreate : Tenant_idDto
    {
        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(50, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Dep_descricao { get; set; }
    }
}