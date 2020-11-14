using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Status
{
    public class StatusStatus
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Sta_id { get; set; }
        public bool Sta_inativo { get; set; }
    }
}