using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.User
{
    public class UserCreate
    {
        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(50, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Use_email { get; set; }

        [Required(ErrorMessage = "Senha é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "Senha deve ter no máximo {1} caracteres.")]
        public string Use_senha { get; set; }
    }
}