using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Categoria
{
    public class CategoriaStatus
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Cat_id { get; set; }
        public bool Cat_inativo { get; set; }
    }
}