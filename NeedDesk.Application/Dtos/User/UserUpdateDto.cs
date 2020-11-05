using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.Dtos.User
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public Int64 Use_id { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(50, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Use_email { get; set; }
    }
}
