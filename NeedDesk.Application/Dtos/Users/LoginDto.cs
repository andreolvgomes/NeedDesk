using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeedDesk.Application.Dtos.Users
{
    public class LoginDto
    {
        [Required(ErrorMessage = "E-mail é obritatório")]
        [EmailAddress(ErrorMessage = "E-mail com formato inválido")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}