using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO
{
    public class BaseCreateDto
    {
        [Range(1, Int64.MaxValue, ErrorMessage = "Tenant_id é obrigatório")]
        public Int64 Tenant_id { get; set; }
    }
}
