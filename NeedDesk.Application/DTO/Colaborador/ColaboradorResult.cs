using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Colaborador
{
    public class ColaboradorResult
    {
        public Guid Col_id { get; set; }
        public string Col_nome { get; set; }
        public string Col_sobrenome { get; set; }
        public string Col_inativo { get; set; }
    }
}