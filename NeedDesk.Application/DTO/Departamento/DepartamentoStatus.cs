using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Departamento
{
    public class DepartamentoStatus
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Dep_id { get; set; }
        public bool Dep_inativo { get; set; }
    }
}