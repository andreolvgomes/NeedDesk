using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Colaborador
{
    public class ColaboradorUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Col_id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Col_nome { get; set; }

        [Required(ErrorMessage = "SobreNome é obrigatório")]
        [StringLength(50, ErrorMessage = "SobreNome deve ter no máximo {1} caracteres")]
        public string Col_sobrenome { get; set; }
    }
}