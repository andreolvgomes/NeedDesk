using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Classificacao
{
    public class ClassificacaoUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Cla_id { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(50, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Cla_descricao { get; set; }
    }
}