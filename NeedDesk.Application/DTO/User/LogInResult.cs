using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.DTO.Users
{
    public class LogIn
    {
        [Required(ErrorMessage = "E-mail é obritatório")]
        [EmailAddress(ErrorMessage = "E-mail com formato inválido")]
        [StringLength(50, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
        public string Use_email { get; set; }

        [Required(ErrorMessage = "Senha é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "Senha deve ter no máximo {1} caracteres.")]
        public string Use_senha { get; set; }
    }
}