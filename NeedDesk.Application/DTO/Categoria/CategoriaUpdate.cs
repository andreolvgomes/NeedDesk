using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Categoria
{
    public class CategoriaUpdate : BaseCreateDto
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Int64 Cat_id { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(50, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Cat_descricao { get; set; }
    }
}
