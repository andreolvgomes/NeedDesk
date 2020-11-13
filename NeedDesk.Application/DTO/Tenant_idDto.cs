using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO
{
    public class Tenant_idDto
    {
        [Required]
        public Guid Tenant_id { get; set; }
    }
}
