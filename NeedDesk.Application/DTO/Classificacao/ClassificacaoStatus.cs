using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Classificacao
{
    public class ClassificacaoStatus
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Cla_id { get; set; }
        public bool Cla_inativo { get; set; }
    }
}