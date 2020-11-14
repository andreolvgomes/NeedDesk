using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Status
{
    public class StatusResult
    {
        public Guid Sta_id { get; set; }
        public string Sta_descricao { get; set; }
        public bool Sta_inativo { get; set; }
    }
}