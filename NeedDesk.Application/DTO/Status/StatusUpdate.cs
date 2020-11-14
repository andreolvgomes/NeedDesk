using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Status
{
    public class StatusUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Sta_id { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(50, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Sta_descricao { get; set; }
    }
}