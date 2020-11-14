using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Colaborador
{
    public class ColaboradorStatus
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Col_id { get; set; }
        public bool Col_inativo { get; set; }
    }
}